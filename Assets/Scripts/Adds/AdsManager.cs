using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : PersistentSingleton<AdsManager>, IUnityAdsListener
{
    [SerializeField] private string _gameID = "5479349";
    [SerializeField] private string _rewardedUnityID = "Rewarded_Android";

    void Start()
    {
        EventManager.SubscribeToEvent(EventType.LevelStarted, OnLevelStarted);
        EventManager.SubscribeToEvent(EventType.LevelEnded, OnLevelEnded);
        EventManager.SubscribeToEvent(EventType.TutorialCompleted, OnTutorialCompleted);

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameID);
    }

    private void OnDestroy()
    {
        EventManager.UnsubscribeToEvent(EventType.LevelStarted, OnLevelStarted);
        EventManager.UnsubscribeToEvent(EventType.LevelEnded, OnLevelEnded);
        EventManager.UnsubscribeToEvent(EventType.TutorialCompleted, OnTutorialCompleted);
    }

    private void OnTutorialCompleted(object[] parameters)
    {
        ShowAdvertisement();
    }

    private void OnLevelEnded(object[] parameters)
    {
        ShowAdvertisement();
    }

    private void OnLevelStarted(object[] parameters)
    {
        ShowAdvertisement();
    }

    public void ShowAdvertisement()
    {
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(_rewardedUnityID);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("It´s ready to show!");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("El anuncio esta comenzando");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error in Unity ads");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == _rewardedUnityID)
        {
            if (showResult == ShowResult.Finished) Debug.Log("Full rewards");
            else if (showResult == ShowResult.Skipped) Debug.Log("Half rewards");
            else if (showResult == ShowResult.Failed) Debug.Log("No rewards");
        }
    }
}
