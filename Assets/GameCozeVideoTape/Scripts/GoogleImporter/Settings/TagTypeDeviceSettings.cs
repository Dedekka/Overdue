using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class TagTypeDeviceSettings 
{
    public string KeyTag;
    public int IdTag;
    public List<UiButtonText> UiButtonTexts;
}


[Serializable]
public class UiButtonText
{
    public DeviceType DeviceType;
    public string Text;
}