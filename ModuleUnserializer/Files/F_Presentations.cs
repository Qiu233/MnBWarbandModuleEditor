using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Presentations
	{
		public ModuleInfo Module;
		public List<Presentation> Presentations;

		public static F_Presentations LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Presentations obj = new F_Presentations();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\presentations.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}

		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "presentationsfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Presentations = new List<Presentation>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Presentations.Capacity; i++)
			{
				var ps = Presentation.FromString(Module, s, ref j);
				Presentations.Add(ps);
			}
		}
	}
}
