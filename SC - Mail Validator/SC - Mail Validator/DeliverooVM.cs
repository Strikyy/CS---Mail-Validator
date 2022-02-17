using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Drawing;

namespace SC___Mail_Validator
{
    class DeliverooVM
    {
        public static void postRequest(string username)
        {
            Utilities.name = "Deliveroo";
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "x-roo-guid: " + genUUID());
                        AmelioratedWrapper.AddHeaderWithStyle(request, "x-roo-client: orderweb-client");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "x-roo-session-guid: " + genUUID());
                        string url = "https://consumer-ow-api.deliveroo.com/orderapp/v2/check-email";
                        var response = request.Raw(HttpMethod.POST, url, (HttpContent)new StringContent("{\"email_address\":\"" + username + "\"}")).ToString();

                        if (response.Contains("registered\":true"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("registered\":false"))
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
        public static string genUUID()
        {
            Guid myuuid = Guid.NewGuid();
            string uuid = myuuid.ToString();
            return uuid;
        }
    }
}
