using UnityEngine;
using SolarEngine;
using System;
using System.Collections.Generic;
//using CAS;
using DG.Tweening;

public class SE_Init : MonoBehaviour
{
    public static SE_Init Instant;
    // Start is called before the first frame update
    void Awake()
    {
        DOVirtual.DelayedCall(0.2f, () => { this.gameObject.gameObject.GetComponent<SE_Init>().enabled = true; });

        Instant = this;
        InitSDK();
        DontDestroyOnLoad(this);
    }

    public void InitSDK()
    {
        
        Debug.LogError("Device ID " + SolarEngine.Analytics.getDistinctId());
        SolarEngine.Analytics.getDistinctId();
        Debug.Log("[unity] init click");

        String AppKey = "704dc20528d86542";
        Debug.LogError("SolarEngine 1");
        //SolarEngine.Analytics.preInitSeSdk("Developer's applied appkey");
        SolarEngine.Analytics.preInitSeSdk(AppKey);
        Debug.LogError("SolarEngine 2");
        SEConfig seConfig = new SEConfig();
        Debug.LogError("SolarEngine 3");
        RCConfig rcConfig = new RCConfig();
        Debug.LogError("SolarEngine 4");
        seConfig.logEnabled = true;
        rcConfig.enable = true;
        Debug.LogError("SolarEngine 5");

        //SolarEngine.Analytics.SEAttributionCallback callback = new SolarEngine.Analytics.SEAttributionCallback(attSuccessCallback);
        //seConfig.attributionCallback = callback;
        //Debug.LogError("SolarEngine 6");

        //SolarEngine.Analytics.SESDKInitCompletedCallback initCallback = new SolarEngine.Analytics.SESDKInitCompletedCallback(initSuccessCallback);
        seConfig.initCompletedCallback = initSuccessCallback;
        Debug.LogError("SolarEngine 7");


        SolarEngine.Analytics.preInitSeSdk(AppKey);
        SolarEngine.Analytics.initSeSdk(AppKey, seConfig, rcConfig);
        Debug.LogError("SolarEngine 8");

        // SE_Init.Instant.trackIAP(args.purchasedProduct.metadata.localizedTitle, args.purchasedProduct.definition.id, 0, (float)args.purchasedProduct.metadata.localizedPrice);
        //SE_Init.Instant.trackAdImpression("Android", "Null", AdType.Banner);
        //SE_Init.Instant.trackAdClick("Android", "Null", AdType.Interstitial);
    }


    private void Start()
    {
        Debug.LogError("SolarEngine ");
        SolarEngine.Analytics.getDistinctId();
    }

    private void attSuccessCallback(int errorCode, Dictionary<string, object> attribution)
    {

        if (errorCode != 0)
        {
            Debug.Log("SEUnity: errorCode : " + errorCode);
            ToastManager.Instance.ShowToast($"SEUnity: errorCode :  {errorCode}",ToastManager.MessageType.Error,3);

        }
        else
        {

            Debug.Log("SEUnity: attSuccessCallback : " + attribution);
            ToastManager.Instance.ShowToast($"SEUnity: attSuccessCallback : {errorCode}",ToastManager.MessageType.Simple,3);
        }
    }

    private void initSuccessCallback(int code)
    {
        Debug.Log("SEUnity:initSuccessCallback  code : " + code);
            ToastManager.Instance.ShowToast($"SEUnity:initSuccessCallback  code : {code}",ToastManager.MessageType.Simple,3);
        SolarEngine.Analytics.getDistinctId();
    }


    public void trackIAP(string ProductName, string IAPID, int ProductNumber, float Ammount)
    {
        Debug.Log("[unity] trackIAP click");

        ProductsAttributes productsAttributes = new ProductsAttributes();
        productsAttributes.product_name = ProductName;
        productsAttributes.product_id = IAPID;
        productsAttributes.product_num = ProductNumber;
        productsAttributes.currency_type = "USD";
        productsAttributes.order_id = "null";
        productsAttributes.fail_reason = "null";
        productsAttributes.paystatus = SEConstant_IAP_PayStatus.SEConstant_IAP_PayStatus_success;
        productsAttributes.pay_type = "AmazonPay";
        productsAttributes.pay_amount = Ammount;
        //productsAttributes.customProperties = getCustomProperties();
        SolarEngine.Analytics.trackIAP(productsAttributes);
    }

    //public void trackAdClick(string Platform,string MediationPlatform,AdType AdType)
    //{
    //    Debug.Log("[unity] trackAdClick click");

    //    AdClickAttributes AdClickAttributes = new AdClickAttributes();
    //    AdClickAttributes.ad_platform = Platform;
    //    AdClickAttributes.mediation_platform = MediationPlatform;
    //    AdClickAttributes.ad_id = "null";
    //    AdClickAttributes.ad_type = (int)AdType;
    //    AdClickAttributes.checkId = "null";
    //    //AdClickAttributes.customProperties = getCustomProperties();
    //    SolarEngine.Analytics.trackAdClick(AdClickAttributes);

    //}


    //public void trackAdImpression(string Platform, string MediationPlatform, AdType AdType)
    //{
    //    Debug.Log("[unity] trackAdImpression click");

    //    AppImpressionAttributes impressionAttributes = new AppImpressionAttributes();
    //    impressionAttributes.ad_platform = Platform;
    //    //impressionAttributes.ad_appid = "ad_appid";
    //    impressionAttributes.mediation_platform = MediationPlatform;
    //    impressionAttributes.ad_id = "null";
    //    impressionAttributes.ad_type = (int)AdType;
    //    impressionAttributes.ad_ecpm = 0;
    //    impressionAttributes.currency_type = "USD";
    //    impressionAttributes.is_rendered = true;
    //    //impressionAttributes.customProperties = getCustomProperties();
    //    SolarEngine.Analytics.trackIAI(impressionAttributes);

    //}
}
