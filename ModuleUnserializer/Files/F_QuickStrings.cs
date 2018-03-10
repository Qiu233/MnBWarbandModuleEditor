using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_QuickStrings
	{
		public ModuleInfo Module;
		public List<QuickString> QuickStrings;

		private F_QuickStrings()
		{

		}
		public static F_QuickStrings LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_QuickStrings obj = new F_QuickStrings();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\quick_strings.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			QuickStrings = new List<QuickString>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < QuickStrings.Capacity; i++)
			{
				var qs = QuickString.FromString(Module, s, ref j);
				QuickStrings.Add(qs);
			}
		}
	}
}
