using System.Collections.Generic;
using UnityEngine;

public class CheckerTextIconTags
{

    private DataTagTypeDevice _dataTagTypeDevice;
    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;

    public CheckerTextIconTags(DataTagTypeDevice dataTagTypeDevice, ImporterMenuInputControlDevice importerMenuInputControlDevice)
    {
        _dataTagTypeDevice = dataTagTypeDevice;
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
    }


    public string CheckTag(string text)
    {
        //string tempText = text;
        int tempIdTag = 1;
        TagTypeDeviceSettings tagTypeDeviceSettings;
        int Count = _dataTagTypeDevice.GetCount();
        for (int i = 0; i < Count; i++)
        {
            tagTypeDeviceSettings = _dataTagTypeDevice.GetTagTypeDeviceSettings(tempIdTag);
            tempIdTag++;
            if (text.Contains(tagTypeDeviceSettings.KeyTag))
            {
                Debug.Log($"CheckTag, Text:{tagTypeDeviceSettings.KeyTag}");
                text = FindIcon(tagTypeDeviceSettings, text);
                Debug.Log($"CheckTag, FullText :{text}");
            }
        }
        return text;
    }



    private string FindIcon(TagTypeDeviceSettings TagTypeDeviceSettings, string text)
    {
        return text.Replace(TagTypeDeviceSettings.KeyTag, GetIcon(TagTypeDeviceSettings));
    }

    private string GetIcon(TagTypeDeviceSettings TagTypeDeviceSettings)
    {
        List<UiButtonText> UiButtonTexts = TagTypeDeviceSettings.UiButtonTexts;
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
