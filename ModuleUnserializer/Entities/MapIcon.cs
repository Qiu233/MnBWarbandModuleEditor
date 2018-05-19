using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class MapIcon
	{
		public string Index;
		public long Flags;
		public string MeshName;
		public float Scale;
		public int Sound;
		public float OffsetX;
		public float OffsetY;
		public float OffsetZ;
		public List<SimpleTrigger> Triggers;
		private MapIcon()
		{

		}
		public static MapIcon FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			MapIcon mi = new MapIcon();
			mi.Index = s[j++];
			mi.Index = mi.Index.Substring(mi.Index.IndexOf("_") + 1);
			mi.Flags = Convert.ToInt64(s[j++]);
			mi.MeshName = s[j++];
			mi.Scale = Convert.ToSingle(s[j++]);
			mi.Sound = Convert.ToInt32(s[j++]);
			mi.OffsetX = Convert.ToSingle(s[j++]);
			mi.OffsetY = Convert.ToSingle(s[j++]);
			mi.OffsetZ = Convert.ToSingle(s[j++]);
			mi.Triggers = new List<SimpleTrigger>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < mi.Triggers.Capacity; i++)
				mi.Triggers.Add(SimpleTrigger.FromString(mInfo, s, ref j));
			return mi;
		}
	}
}
