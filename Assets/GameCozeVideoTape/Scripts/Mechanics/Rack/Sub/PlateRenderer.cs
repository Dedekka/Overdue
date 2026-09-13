using System.Collections.Generic;
using UnityEngine;

public class PlateRenderer 
{
    private ViewRenderer _viewRenderer;
   

    public PlateRenderer(ViewRenderer viewRenderer )
    {
        _viewRenderer = viewRenderer;
    }

    public void SetViewGanre(GameObject mainGanre, Material materialGanre,int materialIndex)
    {
        _viewRenderer.Initialization(materialGanre, mainGanre, materialIndex);
    }
}
