using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Scene_Prop
	{
		public ModuleInfo Module;
		public string Index;
		public BigInteger Flags;
		public int HitPoints;
		public string MeshName;
		public string PhyisicsObjectName;
		public List<SimpleTrigger> Triggers;

		private Scene_Prop()
		{

		}
		public static Scene_Prop FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Scene_Prop sp = new Scene_Prop();
			sp.Module = mInfo;
			sp.Index = s[j++];
			sp.Index = sp.Index.Substring(sp.Index.IndexOf("_") + 1);
			sp.Flags = BigInteger.Parse(s[j++]);
			sp.HitPoints = Convert.ToInt32(s[j++]);
			sp.MeshName = s[j++];
			sp.PhyisicsObjectName = s[j++];
			sp.Triggers = new List<SimpleTrigger>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < sp.Triggers.Capacity; i++)
				sp.Triggers.Add(SimpleTrigger.FromString(mInfo, s, ref j));
			return sp;
		}
	}
}
