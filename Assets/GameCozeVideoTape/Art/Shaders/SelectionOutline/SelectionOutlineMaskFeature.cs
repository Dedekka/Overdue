// Unity 6000.3 / URP. Companion for S_Selection_Outline.shadergraph.
// Add this Renderer Feature to the Universal Renderer used by the camera.
// Set ONLY outline materials to the queue below (3999 by default).
// Existing selection scripts and the second-material setup can stay in use.
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

public sealed class SelectionOutlineMaskFeature : ScriptableRendererFeature
{
    [Tooltip("Reserve this queue for the supplied outline Shader Graph materials.")]
    [Range(2501, 5000)]
    public int outlineQueue = 3999;

    private MaskPass pass;

    public override void Create()
    {
        pass?.Dispose();
        pass = new MaskPass
        {
            renderPassEvent = RenderPassEvent.BeforeRenderingTransparents
        };
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (renderingData.cameraData.isPreviewCamera)
            return;

        pass.queue = Mathf.Clamp(outlineQueue, 2501, 5000);
        renderer.EnqueuePass(pass);
    }

    protected override void Dispose(bool disposing)
    {
        pass?.Dispose();
        pass = null;
        Shader.SetGlobalFloat(MaskPass.MaskPassId, 0f);
        Shader.SetGlobalTexture(MaskPass.MaskTextureId, Texture2D.whiteTexture);
    }

    private sealed class MaskPass : ScriptableRenderPass
    {
        internal static readonly int MaskTextureId = Shader.PropertyToID("_STTSelectionMask");
        internal static readonly int MaskPassId = Shader.PropertyToID("_STTSelectionMaskPass");

        private static readonly List<ShaderTagId> ShaderTags = new List<ShaderTagId>
        {
            new ShaderTagId("UniversalForward"),
            new ShaderTagId("UniversalForwardOnly"),
            new ShaderTagId("SRPDefaultUnlit")
        };

        public int queue = 3999;
        private RTHandle compatibilityMask;

        private FilteringSettings GetFilteringSettings()
        {
            return new FilteringSettings(new RenderQueueRange
            {
                lowerBound = queue,
                upperBound = queue
            });
        }

        private static RenderTextureDescriptor GetDescriptor(RenderTextureDescriptor cameraDescriptor)
        {
            cameraDescriptor.graphicsFormat = GraphicsFormat.R8_UNorm;
            cameraDescriptor.depthStencilFormat = GraphicsFormat.None;
            cameraDescriptor.msaaSamples = 1;
            cameraDescriptor.bindMS = false;
            cameraDescriptor.useMipMap = false;
            cameraDescriptor.autoGenerateMips = false;
            cameraDescriptor.enableRandomWrite = false;
            return cameraDescriptor;
        }

        private sealed class PassData
        {
            public RendererListHandle renderers;
            public TextureHandle blackTexture;
        }

        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameContext)
        {
            UniversalCameraData cameraData = frameContext.Get<UniversalCameraData>();
            UniversalRenderingData renderingData = frameContext.Get<UniversalRenderingData>();
            UniversalLightData lightData = frameContext.Get<UniversalLightData>();

            RenderTextureDescriptor descriptor = GetDescriptor(cameraData.cameraTargetDescriptor);
            TextureHandle mask = UniversalRenderer.CreateRenderGraphTexture(
                renderGraph, descriptor, "Sort the Tapes Selection Mask", true, FilterMode.Point);

            DrawingSettings drawing = RenderingUtils.CreateDrawingSettings(
                ShaderTags, renderingData, cameraData, lightData, SortingCriteria.None);
            FilteringSettings filtering = GetFilteringSettings();
            RendererListHandle renderers = renderGraph.CreateRendererList(
                new RendererListParams(renderingData.cullResults, drawing, filtering));

            using (var builder = renderGraph.AddRasterRenderPass<PassData>(
                       "Sort the Tapes: Original Selection Silhouettes", out var data))
            {
                data.renderers = renderers;
                data.blackTexture = renderGraph.defaultResources.blackTexture;

                builder.UseRendererList(renderers);
                builder.UseTexture(data.blackTexture, AccessFlags.Read);
                builder.SetRenderAttachment(mask, 0, AccessFlags.Write);
                builder.SetGlobalTextureAfterPass(mask, MaskTextureId);
                builder.AllowGlobalStateModification(true);
                // An empty selection must still publish a freshly cleared black mask.
                builder.AllowPassCulling(false);

                builder.SetRenderFunc(static (PassData passData, RasterGraphContext context) =>
                {
                    // Avoid reading a texture while simultaneously drawing into it.
                    context.cmd.SetGlobalTexture(MaskTextureId, passData.blackTexture);
                    context.cmd.SetGlobalFloat(MaskPassId, 1f);
                    context.cmd.DrawRendererList(passData.renderers);
                    context.cmd.SetGlobalFloat(MaskPassId, 0f);
                });
            }
        }

        // Also support projects using URP's Compatibility Mode.
#pragma warning disable CS0672, CS0618
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            RenderTextureDescriptor descriptor = GetDescriptor(renderingData.cameraData.cameraTargetDescriptor);
            RenderingUtils.ReAllocateHandleIfNeeded(ref compatibilityMask, descriptor,
                FilterMode.Point, TextureWrapMode.Clamp, name: "Sort the Tapes Selection Mask");
            ConfigureTarget(compatibilityMask);
            ConfigureClear(ClearFlag.Color, Color.black);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            DrawingSettings drawing = CreateDrawingSettings(ShaderTags, ref renderingData, SortingCriteria.None);
            FilteringSettings filtering = GetFilteringSettings();
            CommandBuffer cmd = CommandBufferPool.Get("Sort the Tapes Selection Mask");
            try
            {
                cmd.SetGlobalTexture(MaskTextureId, Texture2D.blackTexture);
                cmd.SetGlobalFloat(MaskPassId, 1f);
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                context.DrawRenderers(renderingData.cullResults, ref drawing, ref filtering);

                cmd.SetGlobalFloat(MaskPassId, 0f);
                cmd.SetGlobalTexture(MaskTextureId, compatibilityMask.nameID);
                context.ExecuteCommandBuffer(cmd);
            }
            finally
            {
                CommandBufferPool.Release(cmd);
            }
        }
#pragma warning restore CS0672, CS0618

        internal void Dispose()
        {
            compatibilityMask?.Release();
            compatibilityMask = null;
        }
    }
}
