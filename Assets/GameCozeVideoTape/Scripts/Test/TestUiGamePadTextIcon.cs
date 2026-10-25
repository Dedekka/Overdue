using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class TestUiGamePadTextIcon : MonoBehaviour
{
    [SerializeField, TextArea(3, 5)] public string text;
    [SerializeField] public TextMeshProUGUI _tempTYext;

    [SerializeField] public List<string> _textTags;
    [SerializeField] public List<TagTypeDeviceSettings> _settingsUiButtonText;
    //[SerializeField] public string _Newtext;

    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;

    [Inject]
    private void Test(ImporterMenuInputControlDevice importerMenuInputControlDevice)
    {
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
    }

    private void OnEnable()
    {
        _importerMenuInputControlDevice.OnChangeDevice += OnChangeDevice;
    }

    private void OnDisable()
    {
        _importerMenuInputControlDevice.OnChangeDevice -= OnChangeDevice;
    }

    private void Start()
    {
        SetText();
    }

    [ContextMenu("SetText")]
    public void SetText()
    {
        string tempText = text;


        CheckTag(ref tempText);


        //if (text.Contains(_textTag))
        //{
        //    tempText = text.Replace(_textTag, _Newtext);
        //}
        _tempTYext.SetText(tempText);
    }

    private void OnChangeDevice(DeviceType type)
    {
        SetText();
    }

    private void CheckTag(ref string text)
    {
        string tempText = text;
        string tempTag = _textTags[0];
        for (int i = 1; i < _textTags.Count; i++)
        {
            if (text.Contains(tempTag))
            {
                tempText = FindIcon(tempTag, tempText);
                //tempText = text.Replace(tempTag, FindIcon(tempTag, text));
            }
            tempTag = _textTags[i];
        }
        text = tempText;
    }

    private string FindIcon(string tempTag, string text)
    {
        int idTag = tempTag switch
        {
            "[Move]" => 1,
            "[Mouse]" => 2,
            _ => throw new NotImplementedException()
        };
        Debug.Log($"FindIcon, Tag{tempTag}, idTag:{idTag}");
    

        return text.Replace(tempTag, GetIcon(idTag));
    }

    private string GetIcon(int idTag)
    {
        List<UiButtonText> UiButtonTexts = _settingsUiButtonText.Find((x) => x.IdTag == idTag).UiButtonTexts;

        Debug.Log($"GetIcon, idTag:{idTag}, FindUiButtonTexts = null?{UiButtonTexts == null}");

        return CheckDevice(UiButtonTexts);
    }

    private string CheckDevice(List<UiButtonText> UiButtonTexts)
    {
        DeviceType DeviceType = _importerMenuInputControlDevice.CurrentDevice;
        UiButtonText UiButtonText = UiButtonTexts.Find((x) => x.DeviceType == DeviceType);
        Debug.Log($"CheckDevice, FindUiButtonTexts = null?{UiButtonText == null}");
        Debug.Log($"CheckDevice, Text:{UiButtonText.Text}");
        return UiButtonText.Text;
    }

}

//[Serializable]
//public class TagTypeDeviceSettings
//{
//    public int IdTag;
//    public string Tag;

//    public List<UiButtonText> UiButtonTexts;
//}

//[Serializable]
//public class UiButtonText
//{
//    public DeviceType DeviceType;
//    public string Text;
//}
//< sprite name = "Interact_Sony" >