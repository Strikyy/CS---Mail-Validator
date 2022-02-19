using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SC___Mail_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities.time();
            Load.loadCombos();
            Load.proxySelect();
            if(Program.proxyType == 0)
            {
                Load.getThreads();
                Panel.selectPanel();
            }
            else
            {
                Load.loadProxies();
                Load.getThreads();
                Panel.selectPanel();
            }
            Console.ReadKey();
        }
        static Program()
        {
            Program.mailList = new BlockingCollection<string>();
            Program.PROXIES = new List<string>();
            Program.startDateTime = "";

        }
        public static BlockingCollection<string> mailList;
        public static List<string> PROXIES;
        public static int comboCount;
        public static string proxies;
        public static int proxyType;
        public static int threads;
        public static int hitCnt;
        public static int freeCnt;
        public static int deadCnt;
        public static int checkedCnt;
        public static int retryCnt;
        public static string startDateTime;
    }
}
