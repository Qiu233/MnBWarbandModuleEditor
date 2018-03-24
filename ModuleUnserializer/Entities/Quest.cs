using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Quest
	{
		public ModuleInfo Module;
		public string Index;
		public string Name;
		public BigInteger Flags;
		public string Description;
		private Quest()
		{

		}
		public static Quest FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Quest qst = new Quest();

			qst.Index = s[j++];
			qst.Index = qst.Index.Substring(qst.Index.IndexOf("_") + 1);
			qst.Name = s[j++];
			qst.Flags = BigInteger.Parse(s[j++]);
			qst.Description = s[j++].Replace('_', ' ');

			return qst;
		}
	}
}
