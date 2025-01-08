//
//  SEEventConstants.h
//  SolarEngineSDK
//
//  Created by MVP on 2022/1/20.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

// 内置事件类型
typedef NS_ENUM(NSUInteger, SEPresetEventType) {
    SEPresetEventTypeAppInstall,
    SEPresetEventTypeAppStart,
    SEPresetEventTypeAppEnd,
    SEPresetEventTypeAppAll // 该事件表示全部内置事件
};

typedef NS_OPTIONS(NSInteger, SEAutoTrackEventType) {
    SEAutoTrackEventTypeNone          = 0,      // 不开启自动追踪
    SEAutoTrackEventTypeAppClick      = 1 << 0, // 自动追踪控件点击
    SEAutoTrackEventTypeAppViewScreen = 1 << 1, // 自动追踪页面浏览
};

typedef NS_OPTIONS(NSInteger, SEUserDeleteType) {
    SEUserDeleteTypeByAccountId, // 通过AccountId删除用户
    SEUserDeleteTypeByVisitorId, // 通过VisitorId删除用户
};


/*
该枚举自 SDK v1.1.0（包含）版本后废弃。需要传相应的字符串值（即下方应传值），

 前面为应传值，后面为平台名称
 csj：穿山甲国内版
 pangle：穿山甲国际版
 tencent：腾讯优量汇
 baidu：百度百青藤
 kuaishou：快手
 oppo：OPPO
 vivo：vivo
 mi：小米
 huawei：华为
 applovin：Applovin
 sigmob：Sigmob
 mintegral：Mintegral
 oneway：OneWay
 vungle：Vungle
 facebook：Facebook
 admob：AdMob
 unity：UnityAds
 is：IronSource
 adtiming：AdTiming
 klein：游可赢
 fyber：Fyber
 chartboost：Chartboost
 adcolony：Adcolony
 
extern NSString * const SEMonetizationPlatformNameCSJ;
extern NSString * const SEMonetizationPlatformNameYLH;
extern NSString * const SEMonetizationPlatformNameBQT;
extern NSString * const SEMonetizationPlatformNameKuai;
extern NSString * const SEMonetizationPlatformNameSigmob;
extern NSString * const SEMonetizationPlatformNameMintegral;
extern NSString * const SEMonetizationPlatformNameOneWay;
extern NSString * const SEMonetizationPlatformNameVungle;
extern NSString * const SEMonetizationPlatformNameFacebook;
extern NSString * const SEMonetizationPlatformNameAdMob;
extern NSString * const SEMonetizationPlatformNameUnityAds;
extern NSString * const SEMonetizationPlatformNameIronSource;
extern NSString * const SEMonetizationPlatformNameAdTiming;
extern NSString * const SEMonetizationPlatformNameKlein;
*/

/*
 AdImpression Event properties
 */
extern NSString * const SEAdImpressionPropertyAdPlatform;
extern NSString * const SEAdImpressionPropertyAppID;
extern NSString * const SEAdImpressionPropertyPlacementID;
extern NSString * const SEAdImpressionPropertyAdType;
extern NSString * const SEAdImpressionPropertyEcpm;
extern NSString * const SEAdImpressionPropertyCurrency;
extern NSString * const SEAdImpressionPropertyMediationPlatform;
extern NSString * const SEAdImpressionPropertyRendered;


extern NSString * const SEAppAttrPropertyIsAttr;
extern NSString * const SEAppAttrPropertyAdNetwork;
extern NSString * const SEAppAttrPropertySubChannel;
extern NSString * const SEAppAttrPropertyAdAccountID;
extern NSString * const SEAppAttrPropertyAdAccountName;
extern NSString * const SEAppAttrPropertyAdCampaignID;
extern NSString * const SEAppAttrPropertyAdCampaignName;
extern NSString * const SEAppAttrPropertyAdOfferID;
extern NSString * const SEAppAttrPropertyAdOfferName;
extern NSString * const SEAppAttrPropertyAdCreativeID;
extern NSString * const SEAppAttrPropertyAdCreativeName;
extern NSString * const SEAppAttrPropertyAttributionPlatform;

