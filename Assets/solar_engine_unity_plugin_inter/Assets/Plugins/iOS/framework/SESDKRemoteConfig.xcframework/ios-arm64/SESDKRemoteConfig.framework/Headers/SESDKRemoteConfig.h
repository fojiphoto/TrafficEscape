//
//  SESDKRemoteConfig.h
//  SESDKRemoteConfig
//
//  Created by Mobvista on 2022/11/30.
//

#import <Foundation/Foundation.h>
#import <objc/runtime.h>

#define SERCSDKVersion @"1.2.9.2"

NS_ASSUME_NONNULL_BEGIN

/**
 
 初始化API示例
 #import <SolarEngineSDK/SolarEngineSDK.h>
 #import <SESDKRemoteConfig/SESDKRemoteConfig.h>
 
 SEConfig *config = [[SEConfig alloc] init];
 SERemoteConfig *remoteConfig = [[SERemoteConfig alloc] init];
 remoteConfig.enable = YES; // 开启在线参数功能
 config.remoteConfig = remoteConfig;
 [[SolarEngineSDK sharedInstance] startWithAppKey:your_appKey userId:your_userId_SolarEngine config:config];
 
 
 初始化后SDK会请求一次服务端配置，之后轮询每隔30分钟(默认情况)会再次请求服务端配置

 */
@interface SESDKRemoteConfig : NSObject


+ (SESDKRemoteConfig *)sharedInstance;

/**
 * 设置默认配置，当匹配不到服务端配置时会使用默认配置兜底
 *
 * @param defaultConfig 默认配置，一个参数配置为一个字典，格式如下：
  [
   {
         @"name" : @"k1", // 配置项的名称，对应fastFetchRemoteConfig接口的参数 key
         @"type" : @1, // 配置项的类型 1 string、2 integer、3 boolean、4 json
         @"value" : @"v1", // 配置项的值
   }
  ]
 */
- (void)setDefaultConfig:(NSArray *)defaultConfig;

/**
 * 设置自定义事件属性，请求参数配置时后端会使用该属性匹配
 *
 * @param properties 自定义事件属性，跟在后台页面设置的事件属性对应
 */
- (void)setRemoteConfigEventProperties:(NSDictionary *)properties;

/**
 * 设置自定义用户属性，请求参数配置时后端会使用该属性匹配
 *
 * @param properties 自定义用户属性, 跟在后台页面设置的用户属性对应
 */
- (void)setRemoteConfigUserProperties:(NSDictionary *)properties;

/**
 * 同步获取参数配置
 * 优先从缓存配置查询，查询不到则从默认配置查询，都查询不到则返回nil
 *
 * @param key  在后台页面设置的参数key，命中则返回对应值value
 */
- (id)fastFetchRemoteConfig:(NSString *)key;

/**
 * 同步获取所有参数配置
 * 包含默认配置和缓存配置
 */
- (NSDictionary *)fastFetchRemoteConfig ;


/**
 * 异步获取参数配置
 * 请求服务端配置后与本地缓存配置合并，然后从缓存配置查询，查询不到则从默认配置中查询，都查询不到则返回nil
 *
 * @param key  在后台页面设置的参数key，命中则返回对应值value
 */
- (void)asyncFetchRemoteConfig:(NSString *)key
             completionHandler:(void (^)(id data))completionHandler;


/**
 * 异步获取所有参数配置
 * 请求服务端配置后与本地缓存配置合并，然后从缓存配置查询，查询不到则从默认配置中查询，都查询不到则返回nil
 *
 */
- (void)asyncFetchRemoteConfigWithCompletionHandler:(void (^)(NSDictionary *dict))responseHandle;


/**
 *  设置debug模式，debug模式输出详细日志
 *
 * @param isDebug 是否是debug，默认为NO
 */
- (void)setDebug:(BOOL)isDebug;


@end


NS_ASSUME_NONNULL_END
