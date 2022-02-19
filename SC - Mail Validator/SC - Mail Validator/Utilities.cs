using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Threading;

namespace SC___Mail_Validator
{
    public class Utilities
    {
        public static void printLogo()
        {
            string logo = @"

    ________     _________   ______  ___      _____________    __      ___________________      _____              
    __  ___/     __  ____/   ___   |/  /_____ ___(_)__  /_ |  / /_____ ___  /__(_)_____  /_____ __  /______________
    _____ \_______  /        __  /|_/ /_  __ `/_  /__  /__ | / /_  __ `/_  /__  /_  __  /_  __ `/  __/  __ \_  ___/
    ____/ //_____/ /___      _  /  / / / /_/ /_  / _  / __ |/ / / /_/ /_  / _  / / /_/ / / /_/ // /_ / /_/ /  /    
    /____/       \____/      /_/  /_/  \__,_/ /_/  /_/  _____/  \__,_/ /_/  /_/  \__,_/  \__,_/ \__/ \____//_/     
                                                                                                               
";
            Colorful.Console.WriteLine(logo + "\n", System.Drawing.Color.Blue);
            string s = "[Strike X CLocket]";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop); ;
            Colorful.Console.WriteLine(s, Color.AntiqueWhite);
            Console.WriteLine("\n");
        }
        public static void time()
        {
            DateTime dateTime = default(DateTime);
            Program.startDateTime = DateTime.Now.ToString("MM.dd.yyyy H.mm");
            string startDateTime = Program.startDateTime;
            if (startDateTime == null)
            {
            }
            if ((((Directory.Exists(startDateTime) ? 1u : 0u) == (uint)0) ? 1u : 0u) != (uint)0)
            {
                Directory.CreateDirectory(Program.startDateTime);
            }
        }
        public static void invalidChoose()
        {
            Colorful.Console.WriteLine("[Select a Valid Options]", Color.Red);
            Thread.Sleep(1500);
            Console.Clear();
        }
        public static void saveHits(string username)
        {
            Program.hitCnt++;
            Console.Title = "[" + name + "] - [+] [Valids : " + Program.hitCnt + "] | [+] [Invalids : " + Program.deadCnt + "] | [+] [Free : " + Program.freeCnt + "] | [Checkeds : " + Program.checkedCnt + "/" + Program.comboCount + "] | [Errors : " + Program.retryCnt + "] - [+] - [Strike x CLocket]";
            Colorful.Console.WriteLine("[+" + name + "+] [" + username + "] - [Valids]", System.Drawing.Color.Green);
            using (FileStream file = new FileStream(Program.startDateTime + @"\Valids" + name + ".txt", FileMode.Append, FileAccess.Write, FileShare.Read))

            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine(username);
            }
        }
        public static void saveFail(string username)
        {
            Program.deadCnt++;
            Console.Title = "[" + name + "] - [+] [Valids : " + Program.hitCnt + "] | [+] [Invalids : " + Program.deadCnt + "] | [+] [Free : " + Program.freeCnt + "] | [Checkeds : " + Program.checkedCnt + "/" + Program.comboCount + "] | [Errors : " + Program.retryCnt + "] - [+] - [Strike x CLocket]";
            Colorful.Console.WriteLine("[+" + name + "+] [" + username + "] - [Invalids]", System.Drawing.Color.Red);
            using (FileStream file = new FileStream(Program.startDateTime + @"\Inalids" + name + ".txt", FileMode.Append, FileAccess.Write, FileShare.Read))

            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine(username);
            }
        }
        public static void saveFree(string username)
        {
            Program.freeCnt++;
            Console.Title = "[" + name + "] - [+] [Valids : " + Program.hitCnt + "] | [+] [Invalids : " + Program.deadCnt + "] | [+] [Free : " + Program.freeCnt + "] | [Checkeds : " + Program.checkedCnt + "/" + Program.comboCount + "] | [Errors : " + Program.retryCnt + "] - [+] - [Strike x CLocket]";
            Colorful.Console.WriteLine("[+" + name + "+] [" + username + "] - [Free]", System.Drawing.Color.Orange);
            using (FileStream file = new FileStream(Program.startDateTime + @"\Free" + name + ".txt", FileMode.Append, FileAccess.Write, FileShare.Read))

            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine(username);
            }
        }
        public static void catchRetry()
        {
            Program.retryCnt++;
            Console.Title = "[" + name + "] - [+] [Valids : " + Program.hitCnt + "] | [+] [Invalids : " + Program.deadCnt + "] | [+] [Free : " + Program.freeCnt + "] | [Checkeds : " + Program.checkedCnt + "/" + Program.comboCount + "] | [Errors : " + Program.retryCnt + "] - [+] - [Strike x CLocket]";
        }
        public static string name;
    }
}