/*
 IAP Event properties
 */
extern NSString * const SEIAPEventProductID;
extern NSString * const SEIAPEventProductName;
extern NSString * const SEIAPEventProductCount;
extern NSString * const SEIAPEventOrderID;
extern NSString * const SEIAPEventCurrency;
extern NSString * const SEIAPEventPaystatus;
extern NSString * const SEIAPEventPayType;
extern NSString * const SEIAPEventProductPayAmount;
extern NSString * const SEIAPEventFailReason;

/*
 Register Event properties
 */
extern NSString * const SERegisterPropertyType;
extern NSString * const SERegisterPropertyStatus;

/*
 Login Event properties
 */
extern NSString * const SELoginPropertyType;
extern NSString * const SELoginPropertyStatus;

/*
 Order Event properties
 */
extern NSString * const SEOrderPropertyID;
extern NSString * const SEOrderPropertyPayAmount;
extern NSString * const SEOrderPropertyCurrencyType;
extern NSString * const SEOrderPropertyPayType;
extern NSString * const SEOrderPropertyStatus;

/*
 PayType
 */
extern NSString * const SEIAPEventPayTypeAlipay;
extern NSString * const SEIAPEventPayTypeWeixin;
extern NSString * const SEIAPEventPayTypeApplePay;
extern NSString * const SEIAPEventPayTypePaypal;

/// IAP Status
typedef NS_ENUM(NSInteger, SolarEngineIAPStatus) {
    SolarEngineIAPNone          = 0,
    SolarEngineIAPSuccess       = 1,
    SolarEngineIAPFail          = 2,
    SolarEngineIAPRestored      = 3
};

/*

该枚举自 SDK v1.1.0（包含）版本后废弃。用户须传整型数值到接口，整型数值对应如下：
 1：激励视频
 2：开屏
 3：插屏
 4：全屏视频
 5：Banner
 6：信息流
 7：短视频信息流
 8：大横幅
 9：视频贴片
 10：其它
 
 如果没有找到相关值，请查看集成文档或者联系我们技术支持人员。
 
/// Ad Type
typedef NS_ENUM(NSInteger, SolarEngineAdType) {
    SolarEngineAdTypeNone               = 0,
    SolarEngineAdTypeRewardVideo        = 1,
    SolarEngineAdTypeSplash             = 2,
    SolarEngineAdTypeInterstitial       = 3,
    SolarEngineAdTypeInterstitialVideo  = 4,
    SolarEngineAdTypeBanner             = 5,
    SolarEngineAdTypeNative             = 6,
    SolarEngineAdTypeNativeVideo        = 7,
    SolarEngineAdTypeBigBanner          = 8,
    SolarEngineAdTypeInStream           = 9,
    SolarEngineAdTypeOther              = 10
};*/


@interface SEEventBaseAttribute : NSObject

/// 首次事件的唯一标识
@property (nonatomic, copy) NSString *firstCheckId;

@end


@interface SECustomEventAttribute : SEEventBaseAttribute

/// 自定义事件名称
@property (nonatomic, copy) NSString *eventName;

/// 自定义属性
@property (nonatomic, copy) NSDictionary *customProperties;

/// 预置属性
@property (nonatomic, copy) NSDictionary *presetProperties;

@end


@interface SEIAPEventAttribute : SEEventBaseAttribute

/// 购买商品的ID
@property (nonatomic, copy, nonnull) NSString *productID;

/// 商品名称
@property (nonatomic, copy, nonnull) NSString *productName;

/// 商品的数量
@property (nonatomic, assign) NSInteger productCount;

/// 订单 ID
@property (nonatomic, copy, nonnull)  NSString *orderId;

/// 支付的金额
@property (nonatomic, assign) double payAmount;

/// 货币类型。遵循《ISO 4217国际标准》，如 CNY、USD
@property (nonatomic, copy, nonnull) NSString *currencyType;

