using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using AOT;

using Newtonsoft.Json;

using UnityEngine;

namespace SolarEngine
{


    [Serializable]
    public enum SEConstant_IAP_PayStatus
    {
        // 成功
        SEConstant_IAP_PayStatus_success = 1,
        // 失败
        SEConstant_IAP_PayStatus_fail = 2,
        // 恢复
        SEConstant_IAP_PayStatus_restored = 3      
    };

    [Serializable]
    public enum SEConstant_Preset_EventType
    {
        // _appInstall预置事件
        SEConstant_Preset_EventType_AppInstall ,
        // _appStart
        SEConstant_Preset_EventType_AppStart  ,
        // _appEnd
        SEConstant_Preset_EventType_AppEnd   ,
        // _appInstall、_appStart、_appEnd三者
        SEConstant_Preset_EventType_All  

    };

    public interface SEBaseAttributes
    {
        // checkId
        string checkId { get; set; }
    }

    [Serializable]
    public struct CustomAttributes : SEBaseAttributes
    {
        // 自定义事件名
        public string custom_event_name { get; set; }

        // 自定义属性, json字符串
        public Dictionary<string, object> customProperties { get; set; }

        // 自定义事件预置属性
        public Dictionary<string, object> preProperties { get; set; }

        // 实现 SEBaseAttributes 接口中的 checkId 属性
        public string checkId { get; set; }
    }

    [Serializable]
    public struct ProductsAttributes : SEBaseAttributes
    {
        // 商品名称 不可为空
        public string product_name { get; set; }
        // 商品 ID 不可为空
        public string product_id { get; set; }
        // 购买商品的数量 不可为空
        public int product_num { get; set; }
        // 支付的货币各类，遵循《ISO 4217国际标准》，如 CNY、USD... 不可为空
        public string currency_type { get; set; }
        // 本次购买由系统生成的订单 ID 不可为空
        public string order_id { get; set; }
        // 支付失败的原因 可以为空
        public string fail_reason { get; set; }
        // 支付状态 详见 SEConstant_IAP_PayStatus 枚举
        public SEConstant_IAP_PayStatus paystatus { get; set; }
        // 支付方式：如 alipay、weixin、applepay、paypal 等
        public string pay_type { get; set; }
        // 本次购买支付的金额
        public double pay_amount { get; set; }
        // 自定义属性, json字符串
        public Dictionary<string, object> customProperties { get; set; }
        // 实现 SEBaseAttributes 接口中的 checkId 属性
        public string checkId { get; set; }
    }

    [Serializable]
    public struct AppImpressionAttributes : SEBaseAttributes
    {
        // 变现平台名称 不可为空:
        // csj：穿山甲国内版、pangle：穿山甲国际版、tencent：腾讯优量汇、baidu：百度百青藤、kuaishou：快手、oppo：OPPO、vivo：vivo
        // mi：小米、huawei：华为、applovin：Applovin、sigmob：Sigmob、mintegral：Mintegral、oneway：OneWay、vungle：Vungle
        // facebook：Facebook、admob：AdMob、unity：UnityAds、is：IronSource、adtiming：AdTiming、klein：游可赢
        public string ad_platform { get; set; }
        //填充广告的聚合平台，变现广告由聚合平台填充时必填，其他情况默认填custom即可，不可为空
        public string mediation_platform { get; set; }
        // 变现平台的应用 ID 不可为空
        public string ad_appid { get; set; }
        // 变现平台的变现广告位 ID 可为空
        public string ad_id { get; set; }
        // 展示广告的类型 不可为空 
        // 激励视频:1, 开屏:2, 插屏:3, 全屏:4, Banner:5, 信息流:6, 短视频信息流:7, 大横幅:8, 视频贴片:9, 其它:0
        public int ad_type { get; set; }
        // 广告ECPM（广告千次展现的变现收入，0或负值表示没传）不可为空
        public double ad_ecpm { get; set; }
        // 展示收益的货币种类，遵循《ISO 4217国际标准》，如 CNY、USD... 不可为空
        public string currency_type { get; set; }
        // 广告是否渲染成功 不可为空 ,bool类型，true为渲染成功，false为渲染失败
        public bool is_rendered { get; set; }
        // 自定义属性, json字符串
        public Dictionary<string, object> customProperties { get; set; }
        // 实现 SEBaseAttributes 接口中的 checkId 属性
        public string checkId { get; set; }
    }

    [Serializable]
    public struct AdClickAttributes : SEBaseAttributes
    {
        // 变现平台名称 不可为空:
        // csj：穿山甲国内版、pangle：穿山甲国际版、tencent：腾讯优量汇、baidu：百度百青藤、kuaishou：快手、oppo：OPPO、vivo：vivo
        // mi：小米、huawei：华为、applovin：Applovin、sigmob：Sigmob、mintegral：Mintegral、oneway：OneWay、vungle：Vungle
        // facebook：Facebook、admob：AdMob、unity：UnityAds、is：IronSource、adtiming：AdTiming、klein：游可赢
        public string ad_platform { get; set; }

        // 展示广告的类型 不可为空 
        // 1:激励视频、2：开屏、3：插屏、4：全屏、5：Banner、6、信息流、7、短视频信息流、8、大横幅、9、视频贴片、0：其它
        public int ad_type { get; set; }

        // 变现平台的变现广告位 ID 可为空
        public string ad_id { get; set; }

        //填充广告的聚合平台，变现广告由聚合平台填充时必填，其他情况默认填custom即可，不可为空
        public string mediation_platform { get; set; }
        // 自定义属性, json字符串
        public Dictionary<string, object> customProperties { get; set; }
        // 实现 SEBaseAttributes 接口中的 checkId 属性
        public string checkId { get; set; }

    }

    [Serializable]
    public struct RegisterAttributes : SEBaseAttributes
    {
        // 注册类型，如：QQ、WeiXin
        public string register_type { get; set; }
        // 注册状态
        public string register_status { get; set; }
        // 自定义属性, json字符串
        public Dictionary<string, object> customProperties { get; set; }

        // 实现 SEBaseAttributes 接口中的 checkId 属性
        public string checkId { get; set; }
        
    }

    [Serializable]
    public struct LoginAttributes : SEBaseAttributes
    {
        // 登录类型
        public string login_type { get; set; }
        // 登录状态
        public string login_status { get; set; }
        // 自定义属性, json字符串
        public Dictionary<string, object> customProperties { get; set; }

        // 实现 SEBaseAttributes 接口中的 checkId 属性
        public string checkId { get; set; }
    }

    [Serializable]
    public struct OrderAttributes : SEBaseAttributes
    {
        // 订单 ID 不超过 128  字符
        public string order_id { get; set; }
        // 订单金额，单位：元
        public double pay_amount { get; set; }
        // 货币类型。遵循《ISO 4217国际标准》，如 CNY、USD
        public string currency_type { get; set; }
        // 支付类型
        public string pay_type { get; set; }
        // 订单状态
        public string status { get; set; }
        // 自定义属性, json字符串
        public Dictionary<string, object> customProperties { get; set; }

        // 实现 SEBaseAttributes 接口中的 checkId 属性
        public string checkId { get; set; }
    }


    [Serializable]
    public struct AppAttributes : SEBaseAttributes
    {
        // 投放广告的渠道 ID，需要与发行平台匹配
        public string ad_network { get; set; }
        // 投放广告的子渠道
        public string sub_channel { get; set; }
        // 投放广告的投放账号 ID
        public string ad_account_id { get; set; }
        // 投放广告的投放账号名称
        public string ad_account_name { get; set; }
        // 投放广告的广告计划 ID
        public string ad_campaign_id { get; set; }
        // 投放广告的广告计划名称
        public string ad_campaign_name { get; set; }
        // 投放广告的广告单元 ID
        public string ad_offer_id { get; set; }
        // 投放广告的广告单元名称
        public string ad_offer_name { get; set; }
        // 投放广告的广告创意 ID
        public string ad_creative_id { get; set; }
        // 投放广告的广告创意名称
        public string ad_creative_name { get; set; }
        // 监测平台	
        public string attribution_platform { get; set; }
        

        // 自定义属性, json字符串
        public Dictionary<string, object> customProperties { get; set; }

        // 实现 SEBaseAttributes 接口中的 checkId 属性
        public string checkId { get; set; }

    }

    [Serializable]
    public enum SERCMergeType
    {
        // 默认策略，读取缓存配置+默认配置跟服务端配置合并
        SERCMergeTypeDefault = 0,

        // App版本更新时，使用默认配置+服务端合并（丢弃缓存配置）
        SERCMergeTypeUser = 1,
    }

    [Serializable]
    public struct  RCConfig
    {
        // 线参数SDK启用开关，默认为关闭状态，必传字段
        public bool enable { get; set; }

        // SDK配置合并策略，默认情况下服务端配置跟本地缓存配置合并
        // ENUM：SERCMergeTypeUser 在App版本更新时会清除缓存配置
        // 可选字段
        public SERCMergeType mergeType { get; set; }

        // 自定义ID, 用来匹配用户在后台设置规则时设置的自定义ID，可选字段
        public Dictionary<string, object> customIDProperties { get; set; }

        // 自定义ID 事件属性，可选字段
        public Dictionary<string, object> customIDEventProperties { get; set; }

        // 自定义ID 用户属性，可选字段
        public Dictionary<string, object> customIDUserProperties { get; set; }

        // 自定义ID 设备属性，可选字段
        // public Dictionary<string, object> customIDDeviceProperties { get; set; }
    }

    [Serializable]
    public struct SEConfig
    {
        // 开启 Debug 模式，默认为关闭状态，可选字段, Debug模式请勿发布到线上！！！
        public bool isDebugModel { get; set; }

        // 是否开启 本地调试日志（不设置时默认不开启 本地日志）
        public bool logEnabled { get; set; }

        // 是否为GDPR区域。默认为false，可选字段
        public bool isGDPRArea { get; set; }
        // 用户是否允许Google将其数据用于个性化广告，不设置则不上报该字段，可选字段，只有Android调用有效，iOS没有此字段，无需设置此字段
        public bool adPersonalizationEnabled { get; set; }
        // 用户是否同意将其数据发送到Google。不设置则不上报该字段，可选字段，只有Android调用有效，iOS没有此字段，无需设置此字段
        public bool adUserDataEnabled { get; set; }

