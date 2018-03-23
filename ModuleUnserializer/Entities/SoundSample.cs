using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class SoundSample
	{
		public ModuleInfo Module;
		public string File;
		public BigInteger Flags;
		private SoundSample()
		{

		}
		public static SoundSample FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			SoundSample snd = new SoundSample();

			snd.File = s[j++];
			snd.Flags = BigInteger.Parse(s[j++]);

			return snd;
		}
	}
}
