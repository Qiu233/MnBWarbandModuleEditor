using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Tableau_Mats
	{
		public ModuleInfo Module;
		public List<Tableau> Tableau_Mats;

		public static F_Tableau_Mats LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Tableau_Mats obj = new F_Tableau_Mats();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\tableau_materials.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}

		private void FromStream(StreamReader reader)
		{
			Tableau_Mats = new List<Tableau>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Tableau_Mats.Capacity; i++)
			{
				var script = Tableau.FromString(Module, s, ref j);
				Tableau_Mats.Add(script);
			}
		}
	}
}
