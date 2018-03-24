using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Scenes
	{
		public ModuleInfo Module;
		public List<Scene> Scenes;
		private F_Scenes()
		{

		}
		public static F_Scenes LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Scenes obj = new F_Scenes();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\scenes.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "scenesfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Scenes = new List<Scene>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Scenes.Capacity; i++)
			{
				var scn = Scene.FromString(Module, s, ref j);
				Scenes.Add(scn);
			}
		}
	}
}
