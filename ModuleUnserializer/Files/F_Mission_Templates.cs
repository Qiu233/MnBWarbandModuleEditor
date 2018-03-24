using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Mission_Templates
	{
		public ModuleInfo Module;
		public List<Mission_Template> Mission_Templates;
		private F_Mission_Templates()
		{

		}
		public static F_Mission_Templates LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Mission_Templates obj = new F_Mission_Templates();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\mission_templates.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "missionsfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Mission_Templates = new List<Mission_Template>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Mission_Templates.Capacity; i++)
			{
				var scn = Mission_Template.FromString(Module, s, ref j);
				Mission_Templates.Add(scn);
			}
		}
	}
}
