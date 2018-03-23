using ModuleUnserializer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Files
{
	public class F_Sounds
	{
		public ModuleInfo Module;
		public List<SoundSample> Samples;
		public List<Sound> Sounds;
		private F_Sounds()
		{

		}
		public static F_Sounds LoadFromFile(ModuleInfo minfo, string MnBPath, string module)
		{
			F_Sounds obj = new F_Sounds();
			obj.Module = minfo;
			StreamReader reader = new StreamReader(File.Open(MnBPath + "\\modules\\" + module + "\\sounds.txt", FileMode.Open));
			obj.FromStream(reader);

			reader.Close();
			return obj;
		}
		private void FromStream(StreamReader reader)
		{
			if (reader.ReadLine() != "soundsfile version 3")
				throw new Exception("可能不支持当前mod或该mod已损坏");
			Samples = new List<SoundSample>(Convert.ToInt32(reader.ReadLine()));
			string[] s = reader.ReadToEnd().Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
			int j = 0;
			for (int i = 0; i < Samples.Capacity; i++)
			{
				var smp = SoundSample.FromString(Module, s, ref j);
				Samples.Add(smp);
			}
			Sounds = new List<Sound>(Convert.ToInt32(reader.ReadLine()));
			for (int i = 0; i < Sounds.Capacity; i++)
			{
				var snd = Sound.FromString(Module, s, ref j);
				Sounds.Add(snd);
			}
		}
	}
}
