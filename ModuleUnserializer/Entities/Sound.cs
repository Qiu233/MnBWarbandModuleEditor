using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Sound
	{
		public ModuleInfo Module;
		public string Index;
		public BigInteger Flags;
		public List<KeyValuePair<int, int>> Files;//一：number 二：暂不知其作用
		private Sound()
		{

		}
		public static Sound FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Sound snd = new Sound();

			snd.Index = s[j++];
			snd.Index = snd.Index.Substring(snd.Index.IndexOf("_") + 1);

			snd.Flags = BigInteger.Parse(s[j++]);

			snd.Files = new List<KeyValuePair<int, int>>(Convert.ToInt32(s[j++]));

			for (int i = 0; i < snd.Files.Capacity; i++)
			{
				snd.Files.Add(new KeyValuePair<int, int>(Convert.ToInt32(s[j++]), Convert.ToInt32(s[j++])));
			}

			return snd;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
}
