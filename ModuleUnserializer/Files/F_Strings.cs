using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Strings
	{
		public ModuleInfo Module;
		public List<MnBString> Strings;
		private F_Strings()
		{

		}
		public static F_Strings LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Strings obj = new F_Strings();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\strings.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "stringsfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Strings = new List<MnBString>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Strings.Capacity; i++)
			{
				var str = MnBString.FromString(Module, s, ref j);
				Strings.Add(str);
			}
		}
	}
}