        // 是否允许2G上报数据。默认为false，可选字段
        public bool isEnable2GReporting { get; set; }

        // 是否支持coppa合规。默认为false，可选字段
        public bool isCoppaEnabled { get; set; }

        // 是否支持Kids App应用。默认为false，可选字段
        public bool isKidsAppEnabled { get; set; }

        // 是否开启延迟deeplink。默认为false，可选字段
        public bool delayDeeplinkEnable { get; set; }

        // iOS ATT 授权等待时间，默认不等待，可选字段；只有iOS调用有效。
        public int attAuthorizationWaitingInterval { get; set; }
		
		//Android meta应用ID
		public string fbAppID{ get; set; }

        // 设置获取归因结果回调，可选字段
        public Analytics.SEAttributionCallback attributionCallback { get; set; }

        // 设置初始化完成回调, 可选
        public Analytics.SESDKInitCompletedCallback initCompletedCallback { get; set; }


    }

    [Serializable]
    public enum SEUserDeleteType
    {
        // 通过AccountId删除用户
        SEUserDeleteTypeByAccountId = 0,

        // 通过VisitorId删除用户
        SEUserDeleteTypeByVisitorId = 1,
    }


    public partial class Analytics : MonoBehaviour
    {

        private static readonly string sdk_version = "1.2.9.2";


        private SEAttributionCallback attributionCallback_private = null;
        public delegate void SEAttributionCallback(int code, Dictionary<string, object> attribution);


        private SESDKInitCompletedCallback initCompletedCallback_private = null;
        public delegate void SESDKInitCompletedCallback(int code);

        private SESDKDeeplinkCallback deeplinkCallback_private = null;
        public delegate void SESDKDeeplinkCallback(int code, Dictionary<string, object> data);

        // 延迟deeplink
        private SESDKDelayDeeplinkCallback delayDeeplinkCallback_private = null;
        public delegate void SESDKDelayDeeplinkCallback(int code, Dictionary<string, object> data);

        private SESDKATTCompletedCallback attCompletedCallback_private = null;
        public delegate void SESDKATTCompletedCallback(int code);

        // only ios
        public delegate void SKANUpdateCompletionHandler(int errorCode, String errorMsg);

        private SKANUpdateCompletionHandler iosSKANUpdateCVCompletionHandler_private = null;
        private SKANUpdateCompletionHandler iosSKANUpdateCVCoarseValueCompletionHandler_private = null;
        private SKANUpdateCompletionHandler iosSKANUpdateCVCoarseValueLockWindowCompletionHandler_private = null;


        public delegate void SEiOSStringCallback(int code, string dataString);


        private static List<Action> waitingTaskList = new List<Action>();
        private static List<Action> executingTaskList = new List<Action>();

        private static Analytics _instance = null;

        public static Analytics Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = FindObjectOfType(typeof(Analytics)) as Analytics;
                    if (!_instance)
                    {
                        GameObject am = new GameObject("Analytics");
                        _instance = am.AddComponent(typeof(Analytics)) as Analytics;
                    }
                }
                return _instance;
            }
        }

        public static void PostTask(Action task)
        {
            lock (waitingTaskList)
            {
                waitingTaskList.Add(task);
            }
        }

        private void Update()
        {
            lock (waitingTaskList)
            {
                if (waitingTaskList.Count > 0)
                {
                    executingTaskList.AddRange(waitingTaskList);

                    waitingTaskList.Clear();
                }
            }

            for (int i = 0; i < executingTaskList.Count; ++i)
            {
                Action task = executingTaskList[i];
                try
                {
                    task();
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message, this);
                }
            }

            executingTaskList.Clear();
        }

        private static readonly string SEConstant_CHECK_ID = "_first_event_check_id";
        private static readonly string SEConstant_EVENT_TYPE = "_event_type";


        private static readonly string SEConstant_CUSTOM_EVENT_NAME = "_custom_event_name";
        private static readonly string SEConstant_Pre_Properties = "_pre_properties";
        private static readonly string SEConstant_CUSTOM = "_custom_event";
        private static readonly string SEConstant_Custom_CustomProperties = "_customProperties";

        private static readonly string SEConstant_IAP = "_appPur";
        private static readonly string SEConstant_IAP_PName = "_product_name";
        private static readonly string SEConstant_IAP_PID = "_product_id";
        private static readonly string SEConstant_IAP_PCount = "_product_num";
        private static readonly string SEConstant_IAP_Currency = "_currency_type";
        private static readonly string SEConstant_IAP_OrderId = "_order_id";
        private static readonly string SEConstant_IAP_FailReason = "_fail_reason";
        private static readonly string SEConstant_IAP_PayType = "_pay_type";
        private static readonly string SEConstant_IAP_Amount = "_pay_amount";
        private static readonly string SEConstant_IAP_Paystatus = "_pay_status";
        private static readonly string SEConstant_IAP_CustomProperties = "_customProperties";

        private static readonly string SEConstant_IAI = "_appImp";
        private static readonly string SEConstant_IAI_AdPlatform = "_ad_platform";
        private static readonly string SEConstant_IAI_MediationPlatform = "_mediation_platform";
        private static readonly string SEConstant_IAI_AdAppid = "_ad_appid";
        private static readonly string SEConstant_IAI_AdId = "_ad_id";
        private static readonly string SEConstant_IAI_AdType = "_ad_type";
        private static readonly string SEConstant_IAI_AdEcpm = "_ad_ecpm";
        private static readonly string SEConstant_IAI_CurrencyType = "_currency_type";
        private static readonly string SEConstant_IAI_IsRendered = "_is_rendered";
        private static readonly string SEConstant_IAI_CustomProperties = "_customProperties";

        private static readonly string SEConstant_AdClick = "_appClick";
        private static readonly string SEConstant_AdClick_AdPlatform = "_ad_platform";
        private static readonly string SEConstant_AdClick_MediationPlatform = "_mediation_platform";
        private static readonly string SEConstant_AdClick_AdId = "_ad_id";
        private static readonly string SEConstant_AdClick_AdType = "_ad_type";
        private static readonly string SEConstant_AdClick_CustomProperties = "_customProperties";

        private static readonly string SEConstant_Register = "_appReg";
        private static readonly string SEConstant_Register_Type = "_reg_type";
        private static readonly string SEConstant_Register_Status = "_status";
        private static readonly string SEConstant_Register_CustomProperties = "_customProperties";

        private static readonly string SEConstant_Login = "_appLogin";
        private static readonly string SEConstant_Login_Type = "_login_type";
        private static readonly string SEConstant_Login_Status = "_status";
        private static readonly string SEConstant_Login_CustomProperties = "_customProperties";

        private static readonly string SEConstant_Order = "_appOrder";
        private static readonly string SEConstant_Order_ID = "_order_id";
        private static readonly string SEConstant_Order_Pay_Amount = "_pay_amount";
        private static readonly string SEConstant_Order_Currency_Type = "_currency_type";
        private static readonly string SEConstant_Order_Pay_Type = "_pay_type";
        private static readonly string SEConstant_Order_Status = "_status";
        private static readonly string SEConstant_Order_CustomProperties = "_customProperties";


        private static readonly string SEConstant_AppAttr = "_appAttr";
        private static readonly string SEConstant_AppAttr_Ad_Network = "_adnetwork";
        private static readonly string SEConstant_AppAttr_Sub_Channel = "_sub_channel";
        private static readonly string SEConstant_AppAttr_Ad_Account_ID = "_adaccount_id";
        private static readonly string SEConstant_AppAttr_Ad_Account_Name = "_adaccount_name";
        private static readonly string SEConstant_AppAttr_Ad_Campaign_ID = "_adcampaign_id";
        private static readonly string SEConstant_AppAttr_Ad_Campaign_Name = "_adcampaign_name";
        private static readonly string SEConstant_AppAttr_Ad_Offer_ID = "_adoffer_id";
        private static readonly string SEConstant_AppAttr_Ad_Offer_Name = "_adoffer_name";
        private static readonly string SEConstant_AppAttr_Ad_Creative_ID = "_adcreative_id";
        private static readonly string SEConstant_AppAttr_Ad_Creative_Name = "_adcreative_name";
        private static readonly string SEConstant_AppAttr_AttributionPlatform = "_attribution_platform";

        private static readonly string SEConstant_AppAttr_Ad_CustomProperties = "_customProperties";


#if UNITY_ANDROID

        protected static AndroidJavaClass SolarEngineAndroidSDK = new AndroidJavaClass("com.reyun.solar.engine.unity.bridge.UnityAndroidSeSDKManager");
        protected static AndroidJavaObject SolarEngineAndroidSDKObject = new AndroidJavaObject("com.reyun.solar.engine.unity.bridge.UnityAndroidSeSDKManager");

        protected static AndroidJavaObject Context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");