/*
 支付类型
 Your should use below value, or customize your own value if not contains the paytype you using

 extern NSString * const SEIAPEventPayTypeAlipay;
 extern NSString * const SEIAPEventPayTypeWeixin;
 extern NSString * const SEIAPEventPayTypeApplePay;
 extern NSString * const SEIAPEventPayTypePaypal;
 */
@property (nonatomic, copy, nonnull) NSString *payType;

/// 支付状态
@property (nonatomic, assign) SolarEngineIAPStatus payStatus;

/// 支付失败的原因
@property (nonatomic, copy) NSString *failReason;

/// 自定义属性
@property (nonatomic, copy) NSDictionary *customProperties;

@end

@interface SEAdImpressionEventAttribute : SEEventBaseAttribute

/// 广告类型（如开屏、激励视频等）
/* 用户须传整型数值到接口，整型数值对应如下：
1：激励视频
2：开屏
3：插屏
4：全屏视频
5：Banner
6：信息流
7：短视频信息流
8：大横幅
9：视频贴片
10：其它

如果没有找到相关值，请查看集成文档或者联系我们技术支持人员。
 */
@property (nonatomic, assign) NSUInteger adType;

/*
 adNetworkPlatform
 Monetization platform
 
 变现平台，前面为应传值，后面为平台名称
 csj：穿山甲国内版
 pangle：穿山甲国际版
 tencent：腾讯优量汇
 baidu：百度百青藤
 kuaishou：快手
 oppo：OPPO
 vivo：vivo
 mi：小米
 huawei：华为
 applovin：Applovin
 sigmob：Sigmob
 mintegral：Mintegral
 oneway：OneWay
 vungle：Vungle
 facebook：Facebook
 admob：AdMob
 unity：UnityAds
 is：IronSource
 adtiming：AdTiming
 klein：游可赢
 fyber：Fyber
 chartboost：Chartboost
 adcolony：Adcolony
 
 如果没有找到相关值，请查看集成文档或者联系我们技术支持人员。
 */
@property (nonatomic, copy, nonnull) NSString *adNetworkPlatform;

/// Ad Network Platform App ID
@property (nonatomic, copy) NSString *adNetworkAppID;

/// Ad Network Platform Placement ID
@property (nonatomic, copy, nonnull) NSString *adNetworkPlacementID;

/// currency
@property (nonatomic, copy, nonnull) NSString *currency;

/// 每一千次展示可以获得的广告收入
@property (nonatomic, assign) double ecpm;

/// mediationPlatform
@property (nonatomic, copy, nonnull) NSString *mediationPlatform;

/// 是否渲染（默认值为 YES）
@property (nonatomic, assign) BOOL rendered;

/// 自定义属性
@property (nonatomic, copy) NSDictionary *customProperties;

@end


/// 用户注册事件属性
@interface SERegisterEventAttribute : SEEventBaseAttribute

/// 注册类型 不超过 32 字符
@property (nonatomic, copy, nonnull) NSString *registerType;

/// 注册状态
@property (nonatomic, copy) NSString *registerStatus;

/// 自定义属性
@property (nonatomic, copy) NSDictionary *customProperties;

@end

/// 登录事件属性
@interface SELoginEventAttribute : SEEventBaseAttribute

/// 登录类型 不超过 32 字符
@property (nonatomic, copy, nonnull) NSString *loginType;

/// 登录状态
@property (nonatomic, copy) NSString *loginStatus;

/// 自定义属性
@property (nonatomic, copy) NSDictionary *customProperties;

@end

/// 订单事件属性
@interface SEOrderEventAttribute : SEEventBaseAttribute

/// 订单 ID 不超过 128  字符
@property (nonatomic, copy, nonnull) NSString *orderID;

/// 订单金额，单位：元
@property (nonatomic, assign) double payAmount;

/// 货币类型。遵循《ISO 4217国际标准》，如 CNY、USD
@property (nonatomic, copy, nonnull) NSString *currencyType;

/// 支付类型
@property (nonatomic, copy) NSString *payType;

