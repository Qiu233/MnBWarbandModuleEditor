using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Scripts
	{
		public ModuleInfo Module;
		public List<Script> Scripts;

		public static F_Scripts LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Scripts obj = new F_Scripts();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\scripts.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}

		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "scriptsfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Scripts = new List<Script>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Scripts.Capacity; i++)
			{
				var script = Script.FromString(Module, s, ref j);
				Scripts.Add(script);
			}
		}
	}
}