#endif


        /// <summary>
        /// 预初始化 SDK。
        /// </summary>
        /// <param name="appKey">应用 appKey，请联系商务人员获取。</param>
        public static void preInitSeSdk(string appKey)
        {
            PreInitSeSdk(appKey);
        }


        /// <summary>
        /// 用于应用启动后，初始化 SDK。
        /// </summary>
        /// <param name="appKey">应用 appKey，请联系商务人员获取。</param>
        /// <param name="userID">用户 ID ，请联系商务人员获取。</param>
        /// <param name="SEConfig">见SEConfig 说明</param>
        public static void initSeSdk(string appKey, string userID, SEConfig config)
        {
            Init(appKey, userID, config);
        }

        /// <summary>
        /// 用于应用启动后，初始化 SDK。
        /// </summary>
        /// <param name="appKey">应用 appKey，请联系商务人员获取。</param>
        /// <param name="SEConfig">见SEConfig 说明</param>
        public static void initSeSdk(string appKey, SEConfig config)
        {
            Init(appKey, null, config);
        }

        /// <summary>
        /// 用于应用启动后，初始化 SDK。
        /// </summary>
        /// <param name="appKey">应用 appKey，请联系商务人员获取。</param>
        /// <param name="userID">用户 ID ，请联系商务人员获取。</param>
        /// <param name="SEConfig">见SEConfig 说明</param>
        public static void initSeSdk(string appKey, string userID, SEConfig config, RCConfig rcConfig)
        {
            Init(appKey, userID, config, rcConfig);
        }

        /// <summary>
        /// 用于应用启动后，初始化 SDK。
        /// </summary>
        /// <param name="appKey">应用 appKey，请联系商务人员获取。</param>
        /// <param name="SEConfig">见SEConfig 说明</param>
        public static void initSeSdk(string appKey, SEConfig config, RCConfig rcConfig)
        {
            Init(appKey, null, config, rcConfig);
        }

        public static Dictionary<string, object> getAttribution() {

            string attributionString = GetAttribution();

            if (attributionString == null) {
                return null;
            }

            Dictionary<string, object> attribution = null;

            try {
                attribution = JsonConvert.DeserializeObject<Dictionary<string, object>>(attributionString);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            return attribution;

        }

        /// <summary>
        /// 设置访客 ID
        /// </summary>
        /// <param name="visitorId">访客 ID</param>
        public static void setVisitorId(string visitorId)
        {

            SetVisitorID(visitorId);
        }

        /// <summary>
        /// 获取访客 ID
        /// </summary>
        /// <returns></returns>
        public static string getVisitorId()
        {
            return GetVisitorID();
        }

        /// <summary>
        /// 设置账户 ID
        /// </summary>
        /// <param name="accountId">账户 ID</param>
        public static void login(string accountId)
        {
            Login(accountId);
        }

        /// <summary>
        /// 获取账户 ID
        /// </summary>
        /// <returns>账户 ID</returns>
        public static string getAccountId()
        {
            return GetAccountId();
        }

        /// <summary>
        /// 清除账号 ID
        /// </summary>
        public static void logout()
        {
            Logout();
        }

        /// <summary>
        /// 设置谷歌Gaid
        /// </summary>
        /// <param name="gaid">谷歌 gaid，此方法只支持Android系统，IOS不支持</param>
        public static void setGaid(string gaid)
        {
            SetGaid(gaid);
        }

        /// <summary>
        /// 设置渠道名
        /// </summary>
        /// <param name="channel">渠道名，此方法只支持Android系统，IOS不支持</param>
        public static void setChannel(string channel)
        {
            SetChannel(channel);
        }

        /// <summary>
        /// 设置GDPR地区
        /// </summary>
        /// <param name="isGDPRArea">是否属于GDPR地区</param>
        public static void setGDPRArea(bool isGDPRArea)
        {
            SetGDPRArea(isGDPRArea);
        }

        /// <summary>
        /// 获取distinct_id
        /// </summary>
        /// <returns>distinct_id</returns>
        public static string getDistinctId()
        {
            return GetDistinctId();
        }

        /// <summary>
        /// 设置公共事件属性
        /// </summary>
        /// <param name="properties">公共事件属性</param>
        public static void setSuperProperties(Dictionary<string, object> properties)
        {
            SetSuperProperties(properties);
        }

        /// <summary>
        /// 清除某个 key 对应公共事件属性
        /// </summary>
        /// <param name="key">键</param>
        public static void unsetSuperProperty(string key)
        {
            UnsetSuperProperty(key);
        }

        /// <summary>
        /// 清除公共事件属性
        /// </summary>
        public static void clearSuperProperties()
        {
            ClearSuperProperties();
        }

        /// <summary>
        /// 上报首次事件
        /// </summary>
        /// <param name="attributes">SEBaseAttributes 实例</param>
        public static void trackFirstEvent(SEBaseAttributes attributes)
        {
            TrackFirstEvent(attributes);
        }

        /// <summary>
        /// 上报应用内购买事件
        /// </summary>
        /// <param name="attributes">ProductsAttributes 实例</param>
        public static void trackIAP(ProductsAttributes attributes)
        {
            ReportIAPEvent(attributes);
        }

        /// <summary>
        /// 上报变现广告展示事件
        /// </summary>
        /// <param name="attributes">AppImpressionAttributes 实例</param>
        public static void trackIAI(AppImpressionAttributes attributes)
        {
            ReportIAIEvent(attributes);
        }

        /// <summary>
        /// 上报变现广告点击事件
        /// </summary>
        /// <param name="attributes">AdClickAttributes 实例</param>
        public static void trackAdClick(AdClickAttributes attributes)
        {
            ReportAdClickEvent(attributes);
        }

        /// <summary>
        /// 上报注册事件
        /// </summary>
        /// <param name="attributes">RegisterAttributes 实例</param>
        public static void trackRegister(RegisterAttributes attributes)
        {
            ReportRegisterEvent(attributes);
        }

        /// <summary>
        /// 上报登录事件
        /// </summary>
        /// <param name="attributes">LoginAttributes 实例</param>
        public static void trackLogin(LoginAttributes attributes)
        {
            ReportLoginEvent(attributes);
        }

        /// <summary>
        /// 上报订单事件
        /// </summary>
        /// <param name="attributes">OrderAttributes 实例</param>
        public static void trackOrder(OrderAttributes attributes)
        {
            ReportOrderEvent(attributes);
        }

        /// <summary>
        /// 上报自定义归因安装事件
        /// </summary>
        /// <param name="attributes">AppAttributes 实例</param>
        public static void trackAppAttr(AppAttributes attributes)
        {
            AppAttrEvent(attributes);
        }

        /// <summary>
        /// 上报自定义事件
        /// </summary>
        /// <param name="customEventName">自定义事件名称</param>
        /// <param name="customAttributes">自定义事件属性</param>
        public static void trackCustom(string customEventName, Dictionary<string, object> customAttributes)
        {
            ReportCustomEvent(customEventName, customAttributes);
        }


        /// <summary>
        /// 上报自定义事件
        /// </summary>
        /// <param name="customEventName">自定义事件名称</param>
        /// <param name="customAttributes">自定义事件属性</param>
        /// <param name="preAttributes">SDK预置属性</param>
        public static void trackCustom(string customEventName, Dictionary<string, object> customAttributes, Dictionary<string, object> preAttributes)
        {
            ReportCustomEventWithPreAttributes(customEventName, customAttributes, preAttributes);
        }


        /// <summary>
        /// 创建时长事件
        /// </summary>
        /// <param name="timerEventName">时长事件名称</param>
        /// <param name="attributes">时长事件属性</param>
        /// <returns>JSON 字符串，上报时需要传给 trackTimerEvent 方法。</returns>
        public static string createTimerEvent(string timerEventName, Dictionary<string, object> attributes)
        {
            return CreateTimerEvent(timerEventName, attributes);
        }

        /// <summary>
        /// 上报时长事件
        /// </summary>
        /// <param name="timeEventData">createTimerEvent方法返回的 JSON 字符串</param>
        public static void trackTimerEvent(string timeEventData)
        {
            TrackTimerEvent(timeEventData);
        }
		
		/// <summary>
		/// 创建时长事件
		/// </summary>
		/// <param name="timerEventName">时长事件名称</param>
		public static void eventStart(string timerEventName){
			EventStart(timerEventName);
		}
		
		/// <summary>
		/// 上报时长事件
		/// </summary>
		/// <param name="timerEventName">时长事件名称</param>
		/// <param name="attributes">时长事件自定义属性</param>
		public static void eventFinish(string timerEventName, Dictionary<string, object> attributes){
			EventFinish(timerEventName,attributes);
		}

        /// <summary>
        /// 设置预置事件属性
        /// </summary>
        /// <param name="setPresetEvent">事件类型</param>
        /// <param name="properties">事件属性</param>
        public static void setPresetEvent(SEConstant_Preset_EventType eventType, Dictionary<string, object> properties)
        {
            SetPresetEvent(eventType, properties);
        }

        /// <summary>
        /// 用户属性初始化设置。使用本方法上传的属性如果已经存在时不修改原有属性值，如果不存在则会新建。
        /// </summary>
        /// <param name="userProperties">用户属性</param>
        public static void userInit(Dictionary<string, object> userProperties)
        {
            UserInit(userProperties);
        }

        /// <summary>
        /// 用户属性更新设置。使用本方法上传的属性如果已经存在时将会覆盖原有的属性值，如果不存在则会新建
        /// </summary>
        /// <param name="userProperties">用户属性<</param>
        public static void userUpdate(Dictionary<string, object> userProperties)
        {
            UserUpdate(userProperties);
        }

        /// <summary>
        /// 用户属性累加操作
        /// </summary>
        /// <param name="userProperties">自定义属性（仅对数值类型的 key 进行累加操作）</param>
        public static void userAdd(Dictionary<string, object> userProperties)
        {
            UserAdd(userProperties);
        }

        /// <summary>
        /// 追加用户属性
        /// </summary>
        /// <param name="userProperties">用户属性</param>
        public static void userAppend(Dictionary<string, object> userProperties)
        {
            UserAppend(userProperties);
        }

        /// <summary>
        /// 重置用户属性。对指定属性进行清空操作
        /// </summary>
        /// <param name="keys">自定义属性 key 数组</param>
        public static void userUnset(string[] keys)
        {
            UserUnset(keys);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public static void userDelete(SEUserDeleteType deleteType)
        {
            UserDelete(deleteType);
        }

        /// <summary>
        /// 获取设备、用户相关信息'
        /// <returns>设备、用户相关信息</returns>
        /// </summary>
        public static Dictionary<string, object> getPresetProperties()
        {
            return GetPresetProperties();
        }

        /// <summary>
        /// 立即上报事件，不再等上报策略
        /// </summary>
        public static void reportEventImmediately()
        {
            ReportEventImmediately();
        }

        /// <summary>
        /// 设置deeplink回调
        /// <param name="callback">deeplink回调</param>
        /// </summary>
        public static void deeplinkCompletionHandler(SESDKDeeplinkCallback callback)
        {

            DeeplinkCompletionHandler(callback);
        }

        /// <summary>
        /// 设置深度deeplink回调
        /// <param name="callback">delayDeeplink回调</param>
        /// </summary>
        public static void delayDeeplinkCompletionHandler(SESDKDelayDeeplinkCallback callback)
        {

            DelayDeeplinkCompletionHandler(callback);
        }

        // <summary>
        /// 设置urlScheme
        /// <param name="url">deeplink url,此方法仅支持Android系统</param>
        /// </summary>
        public static void handleDeepLinkUrl(string url){
            HandleDeepLinkUrl(url);
        }


        /// <summary>
        /// 仅支持iOS
        /// SolarEngine 封装系统requestTrackingAuthorizationWithCompletionHandler接口
        /// callback 回调用户授权状态: 0: Not Determined；1: Restricted；2: Denied；3: Authorized ；999: system error
        /// </summary>
        public static void requestTrackingAuthorizationWithCompletionHandler(SESDKATTCompletedCallback callback) {

#if UNITY_EDITOR
                Debug.Log("Unity Editor: requestTrackingAuthorizationWithCompletionHandler only ios");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                Analytics.Instance.attCompletedCallback_private = callback;
                __iOSSESDKRequestTrackingAuthorizationWithCompletionHandler(OnRequestTrackingAuthorizationCompletedCallback);

#else
            Debug.Log("Unity Editor: requestTrackingAuthorizationWithCompletionHandler only ios");
#endif
        }


        /// <summary>
        /// 仅支持iOS
        /// SolarEngine 封装系统updatePostbackConversionValue
        /// </summary>
        public static void updatePostbackConversionValue(int conversionValue, SKANUpdateCompletionHandler callback) {

#if UNITY_EDITOR
                Debug.Log("Unity Editor: updatePostbackConversionValue only ios");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                Analytics.Instance.iosSKANUpdateCVCompletionHandler_private = callback;
                __iOSSESDKupdatePostbackConversionValue(conversionValue, OnSKANUpdateCVCallback);

#else
            Debug.Log("Unity Editor: updatePostbackConversionValue only ios");
#endif

        }

        /// <summary>
        /// 仅支持iOS
        /// SolarEngine 封装系统updateConversionValueCoarseValue
        /// </summary>
        public static void updateConversionValueCoarseValue(int fineValue, String coarseValue, SKANUpdateCompletionHandler callback)
        {

#if UNITY_EDITOR
                        Debug.Log("Unity Editor: updateConversionValueCoarseValue only ios");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE

                Analytics.Instance.iosSKANUpdateCVCoarseValueCompletionHandler_private = callback;
                __iOSSESDKupdateConversionValueCoarseValue(fineValue, coarseValue, OnSKANUpdateCVCoarseValueCallback);
            
#else
            Debug.Log("Unity Editor: updateConversionValueCoarseValue only ios");
#endif
        }

        /// <summary>
        /// 仅支持iOS
        /// SolarEngine 封装系统updateConversionValueCoarseValueLockWindow
        /// </summary>
        public static void updateConversionValueCoarseValueLockWindow(int fineValue, String coarseValue, bool lockWindow, SKANUpdateCompletionHandler callback)
        {

#if UNITY_EDITOR
                Debug.Log("Unity Editor: updateConversionValueCoarseValueLockWindow only ios");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                 Analytics.Instance.iosSKANUpdateCVCoarseValueLockWindowCompletionHandler_private = callback;
                 __iOSSESDKupdateConversionValueCoarseValueLockWindow(fineValue, coarseValue, lockWindow, OnSKANUpdateCVCoarseValueLockWindowCallback);
            
#else
            Debug.Log("Unity Editor: updatePostbackConversionValue only ios");
#endif
        }

        #region 

        private static Dictionary<string, object> GetPresetProperties()
        {

#if UNITY_EDITOR
            Debug.Log("Unity Editor: Init error");
            return null;
#elif UNITY_ANDROID
            string presetProperties = SolarEngineAndroidSDK.CallStatic<string>("getPresetProperties");
            Debug.Log("SEUunity-presetProperties: " + presetProperties);
            if(presetProperties != null){
                try{
                    return JsonConvert.DeserializeObject<Dictionary<string, object>>(presetProperties);
                } catch (Exception e) {

                }
            }
            return null;
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
            string presetProperties =  __iOSSolarEngineSDKGetPresetProperties();
            if(presetProperties != null){
                try{
                    return JsonConvert.DeserializeObject<Dictionary<string, object>>(presetProperties);
                } catch (Exception e) {

                }
            }
            return null;
#else
            return null;
#endif
        }


        private static void PreInitSeSdk(string appKey)
        {

#if UNITY_EDITOR
            Debug.Log("Unity Editor: Init error");
#elif UNITY_ANDROID
            SolarEngineAndroidSDK.CallStatic("preInit", Context, appKey);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
            //todo
            __iOSSolarEngineSDKPreInit(appKey);
#else

#endif
        }



        private static void Init(string appKey, string userId, SEConfig config)
        {

            Dictionary<string, object> seDict = new Dictionary<string, object>();
            seDict.Add("isDebugModel", config.isDebugModel);
            seDict.Add("logEnabled", config.logEnabled);
            seDict.Add("isGDPRArea", config.isGDPRArea);
            seDict.Add("adPersonalizationEnabled", config.adPersonalizationEnabled);
            seDict.Add("adUserDataEnabled", config.adUserDataEnabled);
            seDict.Add("isEnable2GReporting", config.isEnable2GReporting);
            seDict.Add("isCoppaEnabled", config.isCoppaEnabled);
            seDict.Add("isKidsAppEnabled", config.isKidsAppEnabled);
            seDict.Add("sub_lib_version", sdk_version);
            seDict.Add("attAuthorizationWaitingInterval", config.attAuthorizationWaitingInterval);
            seDict.Add("fbAppID", config.fbAppID);
            seDict.Add("delayDeeplinkEnable", config.delayDeeplinkEnable);


            string jonString = JsonConvert.SerializeObject(seDict);


            if (config.initCompletedCallback != null) {
                Analytics.Instance.initCompletedCallback_private = config.initCompletedCallback;
            }


            if (config.attributionCallback != null)
            {
                Analytics.Instance.attributionCallback_private = config.attributionCallback;
            }

#if UNITY_EDITOR
            Debug.Log("Unity Editor: Init error");
#elif UNITY_ANDROID
            Debug.Log("SEUunity:jonString :" + jonString);
            SolarEngineAndroidSDK.CallStatic("initialize", Context, appKey, userId, jonString,
                config.attributionCallback != null ? new OnAttributionReceivedData() : null, config.initCompletedCallback != null ? new OnUnityInitCompletedCallback() : null);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
            if (config.initCompletedCallback != null) {
                __iOSSESDKSetInitCompletedCallback(OnInitCompletedCallback);
            }

            if (config.attributionCallback != null) {
                __iOSSESDKSetAttributionDataCallback(OnAttributionCallback);
            }

            __iOSSolarEngineSDKInit(appKey, userId, jonString, null);
#else

#endif
        }

        private static void Init(string appKey, string userId, SEConfig config, RCConfig rcConfig)
        {

            Dictionary<string, object> seDict = new Dictionary<string, object>();
            seDict.Add("isDebugModel", config.isDebugModel);
            seDict.Add("logEnabled", config.logEnabled);
            seDict.Add("isGDPRArea", config.isGDPRArea);
            seDict.Add("adPersonalizationEnabled", config.adPersonalizationEnabled);
            seDict.Add("adUserDataEnabled", config.adUserDataEnabled);
            seDict.Add("isEnable2GReporting", config.isEnable2GReporting);
            seDict.Add("isCoppaEnabled", config.isCoppaEnabled);
            seDict.Add("isKidsAppEnabled", config.isKidsAppEnabled);
            seDict.Add("sub_lib_version", sdk_version);
            seDict.Add("attAuthorizationWaitingInterval", config.attAuthorizationWaitingInterval);
			seDict.Add("fbAppID", config.fbAppID);
            seDict.Add("delayDeeplinkEnable", config.delayDeeplinkEnable);

            string seJonString = JsonConvert.SerializeObject(seDict);

            if (config.initCompletedCallback != null)
            {
                Analytics.Instance.initCompletedCallback_private = config.initCompletedCallback;
            }

            if (config.attributionCallback != null)
            {
                Analytics.Instance.attributionCallback_private = config.attributionCallback;
            }

            Dictionary<string, object> rcDict = new Dictionary<string, object>();
            rcDict.Add("enable", rcConfig.enable);
            rcDict.Add("mergeType", rcConfig.mergeType);

            if (rcConfig.customIDProperties != null)
            {
                rcDict.Add("customIDProperties", rcConfig.customIDProperties);
            }
            if (rcConfig.customIDEventProperties != null)
            {
                rcDict.Add("customIDEventProperties", rcConfig.customIDEventProperties);
            }
            if (rcConfig.customIDUserProperties != null)
            {
                rcDict.Add("customIDUserProperties", rcConfig.customIDUserProperties);
            }
            // if (rcConfig.customIDDeviceProperties != null)
            // {
            //     rcDict.Add("customIDDeviceProperties", rcConfig.customIDDeviceProperties);
            // }
            string rcJonString = JsonConvert.SerializeObject(rcDict);


#if UNITY_EDITOR
            Debug.Log("Unity Editor: Init error");
#elif UNITY_ANDROID
        SolarEngineAndroidSDK.CallStatic("initialize", Context, appKey, userId, seJonString, rcJonString,
                config.attributionCallback != null ? new OnAttributionReceivedData() : null, config.initCompletedCallback != null ? new OnUnityInitCompletedCallback() : null);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
            if (config.initCompletedCallback != null) {
                __iOSSESDKSetInitCompletedCallback(OnInitCompletedCallback);
            }

             if (config.attributionCallback != null) {
                __iOSSESDKSetAttributionDataCallback(OnAttributionCallback);
            }

            __iOSSolarEngineSDKInit(appKey, userId, seJonString, rcJonString);
#else

#endif

        }

        private static void SetVisitorID(string visitorId)
        {
            if (visitorId == null)
            {
                Debug.Log("visitorId must not be null");
                return;
            }

#if UNITY_EDITOR
            Debug.Log("Unity Editor: SetVisitorID");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("setVisitorID",visitorId);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKSetVisitorID(visitorId);
#else

#endif
        }

        private static string GetVisitorID()
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: GetVisitorID");
            return null;
#elif UNITY_ANDROID
                return SolarEngineAndroidSDK.CallStatic<string>("getVisitorID");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                return __iOSSolarEngineSDKVisitorID();
#else
            return null;
#endif
        }

        private static void Login(string accountId)
        {
            if (accountId == null)
            {
                Debug.Log("accountId must not be null");
                return;
            }

#if UNITY_EDITOR
            Debug.Log("Unity Editor: Login");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("login",accountId);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKLoginWithAccountID(accountId);
#else
            return;
#endif

        }

        private static string GetAccountId()
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: GetAccountId");
            return null;
#elif UNITY_ANDROID
                return SolarEngineAndroidSDK.CallStatic<string>("getAccountID");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                return __iOSSolarEngineSDKAccountID();
#else
            return null;
#endif

        }

        private static void Logout()
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: Logout");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("logout");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKLogout();
#else

