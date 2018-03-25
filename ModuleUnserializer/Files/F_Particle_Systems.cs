using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Particle_Systems
	{
		public ModuleInfo Module;
		public List<Particle_System> Particle_Systems;
		private F_Particle_Systems()
		{

		}
		public static F_Particle_Systems LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Particle_Systems obj = new F_Particle_Systems();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\particle_systems.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "particle_systemsfile version 1")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Particle_Systems = new List<Particle_System>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Particle_Systems.Capacity; i++)
			{
				var ptc = Particle_System.FromString(Module, s, ref j);
				Particle_Systems.Add(ptc);
			}
		}
	}
}
