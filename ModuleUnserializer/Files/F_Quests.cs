using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Quests
	{
		public ModuleInfo Module;
		public List<Quest> Quests;
		private F_Quests()
		{

		}
		public static F_Quests LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Quests obj = new F_Quests();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\quests.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "questsfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Quests = new List<Quest>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Quests.Capacity; i++)
			{
				var qst = Quest.FromString(Module, s, ref j);
				Quests.Add(qst);
			}
		}
	}
}