#endif

        }

        private static void SetGaid(string gaid)
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: SetGaid");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("setGaid",gaid);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                Debug.Log("Only Android can set gaid , iOS not support");
#else

#endif

        }

        private static void SetChannel(string channel)
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: SetChannel");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("setChannel",channel);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                Debug.Log("Only Android can set channel , iOS not support");
#else

#endif

        }

        private static void SetGDPRArea(bool isGDPRArea)
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: SetGDPRArea");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("setGDPRArea",isGDPRArea);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKSetGDPRArea(isGDPRArea);
#else

#endif

        }

        private static string GetDistinctId()
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: GetDistinctId");
            return null;
#elif UNITY_ANDROID
                return SolarEngineAndroidSDK.CallStatic<string>("getDistinctId");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                return __iOSSolarEngineSDKGetDistinctId();
#else
            return null;
#endif

        }

        private static void SetSuperProperties(Dictionary<string, object> userProperties)
        {
            if (userProperties == null)
            {
                Debug.Log("userProperties must not be null");
                return;
            }

            string userPropertiesJSONString = JsonConvert.SerializeObject(userProperties);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: SetSuperProperties");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("setSuperProperties",Context,userPropertiesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKSetSuperProperties(userPropertiesJSONString);
#else

#endif
        }

        private static void UnsetSuperProperty(string key)
        {

            if (key == null)
            {
                Debug.Log("key must not be null");
                return;
            }

#if UNITY_EDITOR
            Debug.Log("Unity Editor: UnsetSuperProperty");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("unsetSuperProperty",Context,key);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKUnsetSuperProperty(key);
#else

#endif

        }

        private static void ClearSuperProperties()
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: ClearSuperProperties");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("clearSuperProperties",Context);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                 __iOSSolarEngineSDKClearSuperProperties();
#else

