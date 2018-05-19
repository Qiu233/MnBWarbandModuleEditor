using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_MapIcons
	{
		public ModuleInfo Module;
		public List<MapIcon> MapIcons;

		public static F_MapIcons LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_MapIcons obj = new F_MapIcons();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\map_icons.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}

		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "map_icons_file version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			MapIcons = new List<MapIcon>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < MapIcons.Capacity; i++)
			{
				var mi = MapIcon.FromString(Module, s, ref j);
				MapIcons.Add(mi);
			}
		}
	}
}
