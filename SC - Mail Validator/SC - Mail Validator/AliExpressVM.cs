using System;
using Leaf.xNet;
using CheckerSimplefied;

namespace SC___Mail_Validator
{
    public class AliExpressVM
    {
        public static void getRequests(string username)
        {
            Utilities.name = "AliExpress";
            for (; ; )
            {
                try
                {
                    if(Program.proxyType > 0)
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://best.aliexpress.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://best.aliexpress.com/");
                        string url = "https://login.aliexpress.com/join/preCheckForRegister.htm?registerFrom=AE_MAIN_POPUP_WHOLESALE&umidToken=&ua=&email=" + username + "&registerType=EMAIL_WITH_VERIFY_CODE&aeuic-ab-data=&bx-ua=&_bx-v=2.0.39";
                        var response = request.Raw(HttpMethod.GET, url).ToString();

                        if (response.Contains("\"isEmailExisted\":true}"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("\"isEmailExisted\":false}"))
                        {
                            Utilities.saveFail(username);
                            break;
                        }                       
                    }
                }
                catch(Exception e)
                {
                    Utilities.catchRetry();
                }
            }
        }
    }
}
