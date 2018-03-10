using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Menus
	{
		public ModuleInfo Module;
		public List<Menu> Menus;
		private F_Menus()
		{

		}
		public static F_Menus LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Menus obj = new F_Menus();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\menus.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "menusfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Menus = new List<Menu>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Menus.Capacity; i++)
			{
				var menu = Menu.FromString(Module, s, ref j);
				Menus.Add(menu);
			}
		}
	}
}
