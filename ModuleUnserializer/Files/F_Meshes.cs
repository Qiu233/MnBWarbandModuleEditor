using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Meshes
	{
		public ModuleInfo Module;

		public List<Mesh> Meshes;
		private F_Meshes()
		{

		}
		public static F_Meshes LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Meshes obj = new F_Meshes();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\meshes.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			Meshes = new List<Mesh>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Meshes.Capacity; i++)
			{
				Mesh m = Mesh.FromString(Module, s, ref j);
				Meshes.Add(m);
			}
		}
	}
}
