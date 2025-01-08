/**
 * The MIT License (MIT)
 * 
 * Copyright (c) 2015-Present CG
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System;
using System.Collections.Generic;
using SolarEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

namespace SolarEngine.Sample
{

    public class UIManagerScript : MonoBehaviour
    {

        void Start()
        {

            InitSDK();
        }

        public void InitSDK()
        {

            Debug.Log("[unity] init click");

            String AppKey = "";

            SEConfig seConfig = new SEConfig();
            RCConfig rcConfig = new RCConfig();
            seConfig.logEnabled = true;
            rcConfig.enable = true;

            SolarEngine.Analytics.SEAttributionCallback callback = new SolarEngine.Analytics.SEAttributionCallback(attSuccessCallback);
            seConfig.attributionCallback = callback;

            SolarEngine.Analytics.SESDKInitCompletedCallback initCallback = new SolarEngine.Analytics.SESDKInitCompletedCallback(initSuccessCallback);
            seConfig.initCompletedCallback = initCallback;

            SolarEngine.Analytics.preInitSeSdk(AppKey);
            SolarEngine.Analytics.initSeSdk(AppKey, seConfig, rcConfig);
        }

  
        public void trackAdClick()
        {
            Debug.Log("[unity] trackAdClick click");

            AdClickAttributes AdClickAttributes = new AdClickAttributes();
            AdClickAttributes.ad_platform = "AdMob_Test";
            AdClickAttributes.mediation_platform = "gromore_test";
            AdClickAttributes.ad_id = "product_id_test";
            AdClickAttributes.ad_type = 1;
            AdClickAttributes.checkId = "123";
            AdClickAttributes.customProperties = getCustomProperties();
            SolarEngine.Analytics.trackAdClick(AdClickAttributes);

        }
        public void trackRegister()
        {
            Debug.Log("[unity] trackRegister click");

            RegisterAttributes RegisterAttributes = new RegisterAttributes();
            RegisterAttributes.register_type = "QQ_test";
            RegisterAttributes.register_status = "success_test";
            RegisterAttributes.customProperties = getCustomProperties();
            SolarEngine.Analytics.trackRegister(RegisterAttributes);

        }  

        public void track()
        {
            Debug.Log("[unity] track custom click");

            Dictionary<string, object> customProperties = new Dictionary<string, object>();
            customProperties.Add("event001", 111);
            customProperties.Add("event002", "event002");
            customProperties.Add("_event003", 1);

            Dictionary<string, object> preProperties = new Dictionary<string, object>();
            preProperties.Add("_pay_amount", 0.55);
            preProperties.Add("_ecpm", 1.2);

            SolarEngine.Analytics.trackCustom("xxx", customProperties, preProperties);

        }

        public void trackAppAtrr() {

            Debug.Log("[unity] trackAppAtrr click");

            AppAttributes AppAttributes = new AppAttributes();
            AppAttributes.ad_network = "toutiao";
            AppAttributes.sub_channel = "103300";
            AppAttributes.ad_account_id = "1655958321988611";
            AppAttributes.ad_account_name = "xxx科技全量18";
            AppAttributes.ad_campaign_id = "1680711982033293";
            AppAttributes.ad_campaign_name = "小鸭快冲计划157-1024";
            AppAttributes.ad_offer_id = "1685219082855528";
            AppAttributes.ad_offer_name = "小鸭快冲单元406-1024";
            AppAttributes.ad_creative_id = "1680128668901378";
            AppAttributes.ad_creative_name = "自动创建20210901178921";
            AppAttributes.ad_creative_name = "自动创建20210901178921";
            AppAttributes.attribution_platform = "se";
            AppAttributes.customProperties = getCustomProperties();
            SolarEngine.Analytics.trackAppAttr(AppAttributes);

        }

        public void trackIAP()
        {
            Debug.Log("[unity] trackIAP click");

            ProductsAttributes productsAttributes = new ProductsAttributes();
            productsAttributes.product_name = "product_name";
            productsAttributes.product_id = "product_id";
            productsAttributes.product_num = 8;
            productsAttributes.currency_type = "CNY";
            productsAttributes.order_id = "order_id";
            productsAttributes.fail_reason = "fail_reason";
            productsAttributes.paystatus = SEConstant_IAP_PayStatus.SEConstant_IAP_PayStatus_success;
            productsAttributes.pay_type = "wechat";
            productsAttributes.pay_amount = 9.9;
            productsAttributes.customProperties = getCustomProperties();
            SolarEngine.Analytics.trackIAP(productsAttributes);
        }

        public void trackAdImpression()
        {
            Debug.Log("[unity] trackAdImpression click");

            AppImpressionAttributes impressionAttributes = new AppImpressionAttributes();
            impressionAttributes.ad_platform = "AdMob";
            //impressionAttributes.ad_appid = "ad_appid";
            impressionAttributes.mediation_platform = "gromore";
            impressionAttributes.ad_id = "product_id";
            impressionAttributes.ad_type = 1;
            impressionAttributes.ad_ecpm = 0.8;
            impressionAttributes.currency_type = "CNY";
            impressionAttributes.is_rendered = true;
            impressionAttributes.customProperties = getCustomProperties();
            SolarEngine.Analytics.trackIAI(impressionAttributes);

        }
 

        public void trackLogin()
        {
            Debug.Log("[unity] trackLogin click");

            LoginAttributes LoginAttributes = new LoginAttributes();
            LoginAttributes.login_type = "QQ_test";
            LoginAttributes.login_status = "success1_test";
            LoginAttributes.customProperties = getCustomProperties();
            SolarEngine.Analytics.trackLogin(LoginAttributes);

        }

        public void trackOrder()
        {
            Debug.Log("[unity] trackOrderclick");

            OrderAttributes OrderAttributes = new OrderAttributes();
            OrderAttributes.order_id = "order_id_test";
            OrderAttributes.pay_amount = 10.5;
            OrderAttributes.currency_type = "CNY";
            OrderAttributes.pay_type = "AIP";
            OrderAttributes.status = "success";
            OrderAttributes.customProperties = getCustomProperties();

            SolarEngine.Analytics.trackOrder(OrderAttributes);

        }
    

        public void userInit()
        {
            Debug.Log("[unity] userInit click");

            Dictionary<string, object> userProperties = new Dictionary<string, object>();
            userProperties.Add("K1", "V1");
            userProperties.Add("K2", "V2");
            userProperties.Add("K3", 2);
            SolarEngine.Analytics.userInit(userProperties);

        }

        public void userUpdate()
        {
            Debug.Log("[unity] userUpdate click");

            Dictionary<string, object> userProperties = new Dictionary<string, object>();
            userProperties.Add("K1", "V1");
            userProperties.Add("K2", "V2");
            userProperties.Add("K3", 2);
            SolarEngine.Analytics.userUpdate(userProperties);

        }

        public void userAdd()
        {
            Debug.Log("[unity] userAdd click");

            Dictionary<string, object> userProperties = new Dictionary<string, object>();
            userProperties.Add("K1", 10);
            userProperties.Add("K2", 100);
            userProperties.Add("K3", 2);
            SolarEngine.Analytics.userAdd(userProperties);

        }

        public void userUnset()
        {
            Debug.Log("[unity] userUnset click");

            SolarEngine.Analytics.userUnset(new string[] { "K1", "K2" });

        }

        public void userAppend()
        {
            Debug.Log("[unity] userAppend click");

            Dictionary<string, object> userProperties = new Dictionary<string, object>();
            userProperties.Add("K1", "V1");
            userProperties.Add("K2", "V2");
            userProperties.Add("K3", 2);
            SolarEngine.Analytics.userAppend(userProperties);



        }

        public void userDelete()
        {
            Debug.Log("[unity] SEUserDeleteTypeByAccountId click");

            SolarEngine.Analytics.userDelete(SEUserDeleteType.SEUserDeleteTypeByAccountId);

        }



        private void initSuccessCallback(int code)
        {
            Debug.Log("SEUnity:initSuccessCallback  code : " + code);

        }


        private void attSuccessCallback(int errorCode , Dictionary<string, object> attribution)
        {
     
            if (errorCode != 0)
            {
                Debug.Log("SEUnity: errorCode : " + errorCode);

            }
            else
            {

                Debug.Log("SEUnity: attSuccessCallback : " + attribution);

            }
        }


        private Dictionary<string, object> getCustomProperties() {

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("K1", "V1");
            properties.Add("K2", "V2");
            properties.Add("K3", 2);

            return properties;
        }
    }

}