#endif

        }
		
		private static void EventStart(string timerEventName)
		        {
		            if (timerEventName == null)
		            {
		                Debug.Log("timerEventName must not be null");
		                return;
		            }
		    
		#if UNITY_EDITOR
		            Debug.Log("Unity Editor: EventStart");
		            return;
		#elif UNITY_ANDROID
		            SolarEngineAndroidSDK.CallStatic("eventStart",timerEventName);
		#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                    __iOSSolarEngineSDKEventStart(timerEventName);
		#else
		            return;
		#endif
		
		        }
				
		private static void EventFinish(string timerEventName, Dictionary<string, object> attributes)
		        {
		            if (timerEventName == null)
		            {
		                Debug.Log("timerEventName must not be null");
		                return;
		            }
		            string attributesJSONString = JsonConvert.SerializeObject(attributes);
		
		#if UNITY_EDITOR
		            Debug.Log("Unity Editor: EventFinish");
		            return;
		#elif UNITY_ANDROID
		            SolarEngineAndroidSDK.CallStatic("eventFinish",timerEventName,attributesJSONString);
		#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
		            __iOSSolarEngineSDKEventFinishNew(timerEventName,attributesJSONString);
		#else
		            return;
		#endif
		
		        }
				

        private static string CreateTimerEvent(string timerEventName, Dictionary<string, object> attributes)
        {
            if (timerEventName == null)
            {
                Debug.Log("timerEventName must not be null");
                return null;
            }
            // if (attributes == null)
            // {
            //     Debug.Log("attributes must not be null");
            //     return null;
            // }

            string attributesJSONString = JsonConvert.SerializeObject(attributes);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: CreateTimerEvent");
            return null;
#elif UNITY_ANDROID
                return SolarEngineAndroidSDK.CallStatic<string>("createTimerEvent",timerEventName,attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKEventStart(timerEventName);
                return "{ \"eventName\": \"" + timerEventName + "\", \"attributes\": " + attributesJSONString + " }";
#else
            return null;
#endif

        }

        private static void TrackTimerEvent(string timerEventData)
        {
            if (timerEventData == null)
            {
                Debug.Log("timerEventData must not be null");
                return;
            }

#if UNITY_EDITOR
            Debug.Log("Unity Editor: TrackTimerEvent");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("trackTimerEvent",timerEventData);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKEventFinish(timerEventData);
#else

#endif
        }

        private static void UserUpdate(Dictionary<string, object> userProperties)
        {
            // if (userProperties == null)
            // {
            //     Debug.Log("userProperties must not be null");
            //     return;
            // }

            string userPropertiesJSONString = JsonConvert.SerializeObject(userProperties);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: UserUpdate");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("userUpdate", userPropertiesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKUserUpdate(userPropertiesJSONString);
#else

#endif
        }

        private static void UserInit(Dictionary<string, object> userProperties)
        {
            // if (userProperties == null)
            // {
            //     Debug.Log("userProperties must not be null");
            //     return;
            // }

            string userPropertiesJSONString = JsonConvert.SerializeObject(userProperties);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: UserInit");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("userInit",userPropertiesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKUserInit(userPropertiesJSONString);
#else

#endif
        }

        private static void UserAdd(Dictionary<string, object> userProperties)
        {
            // if (userProperties == null)
            // {
            //     Debug.Log("userProperties must not be null");
            //     return;
            // }

            string userPropertiesJSONString = JsonConvert.SerializeObject(userProperties);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: UserAdd");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("userAdd",userPropertiesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKUserAdd(userPropertiesJSONString);
#else

#endif
        }

        private static void UserAppend(Dictionary<string, object> userProperties)
        {
            // if (userProperties == null)
            // {
            //     Debug.Log("userProperties must not be null");
            //     return;
            // }

            string userPropertiesJSONString = JsonConvert.SerializeObject(userProperties);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: UserAppend");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("userAppend",userPropertiesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKUserAppend(userPropertiesJSONString);
#else

#endif
        }

        private static void UserUnset(string[] keys)
        {
            if (keys == null)
            {
                Debug.Log("keys must not be null");
                return;
            }

            if (keys.Length <= 0)
            {
                Debug.Log("keys length must be > 0");
                return;
            }

            string keysJSONStr = JsonConvert.SerializeObject(keys);
#if UNITY_EDITOR
            Debug.Log("Unity Editor: UserUnset");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("userUnset",keysJSONStr);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKUserUnset(keysJSONStr);
#else

#endif
        }

        private static void UserDelete(SEUserDeleteType deleteType)
        {
            int seUserDeleteType = deleteType == SEUserDeleteType.SEUserDeleteTypeByAccountId ? 0 : 1;
#if UNITY_EDITOR
            Debug.Log("Unity Editor: UserDelete");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("userDelete",seUserDeleteType);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKUserDelete(seUserDeleteType);
#else

#endif
        }

        private static string GetAttribution() {



#if UNITY_EDITOR
            Debug.Log("Unity Editor: GetAttribution");
            return null;
#elif UNITY_ANDROID
                return SolarEngineAndroidSDK.CallStatic<string>("getAttribution");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
               return __iOSSolarEngineSDKGetAttribution();
#else
            return null;
#endif


        }

        private static void TrackFirstEvent(SEBaseAttributes attributes)
        {
            if (attributes == null)
            {
                Debug.Log("attributes must not be null");
                return;
            }
            Dictionary<string, object> attributesDict = new Dictionary<string, object>();

            if (attributes is RegisterAttributes registerAttributes)
            {
                // 处理 RegisterAttributes 类型的逻辑
                attributesDict.Add(SolarEngine.Analytics.SEConstant_EVENT_TYPE, SolarEngine.Analytics.SEConstant_Register);
                attributesDict.Add(SolarEngine.Analytics.SEConstant_Register_Type, registerAttributes.register_type);
                attributesDict.Add(SolarEngine.Analytics.SEConstant_Register_Status, registerAttributes.register_status);
                if (registerAttributes.customProperties != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_Register_CustomProperties, registerAttributes.customProperties);
                }
                if (registerAttributes.checkId != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_CHECK_ID, registerAttributes.checkId);
                }
            }

            if (attributes is LoginAttributes loginAttributes)
            {
                // 处理 LoginAttributes 类型的逻辑
                attributesDict.Add(SolarEngine.Analytics.SEConstant_EVENT_TYPE, SolarEngine.Analytics.SEConstant_Login);
                attributesDict.Add(SolarEngine.Analytics.SEConstant_Login_Type, loginAttributes.login_type);
                attributesDict.Add(SolarEngine.Analytics.SEConstant_Login_Status, loginAttributes.login_status);
                if (loginAttributes.customProperties != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_Login_CustomProperties, loginAttributes.customProperties);
                }
                if (loginAttributes.checkId != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_CHECK_ID, loginAttributes.checkId);
                }
            }

            if (attributes is OrderAttributes orderAttributes)
            {
                // 处理 OrderAttributes 类型的逻辑
                attributesDict.Add(SolarEngine.Analytics.SEConstant_EVENT_TYPE, SolarEngine.Analytics.SEConstant_Order);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_ID, orderAttributes.order_id);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_Currency_Type, orderAttributes.currency_type);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_Pay_Type, orderAttributes.pay_type);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_Status, orderAttributes.status);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_Pay_Amount, orderAttributes.pay_amount);

                if (orderAttributes.customProperties != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_CustomProperties, orderAttributes.customProperties);
                }
                if (orderAttributes.checkId != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_CHECK_ID, orderAttributes.checkId);
                }
            }
            if (attributes is AppAttributes appAttributes)
            {
                // 处理 AppAttributes 类型的逻辑
                attributesDict.Add(SolarEngine.Analytics.SEConstant_EVENT_TYPE, SolarEngine.Analytics.SEConstant_AppAttr);
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Network, appAttributes.ad_network);
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_AttributionPlatform, appAttributes.attribution_platform);
                if (appAttributes.sub_channel != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Sub_Channel, appAttributes.sub_channel);
                }
                if (appAttributes.ad_account_id != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Account_ID, appAttributes.ad_account_id);
                }
                if (appAttributes.ad_account_name != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Account_Name, appAttributes.ad_account_name);
                }
                if (appAttributes.ad_campaign_id != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Campaign_ID, appAttributes.ad_campaign_id);
                }
                if (appAttributes.ad_campaign_name != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Campaign_Name, appAttributes.ad_campaign_name);
                }
                if (appAttributes.ad_offer_id != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Offer_ID, appAttributes.ad_offer_id);
                }
                if (appAttributes.ad_offer_name != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Offer_Name, appAttributes.ad_offer_name);
                }
                if (appAttributes.ad_creative_id != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Creative_ID, appAttributes.ad_creative_id);
                }
                if (appAttributes.ad_creative_name != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Creative_Name, appAttributes.ad_creative_name);
                }
                if (appAttributes.customProperties != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_CustomProperties, appAttributes.customProperties);
                }
                if (appAttributes.checkId != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_CHECK_ID, appAttributes.checkId);
                }
            }

            if (attributes is AdClickAttributes adClickAttributes)
            {
                // 处理 AdClickAttributes 类型的逻辑
                attributesDict.Add(SolarEngine.Analytics.SEConstant_EVENT_TYPE, SolarEngine.Analytics.SEConstant_AdClick);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_AdPlatform, adClickAttributes.ad_platform);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_MediationPlatform, adClickAttributes.mediation_platform);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_AdId, adClickAttributes.ad_id);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_AdType, adClickAttributes.ad_type);

                if (adClickAttributes.customProperties != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_CustomProperties, adClickAttributes.customProperties);
                }
                if (adClickAttributes.checkId != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_CHECK_ID, adClickAttributes.checkId);
                }
            }
            if (attributes is AppImpressionAttributes appImpressionAttributes)
            {
                // 处理 AppImpressionAttributes 类型的逻辑
                attributesDict.Add(SolarEngine.Analytics.SEConstant_EVENT_TYPE, SolarEngine.Analytics.SEConstant_IAI);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdPlatform, appImpressionAttributes.ad_platform);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_MediationPlatform, appImpressionAttributes.mediation_platform);

                if (appImpressionAttributes.ad_appid != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdAppid, appImpressionAttributes.ad_appid);
                }

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdId, appImpressionAttributes.ad_id);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdType, appImpressionAttributes.ad_type);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdEcpm, appImpressionAttributes.ad_ecpm);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_CurrencyType, appImpressionAttributes.currency_type);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_IsRendered, appImpressionAttributes.is_rendered);

                if (appImpressionAttributes.customProperties != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_CustomProperties, appImpressionAttributes.customProperties);
                }
                if (appImpressionAttributes.checkId != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_CHECK_ID, appImpressionAttributes.checkId);
                }
            }
            if (attributes is ProductsAttributes productsAttributes)
            {
                // 处理 ProductsAttributes 类型的逻辑
                attributesDict.Add(SolarEngine.Analytics.SEConstant_EVENT_TYPE, SolarEngine.Analytics.SEConstant_IAP);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_OrderId, productsAttributes.order_id);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_Amount, productsAttributes.pay_amount);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_Currency, productsAttributes.currency_type);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_PayType, productsAttributes.pay_type);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_PID, productsAttributes.product_id);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_PName, productsAttributes.product_name);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_PCount, productsAttributes.product_num);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_Paystatus, productsAttributes.paystatus);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_FailReason, productsAttributes.fail_reason == null ? "" : productsAttributes.fail_reason);

                if (productsAttributes.customProperties != null) {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_CustomProperties, productsAttributes.customProperties);
                }

                if (productsAttributes.checkId != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_CHECK_ID, productsAttributes.checkId);
                }
            }

            if (attributes is CustomAttributes customAttributes)
            {
                // 处理 CustomAttributes 类型的逻辑
                attributesDict.Add(SolarEngine.Analytics.SEConstant_EVENT_TYPE, SolarEngine.Analytics.SEConstant_CUSTOM);

                attributesDict.Add(SolarEngine.Analytics.SEConstant_CUSTOM_EVENT_NAME, customAttributes.custom_event_name);

                if (customAttributes.customProperties != null) {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_Custom_CustomProperties, customAttributes.customProperties);
                }

                if (customAttributes.preProperties != null){
				    attributesDict.Add(SolarEngine.Analytics.SEConstant_Pre_Properties,customAttributes.preProperties);
				}

                if (customAttributes.checkId != null)
                {
                    attributesDict.Add(SolarEngine.Analytics.SEConstant_CHECK_ID, customAttributes.checkId);
                }
            }

            if (attributesDict == null)
            {
                return;
            }
            string attributesJSONString = JsonConvert.SerializeObject(attributesDict);
