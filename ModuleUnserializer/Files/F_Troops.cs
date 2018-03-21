using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Troops
	{
		public ModuleInfo Module;
		public List<Troop> Troops;
		private F_Troops()
		{

		}
		public static F_Troops LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Troops obj = new F_Troops();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\troops.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "troopsfile version 2")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Troops = new List<Troop>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Troops.Capacity; i++)
			{
				var str = Troop.FromString(Module, s, ref j);
				Troops.Add(str);
			}
		}
	}
}
