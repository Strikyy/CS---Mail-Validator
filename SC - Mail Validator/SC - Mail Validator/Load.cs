using System;
using System.Drawing;
using System.Threading;
using System.IO;

namespace SC___Mail_Validator
{
    class Load
    {
		public static bool loadCombos()
		{
			Thread.Sleep(800);
			Colorful.Console.Clear();
			Utilities.printLogo();
			bool result;
			try
			{
				string s = "[Drag your Mail/Phone file]";
				Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop); ;
				Colorful.Console.WriteLine(s, Color.AntiqueWhite);
				Console.WriteLine("\n");
				using (Stream stream = new FileStream(Colorful.Console.ReadLine().Replace("\"", ""), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (Stream stream2 = new BufferedStream(stream))
					{
						using (TextReader textReader = new StreamReader(stream2))
						{
							for (; ; )
							{
								string text = textReader.ReadLine();
								if (text == null)
								{
									break;
								}
								Program.mailList.Add(text);
							}
							if ((((uint)Program.mailList.Count > (uint)0) ? 1u : 0u) != (uint)0)
							{
								Colorful.Console.WriteLine(string.Format("[Loaded {0} Mail/Phone]", Program.mailList.Count), Color.DarkBlue);
								Program.comboCount = Program.mailList.Count;
								result = true;
							}
							else
							{
								Colorful.Console.WriteLine("Empty File.", Color.Crimson);
								result = false;
							}
						}
					}
				}
			}
			catch
			{
				Colorful.Console.Clear();
				Colorful.Console.WriteLine("Error Loading.", Color.Crimson);
				result = false;
			}
			return result;
		}
		public static bool loadProxies()
		{
			Thread.Sleep(1500);
			Colorful.Console.Clear();
			Utilities.printLogo();
			bool result;
			try
			{
				string s = "[Drag your Proxies file]";
				Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop); ;
				Colorful.Console.WriteLine(s, Color.AntiqueWhite);
				Console.WriteLine("\n");
				using (Stream stream = new FileStream(Colorful.Console.ReadLine().Replace("\"", ""), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (Stream stream2 = new BufferedStream(stream))
					{
						using (TextReader textReader = new StreamReader(stream2))
						{
							for (; ; )
							{
								string text = textReader.ReadLine();
								if (text == null)
								{
									break;
								}
								Program.PROXIES.Add(text);
							}
							if ((((uint)Program.PROXIES.Count > (uint)0) ? 1u : 0u) != (uint)0)
							{
								Colorful.Console.WriteLine(string.Format("Loaded {0} Proxies.", Program.PROXIES.Count), Color.DarkBlue);
								result = true;
							}
							else
							{
								Colorful.Console.WriteLine("Empty File.", Color.Crimson);
								result = false;
							}
						}
					}
				}
			}
			catch
			{
				Colorful.Console.Clear();
				Colorful.Console.WriteLine("Error Loading.", Color.Crimson);
				result = false;
			}
			return result;
		}
		public static void proxySelect()
		{
			Thread.Sleep(1500);
			Colorful.Console.Clear();
			Utilities.printLogo();
			try
			{
				Colorful.Console.WriteLine("Select Proxy Type:", Color.AntiqueWhite);
				Colorful.Console.WriteLine("[0] | PROXYLESS", Color.DarkBlue);
				Colorful.Console.WriteLine("[1] | HTTPS", Color.DarkBlue);
				Colorful.Console.WriteLine("[2] | SOCKS4", Color.DarkBlue);
				Colorful.Console.WriteLine("[3] | SOCKS5", Color.DarkBlue);
				Program.proxyType = Convert.ToInt32(Colorful.Console.ReadLine());
				uint num;
				if ((((uint)Program.proxyType < (uint)0) ? 1u : 0u) == (uint)0)
				{
					num = (((uint)Program.proxyType > (uint)3) ? 1u : 0u);
				}
				else
				{
					num = (uint)1;
				}
				if (num != (uint)0)
				{
					Colorful.Console.Clear();
					Utilities.printLogo();
					Load.proxySelect();
				}
			}
			catch
			{
				Colorful.Console.Clear();
				Utilities.printLogo();
				Load.proxySelect();
			}
		}
		public static void getThreads()
		{
			Thread.Sleep(1500);
			Colorful.Console.Clear();
			Utilities.printLogo();
			try
			{
				Colorful.Console.WriteLine("Thread Count ? Max 300", Color.AntiqueWhite);
				Program.threads = Convert.ToInt32(Colorful.Console.ReadLine());
				if ((((((uint)Program.threads > (uint)0) ? 1u : 0u) == (uint)0) ? 1u : 0u) != (uint)0)
				{
					Load.getThreads();
				}
				if (Program.threads > 301)
				{
					Colorful.Console.Clear();
					Utilities.printLogo();
					Colorful.Console.WriteLine("Enter a correct number of threads", Color.Crimson);
					Thread.Sleep(1200);
					Colorful.Console.Clear();
					Utilities.printLogo();
					Colorful.Console.WriteLine("Thread Count ? Max 300", Color.AntiqueWhite);
				}
			}
			catch
			{
				Load.getThreads();
			}
		}
	}
}
