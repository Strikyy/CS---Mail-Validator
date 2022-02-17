using System;
using System.Threading;

namespace SC___Mail_Validator
{
    class Module
    {
        public static void moduleGet()
        {
            for (; ; )
            {
                if ((((uint)Program.mailList.Count == (uint)0) ? 1u : 0u) != (uint)0)
                {
                    break;
                }
                string text;
                if ((Program.mailList.TryTake(out text) ? 1u : 0u) == (uint)0)
                {
                    break;
                }
                if ((text.Contains("") ? 1u : 0u) != (uint)0)
                {
                    string username = text;
                    switch (Panel.vmType)
                    {
                        case 1:
                            AliExpressVM.getRequests(username);
                            break;
                        case 2:
                            AmazonVM.postRequests(username);
                            break;
                        case 3:
                            AppleVM.postRequests(username);
                            break;
                        case 4:
                            BookingVM.postRequests(username);
                            break;
                        case 5:
                            DeezerVM.postRequests(username);
                            break;
                        case 6:
                            DeliverooVM.postRequest(username);
                            break;
                        case 7:
                            LdlcVM.postRequests(username);
                            break;
                        case 8:
                            NetflixVM.postRequest(username);
                            break;
                        case 9:
                            PornhubVM.postRequests(username);
                            break;
                        case 10:
                            SpotifyVM.getRequests(username);
                            break;
                        case 11:
                            UberVM.postRequests(username);
                            break;
                        case 12:
                            WordpressVM.postRequests(username);
                            break;
                    }
                    switch (Panel.vnType)
                    {
                        case 1:
                            UberVN.postRequests(username);
                            break;
                        case 2:
                            AmazonVN.postRequests(username);
                            break;
                    }
                }
                else
                {
                    Program.deadCnt++;
                }
                Program.checkedCnt++;
            }
        }
        public static void threadStart()
        {
            for (int i = 0; i < Program.threads; i++)
            {
                new Thread(new ThreadStart(Module.moduleGet)).Start();
            }
        }
    }
}