/// 订单状态
@property (nonatomic, copy) NSString *status;

/// 自定义属性
@property (nonatomic, copy) NSDictionary *customProperties;

@end

@interface SEAdClickEventAttribute : SEEventBaseAttribute

/// 广告类型（如开屏、激励视频等）
/* 用户须传整型数值到接口，整型数值对应如下：
1：激励视频
2：开屏
3：插屏
4：全屏视频
5：Banner
6：信息流
7：短视频信息流
8：大横幅
9：视频贴片
10：其它

如果没有找到相关值，请查看集成文档或者联系我们技术支持人员。
 */
@property (nonatomic, assign) NSInteger adType;

/*
 adNetworkPlatform
 Monetization platform
 
 变现平台，前面为应传值，后面为平台名称
 csj：穿山甲国内版
 pangle：穿山甲国际版
 tencent：腾讯优量汇
 baidu：百度百青藤
 kuaishou：快手
 oppo：OPPO
 vivo：vivo
 mi：小米
 huawei：华为
 applovin：Applovin
 sigmob：Sigmob
 mintegral：Mintegral
 oneway：OneWay
 vungle：Vungle
 facebook：Facebook
 admob：AdMob
 unity：UnityAds
 is：IronSource
 adtiming：AdTiming
 klein：游可赢
 fyber：Fyber
 chartboost：Chartboost
 adcolony：Adcolony
 
 如果没有找到相关值，请查看集成文档或者联系我们技术支持人员。
 */
@property (nonatomic, copy, nonnull) NSString *adNetworkPlatform;

/// Ad Network Platform Placement ID
@property (nonatomic, copy, nonnull) NSString *adNetworkPlacementID;

/// mediationPlatform 聚合平台标识，没有聚合平台标识，请设置为 "custom"
@property (nonatomic, copy, nonnull) NSString *mediationPlatform;

/// 自定义属性
@property (nonatomic, copy) NSDictionary *customProperties;

@end

@interface SEAppAttrEventAttribute : SEEventBaseAttribute

// 投放广告的渠道 ID，需要与发行平台匹配
@property (nonatomic, copy) NSString *adNetwork;

// 投放广告的子渠道
@property (nonatomic, copy) NSString *subChannel;

// 投放广告的投放账号 ID
@property (nonatomic, copy) NSString *adAccountID;

// 投放广告的投放账号名称
@property (nonatomic, copy) NSString *adAccountName;

// 投放广告的广告计划 ID
@property (nonatomic, copy) NSString *adCampaignID;

// 投放广告的广告计划名称
@property (nonatomic, copy) NSString *adCampaignName;

// 投放广告的广告单元 ID
@property (nonatomic, copy) NSString *adOfferID;

// 投放广告的广告单元名称
@property (nonatomic, copy) NSString *adOfferName;

// 投放广告的广告创意 ID
@property (nonatomic, copy) NSString *adCreativeID;

// 投放广告的广告创意名称
@property (nonatomic, copy) NSString *adCreativeName;

// 监测平台
@property (nonatomic, copy) NSString *attributionPlatform;

// 自定义属性
@property (nonatomic, copy) NSDictionary *customProperties;

@end


@interface SEEventConstants : NSObject

@end

@interface SEDeeplinkInfo : NSObject

// 跳转参数
@property (nonatomic, copy) NSString *sedpLink;
// 7位短链
@property (nonatomic, copy) NSString *turlId;
// 链接类型, link 或 urlscheme
@property (nonatomic, copy) NSString *from;
// 自定义参数    
@property (nonatomic, copy) NSDictionary *customParams;

@end

@interface SEDelayDeeplinkInfo : NSObject

// 跳转参数
@property (nonatomic, copy) NSString *sedpLink;
// 7位短链
@property (nonatomic, copy) NSString *turlId;
// 用户在创建deeplink链接时填写的url scheme
@property (nonatomic, copy) NSString *sedpUrlscheme;

@end



NS_ASSUME_NONNULL_END
