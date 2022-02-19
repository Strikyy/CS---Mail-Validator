using System;
using System.Drawing;

namespace SC___Mail_Validator
{
    class Panel
    {
        public static void selectPanel()
        {
            try
            {
                Console.Clear();
                Utilities.printLogo();
                Colorful.Console.WriteLine("[Select Options]\n", Color.AntiqueWhite);
                Colorful.Console.WriteLine("[1] - [Mail Checker]\n[2] - [Phone Checker]\n[3] - [Utilities]", Color.DarkBlue);
                moduleType = Convert.ToInt32(Colorful.Console.ReadLine());
                switch (moduleType)
                {
                    case < 1:
                        Utilities.invalidChoose();
                        selectPanel();
                        break;
                    case > 3:
                        Utilities.invalidChoose();
                        selectPanel();
                        break;
                    case 1:
                        selectVM();
                        break;
                    case 2:
                        selectVN();
                        break;
                    case 3:

                        break;
                }
            }
            catch (Exception)
            {
                Utilities.invalidChoose();
                selectPanel();
            }
        }

        public static void selectVM()
        {
            try
            {
                Console.Clear();
                Utilities.printLogo();
                Colorful.Console.WriteLine("[Select Options]\n", Color.AntiqueWhite);
                Colorful.Console.WriteLine("[1] - [AliExpress]\n[2] - [Amazon]\n[3] - [Apple]\n[4] - [Booking]\n[5] - [Deezer]\n[6] - [Deliveroo]\n[7] - [LDLC]\n[8] - [Netflix]\n[9] - [Pornhub]\n[10] - [Spotify]\n[11] - [Uber]\n[12] - [WordPress]\n[13] - [Disney+]\n[14] - [Paypal]\n\n[15] - [Back]", Color.DarkBlue);
                vmType = Convert.ToInt32(Colorful.Console.ReadLine());
                switch (vmType)
                {
                    case < 1:
                        Utilities.invalidChoose();
                        selectVM();
                        break;
                    case > 15:
                        Utilities.invalidChoose();
                        selectVM();
                        break;
                    case 15:
                        selectPanel();
                        break;
                    case 13:
                        DisneyVM.getToken();
                        Module.threadStart();
                        break;
                    default:
                        Console.Clear();
                        Module.threadStart();
                        break;
                }
            }
            catch (Exception)
            {
                Utilities.invalidChoose();
                selectVM();
            }
        }
        public static void selectVN()
        {
            try
            {
                Console.Clear();
                Utilities.printLogo();
                Colorful.Console.WriteLine("[Select Options]\n", Color.AntiqueWhite);
                Colorful.Console.WriteLine("[1] - [Uber]\n[2] - [Amazon]\n\n[3] - [Back]", Color.DarkBlue);
                vnType = Convert.ToInt32(Colorful.Console.ReadLine());
                switch (vnType)
                {
                    case < 1:
                        Utilities.invalidChoose();
                        selectVM();
                        break;
                    case > 3:
                        Utilities.invalidChoose();
                        selectVM();
                        break;
                    case 3:
                        selectPanel();
                        break;
                    default:
                        Console.Clear();
                        Module.threadStart();
                        break;
                }
            }
            catch (Exception)
            {
                Utilities.invalidChoose();
                selectVM();
            }
        }
        public static int moduleType;
        public static int vmType;
        public static int vnType;
    }
}
