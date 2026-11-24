using GameAnalyticsSDK;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControlGameAnalytics : IInitializable
{
    private Dictionary<string, object> _parameters;
    private DataAnalyticsEvent _dataAnalyticsEvent;

    public ControlGameAnalytics(DataAnalyticsEvent dataAnalyticsEvent)
    {
        _dataAnalyticsEvent = dataAnalyticsEvent;
    }

    public void Initialize()
    {
        GameAnalytics.Initialize();
        SendCompliteEvent(1);
    }

    public void VCREvent(int idCassette)
    {
        if (GetAnalyticsEvent(3, out AnalyticsEventSettings analyticsEventSettings))
        {
            GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "VCR", 1, "IdCassette", idCassette.ToString());
        }
    }

    public void ExitEvent()
    {
        if (GetAnalyticsEvent(3, out AnalyticsEventSettings analyticsEventSettings))
        {
            int time = Convert.ToInt32(Time.time);
            FunnelFinished(analyticsEventSettings, time, true);
        }
    }

    public void SendPhoneEvent(int IdEventHistory)
    {
        // Нужно переписать если изменятся Id событий
        if (IdEventHistory == 1)
        {
            SendCompliteEvent(17);
        }
        else if (IdEventHistory == 3)
        {
            SendCompliteEvent(18);

        }
        else if (IdEventHistory == 5)
        {
            SendCompliteEvent(19);

        }
    }

    public void SendCompliteEvent(int id)
    {
        if (GetAnalyticsEvent(id, out AnalyticsEventSettings analyticsEventSettings))
        {
            FunnelFinished(analyticsEventSettings);
        }
    }

    private bool GetAnalyticsEvent(int id, out AnalyticsEventSettings analyticsEventSettings)
    {
        analyticsEventSettings = _dataAnalyticsEvent.GetAnalyticsEvent(id);

        if (analyticsEventSettings == null)
        {
            Debug.LogError($"Not Found AnalyticsEventSettings, ID:{id}");
        }
        return analyticsEventSettings != null;
    }

    private void FunnelFinished(AnalyticsEventSettings analyticsEvent)
    {
        if (CheckSendEvent(analyticsEvent)) { return; }
        string missionFinalName = CreateNameEvent(analyticsEvent.Id, analyticsEvent.NameEvent);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, missionFinalName);
        Debug.Log("funnel event: " + missionFinalName);
        PlayerPrefs.SetInt(analyticsEvent.NameEvent, 1);
    }

    private void FunnelFinished(AnalyticsEventSettings analyticsEvent, int value, bool IsCheckOneSend)
    {
        if (IsCheckOneSend)
        {
            if (CheckSendEvent(analyticsEvent)) { return; }
        }
        string missionFinalName = CreateNameEvent(analyticsEvent.Id, analyticsEvent.NameEvent);
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, missionFinalName, value);
        Debug.Log("funnel event: " + missionFinalName);
        PlayerPrefs.SetInt(analyticsEvent.NameEvent, 1);
    }

    private bool CheckSendEvent(AnalyticsEventSettings analyticsEvent)
    {
        return PlayerPrefs.HasKey(analyticsEvent.NameEvent);
    }

    private string CreateNameEvent(int idEvent, string name)
    {
        string newName = $"{idEvent}_{name}";
        return newName;
    }
}