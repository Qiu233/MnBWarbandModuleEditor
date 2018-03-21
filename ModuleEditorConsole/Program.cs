using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModuleEditorConsole
{
	class Program
	{
		static string INIFile = "./MnBEditorConsole.ini";
		static string MnBPath;
		static string Language;
		static string Module;
		static ModuleInfo ModuleInfo;
		static event Action<string[]> OnCommand;
		static void Main(string[] args)
		{
			ModuleCheck();
			ModuleInfo = new ModuleInfo(MnBPath, Module, Language);
			Console.WriteLine("Module已读入......");
			OnCommand += Handler_OnCommand;
			while (true)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n>>>");
				Console.ForegroundColor = ConsoleColor.White;
				string[] command = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				OnCommand?.Invoke(command);
			}

		}

		private static void Decompile()
		{
			if (!Directory.Exists(".\\" + Module)) Directory.CreateDirectory(".\\" + Module);
			foreach (var f in Directory.EnumerateFiles(".\\" + Module))
				File.Delete(f);
			var scriptFile = File.Open(".\\" + Module + "\\module_scripts.py", FileMode.OpenOrCreate);
			StreamWriter sw = new StreamWriter(scriptFile);
			StringBuilder s = new StringBuilder("script=[\n");
			foreach (var m in ModuleInfo.F_Scripts.Scripts)
				s.Append(m.Decompile() + "\n");
			s.Append("]\n");
			sw.Write(s);
			sw.Close();
		}

		/// <summary>
		/// 处理指令
		/// </summary>
		/// <param name="cmd">包括了指令的操作码，参数的字符串数组</param>
		private static void Handler_OnCommand(string[] cmd)
		{
			if (cmd.Length <= 0)
				return;
			string opCode = cmd[0].ToLower();
			switch (opCode)
			{
				case "decompile":
					Decompile();
					break;
				case "quit":
				case "exit":
				case "close":
					Console.WriteLine("1s后程序结束......");
					Thread.Sleep(1000);
					Environment.Exit(0);
					break;
				case "item":
					Handler_Cmd_Item(cmd);
					break;
				case "script":
					Handler_Cmd_Script(cmd);
					break;
				default:
					Console.WriteLine("没有这样的指令");
					break;
			}
		}

		/// <summary>
		/// 处理script类指令
		/// </summary>
		/// <param name="cmd">指令</param>
		private static void Handler_Cmd_Script(string[] cmd)
		{
			if (cmd.Length <= 1)
				return;
			switch (cmd[1].Trim().ToLower())
			{
				case "list":
					{
						for (int i = 0; i < ModuleInfo.F_Scripts.Scripts.Count; i++)
							Console.WriteLine(i + ".\t" + ModuleInfo.F_Scripts.Scripts[i].Name);
					}
					break;
				case "code":
					{
						if (cmd.Length <= 2)
						{
							Console.WriteLine("参数不足");
							break;
						}
						var script = ModuleInfo.F_Scripts.Scripts[Convert.ToInt32(cmd[2])];
						Console.WriteLine(script.Decompile());
					}

					break;
				default:
					break;
			}
		}


		/// <summary>
		/// 处理item类指令
		/// </summary>
		/// <param name="cmd">指令</param>
		private static void Handler_Cmd_Item(string[] cmd)
		{
			if (cmd.Length <= 1)
				return;
			switch (cmd[1].Trim().ToLower())
			{
				case "list":
					for (int i = 0; i < ModuleInfo.F_Items.Items.Count; i++)
						Console.WriteLine(i + ".\t" + ModuleInfo.F_Items.Items[i].Index);
					break;
				default:
					break;
			}
		}



		/// <summary>
		/// 检查游戏位置，mod名称和语言
		/// </summary>
		static void ModuleCheck()
		{
			MnBPath = INI.ReadIniKeys("MnB", "PATH", INIFile);
			while (MnBPath == null || MnBPath.Trim() == "")
			{
				Console.WriteLine("请输入游戏根目录:");
				string path = Console.ReadLine();
				if (!Directory.Exists(path))
				{
					Console.WriteLine("路径不存在");
					continue;
				}
				MnBPath = path;
				INI.WriteIniKeys("MnB", "Path", MnBPath, INIFile);
			}
			Module = INI.ReadIniKeys("MnB", "Module", INIFile);
			if (Module == null || Module.Trim() == "")
			{
				var Modules = Directory.EnumerateDirectories(MnBPath + "\\Modules\\").ToList();
				int i = 0;
				Modules.ForEach(e => Console.WriteLine(i++ + ".\t" + Path.GetFileNameWithoutExtension(e)));
				Console.WriteLine("请选择mod:");
				Module = Modules[Convert.ToInt32(Console.ReadLine())];
				INI.WriteIniKeys("MnB", "Module", Path.GetFileNameWithoutExtension(Module), INIFile);
			}
			Language = INI.ReadIniKeys("MnB", "Language", INIFile);
			while (Language == null || Language.Trim() == "")
			{
				Console.WriteLine("请选择语言:");
				string language = Console.ReadLine();
				if (!Directory.Exists(MnBPath + "\\Modules\\" + Module + "\\Languages\\" + language))
				{
					Console.WriteLine("该语言不存在");
					continue;
				}
				Language = language;
				INI.WriteIniKeys("MnB", "Language", Language, INIFile);
			}
			Console.WriteLine("配置信息已处理完毕......");
			Thread.Sleep(1000);
			Console.Clear();
		}
	}
}
