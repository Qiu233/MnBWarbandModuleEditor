using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Factions
	{
		public ModuleInfo Module;
		public List<Faction> Factions;
		private F_Factions()
		{

		}
		public static F_Factions LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Factions obj = new F_Factions();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\factions.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "factionsfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Factions = new List<Faction>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Factions.Capacity; i++)
			{
				var faction = Faction.FromString(Module, s, ref j, Factions.Capacity);
				Factions.Add(faction);
			}
		}
	}
}
