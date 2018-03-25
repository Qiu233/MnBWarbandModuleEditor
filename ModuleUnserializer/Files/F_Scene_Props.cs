using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Scene_Props
	{
		public ModuleInfo Module;
		public List<Scene_Prop> Scene_Props;
		private F_Scene_Props()
		{

		}
		public static F_Scene_Props LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Scene_Props obj = new F_Scene_Props();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\scene_props.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "scene_propsfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Scene_Props = new List<Scene_Prop>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Scene_Props.Capacity; i++)
			{
				var spr = Scene_Prop.FromString(Module, s, ref j);
				Scene_Props.Add(spr);
			}
		}
	}
}
