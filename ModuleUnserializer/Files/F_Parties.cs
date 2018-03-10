using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Parties
	{
		public ModuleInfo Module;
		public List<Party> Parties;
		private F_Parties()
		{

		}
		public static F_Parties LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Parties obj = new F_Parties();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\parties.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "partiesfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			Parties = new List<Party>(Convert.ToInt32(s[j++]));
			j++;
			for (int i = 0; i < Parties.Capacity; i++)
			{
				var faction = Party.FromString(Module, s, ref j);
				Parties.Add(faction);
			}
		}
	}
}
