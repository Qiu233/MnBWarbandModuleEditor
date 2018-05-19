using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Animations
	{
		public ModuleInfo Module;
		public List<Entities.Action> Actions;

		public static F_Animations LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Animations obj = new F_Animations();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\actions.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}

		private void FromStream(StreamReader reader)
		{
			Actions = new List<Entities.Action>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Actions.Capacity; i++)
			{
				var an = Entities.Action.FromString(Module, s, ref j);
				Actions.Add(an);
			}
		}
	}
}
