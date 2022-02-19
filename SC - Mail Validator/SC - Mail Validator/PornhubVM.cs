using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Drawing;
using System.Text;
using System.Net;

namespace SC___Mail_Validator
{
    class PornhubVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "Pornhub";
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/x-www-form-urlencoded");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Referer: https://fr.pornhub.com/");
                        string url = "https://fr.pornhubpremium.com/premium_signup?ats=" + genJWT();
                        var response = request.Raw(HttpMethod.GET, url).ToString();
                        string idToken = response.Substring("id=\"token\" value=\"", "\"");
                        var cookies = request.Cookies.GetCookies(url);
                        foreach (Cookie cookie in cookies)
                        {
                            if (cookie.Name == "ss")
                            {
                                ss = cookie.Value;
                            }
                        }

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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/x-www-form-urlencoded");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Origin: https://fr.pornhubpremium.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Referer: " + url);
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Accept-Encoding: gzip, deflate, br");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Accept-Language: fr-FR,fr;q=0.9");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "cookie: ss=" + ss);
                        string urlPost = "https://fr.pornhubpremium.com/user/create_account_check?token=" + idToken;
                        var responsePost = request.Raw(HttpMethod.POST, urlPost, (HttpContent)new StringContent("token=" + idToken + "&join=&dbPackageId=&probiller_init=1&referred_by=&newUserProductId=&renewUserProductId=&forcePaymentType=cryptocurrency&orientation=straight&affiliateName=&externalOrInternal=&campaignName=&fromPremiumSignUp=1&premiumRebillPeriod=&username=&password=&email=" + username + "&check_what=email")).ToString();
                        
                        if (responsePost.Contains("create_account_passed") || responsePost.Contains("create_account_empty"))
                        {
                            Utilities.saveFail(username);
                            break;
                        }
                        if (responsePost.Contains("create_account_failed"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (responsePost.Contains("\"NOK\""))
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

        static Random rand = new Random();

        public static string genJWT()
        {
            StringBuilder S = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                int number = rand.Next(0, 9);
                S.Append(number.ToString());
            }
            StringBuilder T = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                int number = rand.Next(0, 9);
                T.Append(number.ToString());
            }
            StringBuilder R = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                int number = rand.Next(0, 9);
                R.Append(number.ToString());
            }
            StringBuilder I = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                int number = rand.Next(0, 9);
                I.Append(number.ToString());
            }
            StringBuilder K = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                int number = rand.Next(0, 9);
                K.Append(number.ToString());
            }

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("{\"a\":" + S + ",\"n\":" + T + ",\"s\":" + R + ",\"e\":" + I + ",\"p\":" + K + ",\"cn\":\"SignUp-Modal_C000_42_1_42\"}");
            string jwt = Convert.ToBase64String(plainTextBytes);
            return jwt;
        }

        public static string ss;
    }
}
