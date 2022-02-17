using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Net;

namespace SC___Mail_Validator
{
    public class DeezerVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "Deezer";
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: text/plain");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://www.deezer.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://www.deezer.com/fr/register?rg=1");
                        string url = "https://www.deezer.com/ajax/gw-light.php?method=deezer.getUserData&input=3&api_version=1.0&api_token";
                        var response = request.Raw(HttpMethod.POST, url, (HttpContent)new StringContent("{}")).ToString();
                        string csrf = response.Substring("checkForm\":\"", "\",");

                        request.UserAgent = Http.RandomUserAgent();
                        request.KeepAlive = true;
                        request.ConnectTimeout = 2500;
                        request.IgnoreProtocolErrors = true;
                        AmelioratedWrapper.AddHeaderWithStyle(request, "User-Agent: Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: text/plain");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://www.deezer.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://www.deezer.com/en/register");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "x-deezer-user: 0");                   
                        string urlPost = "https://www.deezer.com/ajax/gw-light.php?method=deezer.emailCheck&input=3&api_version=1.0&api_token=" + csrf;
                        var responsePost = request.Raw(HttpMethod.POST, urlPost, (HttpContent)new StringContent("{\"EMAIL\":\"" + username + "\"}")).ToString();

                        if (responsePost.Contains("{\"availability\":true") || responsePost.Contains("MISSING_PARAMETER_EMAIL") || responsePost.Contains("domain_validity\":false"))
                        {
                            Utilities.saveFail(username);
                            break;
                        }
                        if (responsePost.Contains("availability\":false") || responsePost.Contains("domain_validity\":true"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (responsePost.Contains("Invalid CSRF token"))
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
