//
//  SEConfig.h
//  SolarEngineSDK
//
//  Created by Mobvista on 2023/9/14.
//

#import <Foundation/Foundation.h>
#import <SolarEngineSDK/SEEventConstants.h>

NS_ASSUME_NONNULL_BEGIN

typedef NS_ENUM(NSInteger, SERCMergeType) {
    SERCMergeTypeDefault      = 0, // 默认策略，读取缓存配置+默认配置跟服务端配置合并
    SERCMergeTypeUser         = 1, // App版本更新时，使用默认配置+服务端合并（丢弃缓存配置）
};


@interface SERemoteConfig : NSObject

/**
 线参数SDK启用开关，默认为关闭状态
*/
@property (nonatomic, assign) BOOL enable;

/**
自定义ID, 用来匹配用户在后台设置规则时设置的自定义ID
*/
@property (nonatomic, strong) NSDictionary *customIDProperties;

/**
 * 自定义ID 事件属性
 */
@property (nonatomic, strong) NSDictionary *customIDEventProperties;

/**
 * 自定义ID 用户属性
 */
@property (nonatomic, strong) NSDictionary *customIDUserProperties;

/**
SDK配置合并策略，默认情况下服务端配置跟本地缓存配置合并
ENUM：SERCMergeTypeUser 在App版本更新时会清除缓存配置
*/
@property (nonatomic, assign) SERCMergeType mergeType;

/// 是否开启 本地调试日志（不设置时默认不开启 本地日志）
@property (nonatomic, assign) BOOL logEnabled;

@end


@interface SECustomDomain : NSObject

/// 是否开启 私有化部署（不设置时默认不开启 ）
@property (nonatomic, assign) BOOL enable;

/// 设置私有化部署http域名：事件上报、debug模式事件上报、归因、延迟deeplink
@property (nonatomic, strong) NSString *receiverDomain;
/// 设置私有化部署http域名：在线参数
@property (nonatomic, strong) NSString *ruleDomain;
/// 设置私有化部署tcp host:  归因、debug模式事件上报
@property (nonatomic, strong) NSString *receiverTcpHost;
/// 设置私有化部署tcp host:  在线参数
@property (nonatomic, strong) NSString *ruleTcpHost;
/// 设置私有化部署tcp host:  事件上报
@property (nonatomic, strong) NSString *gatewayTcpHost;

@end


@interface SEConfig : NSObject

/// 是否开启 本地调试日志（不设置时默认不开启 本地日志）
@property (nonatomic, assign) BOOL logEnabled;

/// 是否开启 Debug 模式，开启后能在后台实时查看数据（不设置时默认不开启 Debug 模式）
/// Debug 模式 请勿发布到线上 !!!
@property (nonatomic, assign) BOOL isDebugModel;

/// 是否为GDPR区域，默认为不做GDPR区域限制
@property (nonatomic, assign) BOOL isGDPRArea;

// 是否开启COPPA合规政策，开启后不获取idfv、idfa, 默认不开启
@property (nonatomic, assign) BOOL setCoppaEnabled;

// 是否开启Kids App合规政策，开启后不获取idfv、idfa, 默认不开启
@property (nonatomic, assign) BOOL setKidsAppEnabled;

/// 自动追踪埋点采集类型，SDK默认不开启自动追踪埋点采集
@property(nonatomic, assign) SEAutoTrackEventType autoTrackEventType;


/// 2G网络是否上报数据，默认只有3G、4G、5G、WiFi上报，2G不上报
@property (nonatomic, assign) BOOL enable2GReporting;

/// 首次上报事件等待ATT授权秒数，单位：秒
@property (nonatomic, assign) int attAuthorizationWaitingInterval;

/// 是否开启延迟Deeplink，默认NO，不开启。
@property (nonatomic, assign) BOOL enableDelayDeeplink;


/// 在线参数config (不使用在线参数则不需要设置)
@property (nonatomic, strong) SERemoteConfig * remoteConfig;


/// 私有化部署配置，saas用户不用设置
@property (nonatomic, strong) SECustomDomain * customDomain;

@end




NS_ASSUME_NONNULL_END
