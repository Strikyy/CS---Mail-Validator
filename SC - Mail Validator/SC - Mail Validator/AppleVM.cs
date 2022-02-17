using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Drawing;

namespace SC___Mail_Validator
{
    class AppleVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "Apple";
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
                        string url = "https://appleid.apple.com/account";
                        var response = request.Raw(HttpMethod.GET, url).ToString();
                        string SCNT = response.Substring("\"scnt\": \"", "\",");
                        string session = response.Substring("\"sessionId\": \"", "\",");

                        request.KeepAlive = true;
                        request.ConnectTimeout = 2500;
                        request.IgnoreProtocolErrors = true;
                        AmelioratedWrapper.AddHeaderWithStyle(request, "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/json");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "X-Apple-ID-Session-Id: " + session);
                        AmelioratedWrapper.AddHeaderWithStyle(request, "scnt: " + SCNT);
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://appleid.apple.com/");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://appleid.apple.com/");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Accept: application/json, text/javascript, */*; q=0.01");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "X-Requested-With: XMLHttpRequest");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Accept-Encoding: gzip, deflate, br");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Accept-Language: fr-FR,fr;q=0.9,en-US;q=0.8,en;q=0.7");
                        string urlPost = "https://appleid.apple.com/account/validation/appleid";
                        var responsePost = request.Raw(HttpMethod.POST, urlPost, (HttpContent)new StringContent("{\"emailAddress\":\"" + username + "\"}")).ToString();

                        if (responsePost.Contains("used\" : true"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (responsePost.Contains("\"used\" : false") || responsePost.Contains("valid\" : false"))
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
    }
}
