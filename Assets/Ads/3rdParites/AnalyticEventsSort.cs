using System.Collections.Generic;
using UnityEngine;
//using Facebook.Unity;
//using Firebase.Analytics;
using System;
using System.Collections;
using System.Globalization;
using System.Threading.Tasks;
//using AppsFlyerSDK;
//using Facebook.MiniJSON;
//using Firebase;
//using UnityEngine.Purchasing;
using UnityEngine.Analytics;

namespace Analytics
{
    [System.Serializable]
    public struct Receipt
    {
        public string Store;
        public string TransactionID;
        public string Payload;
    }

    [System.Serializable]
    public struct PayloadAndroid
    {
        public string Json;
        public string Signature;
    }

    public class AnalyticEventsSort : MonoBehaviour
    {
        private static AnalyticEventsSort _instance;
        public static AnalyticEventsSort Instance => _instance;
        private bool _isFirebaseInitialized;
        [SerializeField] private bool isDubg;

        #region Initialization

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }

            // if (Preferences.Instance.Launch_date == "")
            // {
            //     try
            //     {
            //         Preferences.Instance.Launch_date = DateTime.Now.ToString();
            //         Debug.Log("Fist Launch datetime " + Preferences.Instance.Launch_date);
            //     }
            //     catch (System.Exception e)
            //     {
            //         Debug.Log("Exception occur at MemoryManager line 48" + e.Message);
            //     }
            // }

            //FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(CalledAfterSomeTime);
        }

        //private void CalledAfterSomeTime(Task<DependencyStatus> task)
        //{
        //    var dependencyStatus = task.Result;
        //    if (dependencyStatus == Firebase.DependencyStatus.Available)
        //    {
        //        // Set a flag here indiciating that Firebase is ready to use by your
        //        // application.
        //        _isFirebaseInitialized = true;
        //        Debug.Log("Firebase Initialized");
        //        Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;
        //        if (isDubg) FirebaseApp.LogLevel = LogLevel.Debug;
        //    }
        //    else
        //    {
        //        UnityEngine.Debug.LogError($"Firebase Could not resolve all Firebase dependencies: {dependencyStatus}");
        //        // Firebase Unity SDK is not safe to use here.
        //    }
        //}

        //public void AppStartEvents() //call one time on game start after firebase initialization
        //{
        //    LogApp_LaunchEvent();
        //    if (PlayerPrefs.GetInt("app_install") == 0)
        //    {
        //        LogApp_InstallEvent();
        //        PlayerPrefs.SetInt("app_install", 1);
        //    }
        //}

        //private void LogApp_LaunchEvent() // each time app_open
        //{
        //    if (FB.IsInitialized) FB.LogAppEvent("app_launch");
        //    if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("app_open");
        //}

        //private void LogApp_InstallEvent() //one time
        //{
        //    if (FB.IsInitialized) FB.LogAppEvent("app_install");
        //    if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("app_install");
        //}

        #endregion

        #region LogAdsDisplay

        void LogAd_interstitial_shownEvent() //SimpleFirebaseEvent
        {
            //if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("ad_interstitial_shown");
        }

        public void LogAd_rewarded_shownEvent(string placement) //Parametrized event
        {
            //Parameter[] parameters = {new Parameter("placement", placement)};

            //if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("ad_rewarded_shown", parameters);
        }

        public void LogInterstitial_first_Event()
        {
           // if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("first_interstitial");
        }

        public void LogInterstitial_5th_Event()
        {
            //if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("fifth_interstitial");
        }

        public void LogInterstitial_10th_Event()
        {
            //if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("tenth_interstitial");
        }

        public void LogInterstitial_20thEvent()
        {
            //if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("twenty_interstitial");
        }

        public void LogRewarded_first_Event()
        {
           // if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("first_rewarded");
        }

        public void LogRewarded_5th_Event()
        {
           // if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("fifth_rewarded");
        }

        public void LogRewarded_10th_Event()
        {
            //if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("tenth_rewarded");
        }

        public void LogRewarded_20thEvent()
        {
            //if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("twenty_rewarded");
        }

        #endregion

        #region Offers

        //public void Log_VipSubscription_getEvent()
        //{
        //    if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("log_vipSubscription_getEvent");
        //}

        //public void Log_LimitedOffer_getEvent(string placement)
        //{
        //    Parameter[] parameters = {new Parameter("placement", placement)};
        //    if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent("log_limitedOffer_getEvent", parameters);
        //}

        #endregion //Offers

        #region GamePlayEvents

        //public void Log_Tutorial_Begin_getEvent() //FirebaseAnalytics.EventTutorialBegin="tutorial_begin"
        //{
        //    if (PlayerPrefs.GetInt("TutorialStarted") == 0)
        //    {
        //        if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventTutorialBegin);
        //        PlayerPrefs.SetInt("TutorialStarted", 1);
        //    }
        //}

        //public void Log_Tutorial_Completed_getEvent()
        //{
        //    if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventTutorialComplete);
        //}

        //public void Log_level_start_Event(int level)
        //{
        //    Parameter[] parameters = {new Parameter(FirebaseAnalytics.ParameterLevel, level)};
        //    if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart, parameters);
        //}

        //public void Log_level_complete_Event(int level)
        //{
        //    Parameter[] parameters = {new Parameter(FirebaseAnalytics.ParameterLevel, level)};
        //    if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd, parameters);

        //    if (level == 10 || level == 20 || level == 30 || level == 40 || level == 50)
        //    {
        //        var levelUp = "level_" + level + "_complete";
        //        if (_isFirebaseInitialized) FirebaseAnalytics.LogEvent(levelUp);
        //    }
        //}

        #endregion

        //public void LogIn_app_purchaseEvent(string product_id, string product_name, string currencySymbol, float price,
        //    bool validated, PurchaseEventArgs args)
        //{
        //    {
        //        price *= 0.85f; //removing apple/google 30% cut
        //        var parameters = new Dictionary<string, object>
        //        {
        //            ["content_ID"] = product_id, ["content"] = product_name, ["success"] = validated ? 1 : 0
        //        };
        //        FB.LogPurchase(price, currencySymbol, parameters);
        //        var value = price *
        //                    1; //Value = price*quantity. As quantity will always be 1, value should always be equal to price
        //        FirebaseAnalytics.LogEvent("in_app_purchase",
        //            new Parameter(FirebaseAnalytics.ParameterItemId, product_id),
        //            new Parameter(FirebaseAnalytics.ParameterItemName, product_name),
        //            new Parameter(FirebaseAnalytics.ParameterCurrency, currencySymbol),
        //            new Parameter(FirebaseAnalytics.ParameterPrice, price),
        //            new Parameter(FirebaseAnalytics.ParameterValue, value),
        //            new Parameter(FirebaseAnalytics.ParameterSuccess, validated.ToString()));
        //    }
        //}
    }
}

