using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Skills
	{
		public ModuleInfo Module;
		public List<Skill> Skills;

		public static F_Skills LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Skills obj = new F_Skills();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\skills.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}

		private void FromStream(StreamReader reader)
		{
			Skills = new List<Skill>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Skills.Capacity; i++)
			{
				var sk = Skill.FromString(Module, s, ref j);
				Skills.Add(sk);
			}
		}
	}
}
