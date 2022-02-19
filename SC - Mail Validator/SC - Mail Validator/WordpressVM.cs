using System;
using Leaf.xNet;
using CheckerSimplefied;

namespace SC___Mail_Validator
{
    class WordpressVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "WordPress";
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://public-api.wordpress.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://public-api.wordpress.com/wp-admin/rest-proxy/?v=2.0user-agent: Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36");
                        string url = "https://public-api.wordpress.com/rest/v1.1/signups/validation/user?http_envelope=1&locale=us";
                        var response = request.Raw(HttpMethod.POST, url, (HttpContent)new StringContent("{\"email\":\"" + username + "\",\"password\":\"\",\"username\":\"\",\"locale\":\"us\"}")).ToString();

                        if (response.Contains("{\"taken\":\"An account with this email already exists.\"}"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("Enter a working email address") || response.Contains("Required fields not supplied") || response.Contains("Use a working email address") || response.Contains("messages\":{\"username\":{\"argument\":\"Enter a username of your choice.\"}"))
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