#if UNITY_EDITOR
            Debug.Log("Unity Editor: trackFirstEvent");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("trackFirstEvent",attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                //todo ios support
                __iOSSolarEngineSDKTrackFirstEventWithAttributes(attributesJSONString);
#else

#endif

        }

        private static void ReportIAPEvent(ProductsAttributes attributes)
        {
            Dictionary<string, object> attributesDict = new Dictionary<string, object>();

            // if (attributes.order_id == null)
            // {
            //     Debug.Log("order_id must not be null");
            //     return;
            // }
            // if (attributes.currency_type == null)
            // {
            //     Debug.Log("currency_type must not be null");
            //     return;
            // }
            // if (attributes.product_id == null)
            // {
            //     Debug.Log("product_id must not be null");
            //     return;
            // }
            // if (attributes.product_num == 0)
            // {
            //     Debug.Log("product_num must be > 0");
            //     return;
            // }
            // if (attributes.product_name == null)
            // {
            //     Debug.Log("product_name must not be null");
            //     return;
            // }
            // if (!Enum.IsDefined(typeof(SEConstant_IAP_PayStatus), attributes.paystatus))
            // {
            //     Debug.Log("pay_status param type error");
            //     return;
            // }
            // if (attributes.pay_type == null)
            // {
            //     Debug.Log("pay_type must not be null");
            //     return;
            // }




            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_OrderId, attributes.order_id);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_Amount, attributes.pay_amount);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_Currency, attributes.currency_type);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_PayType, attributes.pay_type);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_PID, attributes.product_id);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_PName, attributes.product_name);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_PCount, attributes.product_num);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_Paystatus, attributes.paystatus);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_FailReason, attributes.fail_reason == null ? "" : attributes.fail_reason);

            if (attributes.customProperties != null) {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAP_CustomProperties, attributes.customProperties);
            }


            string attributesJSONString = JsonConvert.SerializeObject(attributesDict);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: TrackIAP");
#elif UNITY_ANDROID
                    SolarEngineAndroidSDKObject.CallStatic("trackPurchaseEvent",attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                    __iOSSolarEngineSDKTrackIAPWithAttributes(attributesJSONString);
#else

#endif
        }

        private static void ReportIAIEvent(AppImpressionAttributes attributes)
        {
            Dictionary<string, object> attributesDict = new Dictionary<string, object>();

            // if (attributes.ad_platform == null)
            // {
            //     Debug.Log("ad_platform must not be null");
            //     return;
            // }
            // if (attributes.mediation_platform == null)
            // {
            //     Debug.Log("mediation_platform must not be null");
            //     return;
            // }
            // if (attributes.ad_id == null)
            // {
            //     Debug.Log("ad_id must not be null");
            //     return;
            // }
            // if (attributes.ad_type == 0)
            // {
            //     Debug.Log("ad_type must be > 0");
            //     return;
            // }
            // if (attributes.currency_type == null)
            // {
            //     Debug.Log("currency_type must not be null");
            //     return;
            // }

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdPlatform, attributes.ad_platform);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_MediationPlatform, attributes.mediation_platform);

            if (attributes.ad_appid != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdAppid, attributes.ad_appid);
            }

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdId, attributes.ad_id);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdType, attributes.ad_type);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_AdEcpm, attributes.ad_ecpm);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_CurrencyType, attributes.currency_type);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_IsRendered, attributes.is_rendered);

            if (attributes.customProperties != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_IAI_CustomProperties, attributes.customProperties);
            }

            string attributesJSONString = JsonConvert.SerializeObject(attributesDict);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: TrackIAI");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("trackImpEvent",attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKTrackAdImpressionWithAttributes(attributesJSONString);
#else

#endif
        }

        private static void ReportAdClickEvent(AdClickAttributes attributes)
        {

            // if (attributes.ad_platform == null)
            // {
            //     Debug.Log("ad_platform must not be null");
            //     return;
            // }

            // if (attributes.ad_id == null)
            // {
            //     Debug.Log("ad_id must not be null");
            //     return;
            // }

            // if (attributes.mediation_platform == null)
            // {
            //     Debug.Log("mediation_platform must not be null");
            //     return;
            // }

            // if (attributes.ad_type == 0)
            // {
            //     Debug.Log("ad_type must be > 0");
            //     return;
            // }

            Dictionary<string, object> attributesDict = new Dictionary<string, object>();

            attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_AdPlatform, attributes.ad_platform);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_MediationPlatform, attributes.mediation_platform);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_AdId, attributes.ad_id);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_AdType, attributes.ad_type);

            if (attributes.customProperties != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AdClick_CustomProperties, attributes.customProperties);
            }

            string attributesJSONString = JsonConvert.SerializeObject(attributesDict);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: TrackAdClick");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("trackAdClickEvent",attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKTrackAdClickWithAttributes(attributesJSONString);
#else

#endif

        }

        private static void ReportRegisterEvent(RegisterAttributes attributes)
        {

            // if (attributes.register_type == null)
            // {
            //     Debug.Log("register_type must not be null");
            //     return;
            // }

            // if (attributes.register_status == null)
            // {
            //     Debug.Log("register_status must not be null");
            //     return;
            // }

            Dictionary<string, object> attributesDict = new Dictionary<string, object>();

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Register_Type, attributes.register_type);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Register_Status, attributes.register_status);

            if (attributes.customProperties != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_Register_CustomProperties, attributes.customProperties);
            }

            string attributesJSONString = JsonConvert.SerializeObject(attributesDict);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: TrackRegister");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("trackRegisterEvent",attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKTrackRegisterWithAttributes(attributesJSONString);
#else

#endif

        }

        private static void ReportLoginEvent(LoginAttributes attributes)
        {

            // if (attributes.login_type == null)
            // {
            //     Debug.Log("login_type must not be null");
            //     return;
            // }

            // if (attributes.login_status == null)
            // {
            //     Debug.Log("login_status must not be null");
            //     return;
            // }

            Dictionary<string, object> attributesDict = new Dictionary<string, object>();

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Login_Type, attributes.login_type);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Login_Status, attributes.login_status);

            if (attributes.customProperties != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_Login_CustomProperties, attributes.customProperties);
            }

            string attributesJSONString = JsonConvert.SerializeObject(attributesDict);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: TrackLogin");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("trackLoginEvent",attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKTrackLoginWithAttributes(attributesJSONString);
#else

#endif

        }

        private static void ReportOrderEvent(OrderAttributes attributes)
        {

            // if (attributes.order_id == null)
            // {
            //     Debug.Log("order_id must not be null");
            //     return;
            // }

            // if (attributes.currency_type == null)
            // {
            //     Debug.Log("currency_type must not be null");
            //     return;
            // }
            // if (attributes.pay_type == null)
            // {
            //     Debug.Log("pay_type must not be null");
            //     return;
            // }
            // if (attributes.status == null)
            // {
            //     Debug.Log("status must not be null");
            //     return;
            // }


            Dictionary<string, object> attributesDict = new Dictionary<string, object>();

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_ID, attributes.order_id);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_Currency_Type, attributes.currency_type);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_Pay_Type, attributes.pay_type);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_Status, attributes.status);

            attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_Pay_Amount, attributes.pay_amount);

            if (attributes.customProperties != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_Order_CustomProperties, attributes.customProperties);
            }

            string attributesJSONString = JsonConvert.SerializeObject(attributesDict);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: TrackOrder");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("trackOrderEvent",attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKTrackOrderWithAttributes(attributesJSONString);
#else

#endif

        }

        private static void AppAttrEvent(AppAttributes attributes)
        {

            // if (attributes.ad_network == null)
            // {
            //     Debug.Log("ad_network must not be null");
            //     return;
            // }

            // if (attributes.attribution_platform == null)
            // {
            //     Debug.Log("attribution_platform must not be null");
            //     return;
            // }

            Dictionary<string, object> attributesDict = new Dictionary<string, object>();

            attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Network, attributes.ad_network);
            attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_AttributionPlatform, attributes.attribution_platform);

            if (attributes.sub_channel != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Sub_Channel, attributes.sub_channel);
            }
            if (attributes.ad_account_id != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Account_ID, attributes.ad_account_id);
            }
            if (attributes.ad_account_name != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Account_Name, attributes.ad_account_name);
            }
            if (attributes.ad_campaign_id != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Campaign_ID, attributes.ad_campaign_id);
            }
            if (attributes.ad_campaign_name != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Campaign_Name, attributes.ad_campaign_name);
            }
            if (attributes.ad_offer_id != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Offer_ID, attributes.ad_offer_id);
            }
            if (attributes.ad_offer_name != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Offer_Name, attributes.ad_offer_name);
            }
            if (attributes.ad_creative_id != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Creative_ID, attributes.ad_creative_id);
            }
            if (attributes.ad_creative_name != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_Creative_Name, attributes.ad_creative_name);
            }
            if (attributes.customProperties != null)
            {
                attributesDict.Add(SolarEngine.Analytics.SEConstant_AppAttr_Ad_CustomProperties, attributes.customProperties);
            }

            string attributesJSONString = JsonConvert.SerializeObject(attributesDict);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: AppAttrEvent");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("trackAppAttrEvent",attributesJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKTrackAppAttrWithAttributes(attributesJSONString);
#else

#endif
        }


        private static void SetPresetEvent(SEConstant_Preset_EventType eventType, Dictionary<string, object> attributes)
        {

            string eventDataJSONString = JsonConvert.SerializeObject(attributes);

            string eventName = "";
            if (eventType == SEConstant_Preset_EventType.SEConstant_Preset_EventType_AppInstall)
            {
                eventName = "SEPresetEventTypeAppInstall";
            } else if (eventType == SEConstant_Preset_EventType.SEConstant_Preset_EventType_AppStart)
            {
                eventName = "SEPresetEventTypeAppStart";
            } else if (eventType == SEConstant_Preset_EventType.SEConstant_Preset_EventType_AppEnd)
            {
                eventName = "SEPresetEventTypeAppEnd";
            } else if (eventType == SEConstant_Preset_EventType.SEConstant_Preset_EventType_All)
            {
                eventName = "SEPresetEventTypeAppAll";
            }


#if UNITY_EDITOR
            Debug.Log("Unity Editor: SetPresetEvent");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("setPresetEvent",eventName,eventDataJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKSetPresetEvent(eventName, eventDataJSONString);
#else

#endif
        }

        private static void ReportCustomEvent(string customEventName, Dictionary<string, object> attributes)
        {
            string eventDataJSONString = JsonConvert.SerializeObject(attributes);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: ReportCustomEvent");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("trackCustomEvent",customEventName,eventDataJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKTrack(customEventName, eventDataJSONString);
#else

#endif
        }

        private static void ReportCustomEventWithPreAttributes(string customEventName, Dictionary<string, object> customAttributes, Dictionary<string, object> preAttributes)
        {
            string customDataJSONString = JsonConvert.SerializeObject(customAttributes);
            string preDataJSONString = JsonConvert.SerializeObject(preAttributes);

#if UNITY_EDITOR
            Debug.Log("Unity Editor: ReportCustomEvent");
#elif UNITY_ANDROID
            SolarEngineAndroidSDKObject.CallStatic("trackCustomEventWithPreEventData",customEventName,customDataJSONString,preDataJSONString);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
             __iOSSolarEngineSDKTrackCustomEventWithPreAttributes(customEventName,customDataJSONString,preDataJSONString);
#else

#endif
        }

        private static void ReportEventImmediately()
        {
#if UNITY_EDITOR
            Debug.Log("Unity Editor: ReportEventImmediately");
#elif UNITY_ANDROID
                SolarEngineAndroidSDKObject.CallStatic("reportEventImmediately");
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKReportEventImmediately();
#else

#endif
        }

        private static void HandleDeepLinkUrl(string url)
        {

#if UNITY_EDITOR
                Debug.Log("Unity Editor: HandleDeepLinkUrl not found");
#elif UNITY_ANDROID
                if(url != null) {
                    SolarEngineAndroidSDK.CallStatic("handleSchemeUrl", url);
                } else {
                    Debug.Log("url is invalid");
                }
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
               Debug.Log("Only Android can use , iOS not support");
#else

#endif

        }


        private static void DeeplinkCompletionHandler(SESDKDeeplinkCallback callback)
        {
            Analytics.Instance.deeplinkCallback_private = callback;
#if UNITY_EDITOR
                Debug.Log("Unity Editor: DeeplinkCompletionHandler not found");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("setDeepLinkCallback", callback != null ? new OnDeepLinkCallBack() : null);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKDeeplinkParseCallback(OnDeeplinkParseCallback);
#else

#endif

        }


        private static void DelayDeeplinkCompletionHandler(SESDKDelayDeeplinkCallback callback)
        {
            Analytics.Instance.delayDeeplinkCallback_private = callback;
#if UNITY_EDITOR
                Debug.Log("Unity Editor: DelayDeeplinkCompletionHandler not found");
#elif UNITY_ANDROID
                SolarEngineAndroidSDK.CallStatic("setDelayDeepLinkCallback", callback != null ? new OnDelayDeepLinkCallBack() : null);
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                __iOSSolarEngineSDKDelayDeeplinkParseCallback(OnDelayDeeplinkParseCallback);
#else

#endif

        }


#if UNITY_IPHONE
        //回调函数，必须MonoPInvokeCallback并且是static
        [MonoPInvokeCallback(typeof(SEiOSStringCallback))]
        private static void OnAttributionCallback(int code, string attribution)
        {
            OnAttributionHandler(code, attribution);
        }

        [MonoPInvokeCallback(typeof(SESDKInitCompletedCallback))]
        private static void OnInitCompletedCallback(int code)
        {
            OnInitCompletedHandler(code);
        }

        [MonoPInvokeCallback(typeof(SESDKATTCompletedCallback))]
        private static void OnRequestTrackingAuthorizationCompletedCallback(int code)
        {
            OnRequestTrackingAuthorizationCompletedHandler(code);
        }

        //回调函数，必须MonoPInvokeCallback并且是static
        [MonoPInvokeCallback(typeof(SEiOSStringCallback))]
        private static void OnSKANUpdateCVCallback(int errorCode, string errorMsg)
        {
            OnSKANUpdateCVCompletionHandler(errorCode, errorMsg);
        }

        //回调函数，必须MonoPInvokeCallback并且是static
        [MonoPInvokeCallback(typeof(SEiOSStringCallback))]
        private static void OnSKANUpdateCVCoarseValueCallback(int errorCode, string errorMsg)
        {
            OnSKANUpdateCVCoarseValueCompletionHandler(errorCode, errorMsg);
        }

        //回调函数，必须MonoPInvokeCallback并且是static
        [MonoPInvokeCallback(typeof(SEiOSStringCallback))]
        private static void OnSKANUpdateCVCoarseValueLockWindowCallback(int errorCode, string errorMsg)
        {
            OnSKANUpdateCVCoarseValueLockWindowCompletionHandler(errorCode, errorMsg);
        }

        //回调函数，必须MonoPInvokeCallback并且是static
        [MonoPInvokeCallback(typeof(SEiOSStringCallback))]
        private static void OnDeeplinkParseCallback(int code, string jsonString)
        {
            OnDeeplinkCompletionHandler(code, jsonString);
        }

        //回调函数，必须MonoPInvokeCallback并且是static
        [MonoPInvokeCallback(typeof(SEiOSStringCallback))]
        private static void OnDelayDeeplinkParseCallback(int code, string jsonString)
        {
            OnDelayDeeplinkCompletionHandler(code, jsonString);
        }

#endif


#if UNITY_ANDROID && !UNITY_EDITOR
    private sealed class OnAttributionReceivedData: AndroidJavaProxy
    {
        public OnAttributionReceivedData():base("com.reyun.solar.engine.unity.bridge.OnAttributionReceivedDataForUnity")
        {
            
        }
        public void onResultForUnity(int code,String result)
        {
            OnAttributionHandler(code,result);
        }
    }
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
    private sealed class OnDeepLinkCallBack: AndroidJavaProxy
    {
        public OnDeepLinkCallBack():base("com.reyun.solar.engine.unity.bridge.OnDeepLinkCallBack")
        {
        }
        public void onReceived(int code,String result)
        {

            OnDeeplinkCompletionHandler(code,result);
        }
    }
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
    private sealed class OnDelayDeepLinkCallBack: AndroidJavaProxy
    {
        public OnDelayDeepLinkCallBack():base("com.reyun.solar.engine.unity.bridge.OnDelayDeepLinkCallBack")
        {
        }
        public void onReceived(int code,String result)
        {

            OnDelayDeeplinkCompletionHandler(code,result);
        }
    }
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
    private sealed class OnUnityInitCompletedCallback: AndroidJavaProxy
    {
        public OnUnityInitCompletedCallback():base("com.reyun.solar.engine.unity.bridge.OnUnityInitCompletedCallback")
        {
            
        }
        public void onInitializationCompleted(int code)
        {
            OnInitCompletedHandler(code);
        }
    }
#endif

        private static void OnAttributionHandler(int code, String attributionString)
        {
            Dictionary<string, object> attribution = null;

            try
            {
                if (attributionString != null)
                {
                    attribution = JsonConvert.DeserializeObject<Dictionary<string, object>>(attributionString);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }


            Analytics.PostTask(() =>
            {
                if (Analytics.Instance.attributionCallback_private != null)
                {
                    Analytics.Instance.attributionCallback_private.Invoke(code, attribution);
                }
                else
                {
                    Debug.Log("Unity Editor: attributionCallback_private not found ");
                }
            });

        }

        private static void OnInitCompletedHandler(int code)
        {
        

            Analytics.PostTask(() =>
            {
                if (Analytics.Instance.initCompletedCallback_private != null)
                {
                    Analytics.Instance.initCompletedCallback_private.Invoke(code);
                }
                else
                {
                    Debug.Log("Unity Editor: initCompletedCallback_private not found ");
                }
            });

        }

        private static void OnRequestTrackingAuthorizationCompletedHandler(int code)
        {


            Analytics.PostTask(() =>
            {
                if (Analytics.Instance.attCompletedCallback_private != null)
                {
                    Analytics.Instance.attCompletedCallback_private.Invoke(code);
                }
                else
                {
                    Debug.Log("Unity Editor: attCompletedCallback_private not found ");
                }
            });

        }

        private static void OnDeeplinkCompletionHandler(int code, String jsonString)
        {
            Dictionary<string, object> deeplinkData = null;

            try
            {
                if (jsonString != null)
                {
                    deeplinkData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            Analytics.PostTask(() =>
            {
                if (Analytics.Instance.deeplinkCallback_private != null)
                {
                    Analytics.Instance.deeplinkCallback_private.Invoke(code, deeplinkData);
                }
                else
                {
                    Debug.Log("Unity Editor: OnDeeplinkCompletionHandler not found ");
                }
            });

        }


        private static void OnDelayDeeplinkCompletionHandler(int code, String jsonString)
        {
            Dictionary<string, object> delayDeeplinkData = null;

            try
            {
                if (jsonString != null)
                {
                    delayDeeplinkData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            Analytics.PostTask(() =>
            {
                if (Analytics.Instance.delayDeeplinkCallback_private != null)
                {
                    Analytics.Instance.delayDeeplinkCallback_private.Invoke(code, delayDeeplinkData);
                }
                else
                {
                    Debug.Log("Unity Editor: OnDelayDeeplinkCompletionHandler not found ");
                }
            });

        }


        private static void OnSKANUpdateCVCompletionHandler(int errorCode, String errorMsg)
        {
            Analytics.PostTask(() =>
            {
                if (Analytics.Instance.iosSKANUpdateCVCompletionHandler_private != null)
                {
                    Analytics.Instance.iosSKANUpdateCVCompletionHandler_private.Invoke(errorCode, errorMsg);
                }
                else
                {
                    Debug.Log("Unity Editor: iosSKANUpdateCVCompletionHandler_private not found ");
                }
            });

        }

        private static void OnSKANUpdateCVCoarseValueCompletionHandler(int errorCode, String errorMsg)
        {
            Analytics.PostTask(() =>
            {
                if (Analytics.Instance.iosSKANUpdateCVCoarseValueCompletionHandler_private != null)
                {
                    Analytics.Instance.iosSKANUpdateCVCoarseValueCompletionHandler_private.Invoke(errorCode, errorMsg);
                }
                else
                {
                    Debug.Log("Unity Editor: iosSKANUpdateCVCoarseValueCompletionHandler_private not found ");
                }
            });
        }


        private static void OnSKANUpdateCVCoarseValueLockWindowCompletionHandler(int errorCode, String errorMsg)
        {
            Analytics.PostTask(() =>
            {
                if (Analytics.Instance.iosSKANUpdateCVCoarseValueLockWindowCompletionHandler_private != null)
                {
                    Analytics.Instance.iosSKANUpdateCVCoarseValueLockWindowCompletionHandler_private.Invoke(errorCode, errorMsg);
                }
                else
                {
                    Debug.Log("Unity Editor: iosSKANUpdateCVCoarseValueLockWindowCompletionHandler_private not found ");
                }
            });
        }



#if UNITY_IPHONE


            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKPreInit(string appKey);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKInit(string appKey, string SEUserId, string seConfig, string rcConfig);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKSetGDPRArea(bool isGDPRArea);

            [DllImport("__Internal")]
	        private static extern void __iOSSolarEngineSDKTrack(string eventName, string attributes);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKTrackCustomEventWithPreAttributes(string eventName, string customAttributes, string preAttributes);

            [DllImport("__Internal")]
	        private static extern void __iOSSolarEngineSDKTrackIAPWithAttributes(string attributes);

	        [DllImport("__Internal")]
	        private static extern void __iOSSolarEngineSDKTrackAdImpressionWithAttributes(string attributes);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKTrackAdClickWithAttributes(string attributes);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKTrackRegisterWithAttributes(string attributes);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKTrackLoginWithAttributes(string attributes);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKTrackOrderWithAttributes(string attributes);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKTrackAppAttrWithAttributes(string attributes);       

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKTrackFirstEventWithAttributes(string attributes);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKSetVisitorID(string visitorID);

            [DllImport("__Internal")]
            private static extern string __iOSSolarEngineSDKVisitorID();

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKLoginWithAccountID(string accountID);

            [DllImport("__Internal")]
            private static extern string __iOSSolarEngineSDKAccountID();

            [DllImport("__Internal")]
            private static extern string __iOSSolarEngineSDKGetDistinctId();

            [DllImport("__Internal")]
            private static extern string __iOSSolarEngineSDKGetPresetProperties();

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKLogout();

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKReportEventImmediately();

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKSetSuperProperties(string properties);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKUnsetSuperProperty(string property);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKClearSuperProperties();

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKUserInit(string properties);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKUserUpdate(string properties);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKUserAdd(string properties);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKUserUnset(string keys);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKUserAppend(string properties);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKUserDelete(int deleteType);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKEventStart(string eventName);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKEventFinish(string eventJSONStr);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKEventFinishNew(string eventName, string properties);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKSetPresetEvent(string eventName, string eventDataJSONString);

            [DllImport("__Internal")]
            private static extern string __iOSSolarEngineSDKGetAttribution();

            [DllImport("__Internal")]
            private static extern void __iOSSESDKSetAttributionDataCallback(SEiOSStringCallback callback);

            [DllImport("__Internal")]
            private static extern void __iOSSESDKSetInitCompletedCallback(SESDKInitCompletedCallback callback);

            [DllImport("__Internal")]
            private static extern void __iOSSESDKRequestTrackingAuthorizationWithCompletionHandler(SESDKATTCompletedCallback callback);

            [DllImport("__Internal")]
            private static extern void __iOSSESDKupdatePostbackConversionValue(int conversionValue, SEiOSStringCallback callback);

            [DllImport("__Internal")]
            private static extern void __iOSSESDKupdateConversionValueCoarseValue(int fineValue, String coarseValue, SEiOSStringCallback callback);

            [DllImport("__Internal")]
            private static extern void __iOSSESDKupdateConversionValueCoarseValueLockWindow(int fineValue, String coarseValue, bool lockWindow, SEiOSStringCallback callback);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKDeeplinkParseCallback(SEiOSStringCallback callback);

            [DllImport("__Internal")]
            private static extern void __iOSSolarEngineSDKDelayDeeplinkParseCallback(SEiOSStringCallback callback);


#endif

        #endregion

    }
}