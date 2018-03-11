using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Party
	{
		public ModuleInfo Module;
		public int Index;
		public string Iden;
		public string NameEn;
		public string Name;
		public BigInteger Flags;
		public Menu Menu;
		public int PartyTemplate;
		public Faction Faction;
		public int Personality;//不知道有什么用的属性
		public int AI_Behavior;
		public int AI_Target;
		public float InitialCoordinateX, InitialCoordinateY;
		public List<Tuple<int, int, BigInteger>> Members;
		public float Bearing;
		private Party()
		{

		}
		public static Party FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Party party = new Party();
			party.Module = mInfo;
			int _n1 = Convert.ToInt32(s[j++]);//暂不知其意义
			party.Index = Convert.ToInt32(s[j++]);
			j++;
			party.Iden = s[j++];
			party.Iden = party.Iden.Substring(party.Iden.IndexOf("_") + 1);
			party.NameEn = s[j++];
			if (mInfo.F_Language["parties"].ContainsKey(party.Iden))
				party.Name = mInfo.F_Language["parties"][party.Iden];
			party.Flags = BigInteger.Parse(s[j++]);
			party.Menu = mInfo.F_Menus.Menus[Convert.ToInt32(s[j++])];
			party.PartyTemplate = Convert.ToInt32(s[j++]);
			party.Faction = mInfo.F_Factions.Factions[Convert.ToInt32(s[j++])];
			party.Personality = Convert.ToInt32(s[j++]);
			j++;
			party.AI_Behavior = Convert.ToInt32(s[j++]);
			party.AI_Target = Convert.ToInt32(s[j++]);
			j++;
			party.InitialCoordinateX = Convert.ToSingle(s[j++]);
			party.InitialCoordinateY = Convert.ToSingle(s[j++]);
			j += 4;
			float z = Convert.ToSingle(s[j++]);//暂不知意义
			party.Members = new List<Tuple<int, int, BigInteger>>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < party.Members.Capacity; i++)
			{
				Tuple<int, int, BigInteger> v;
				int a = Convert.ToInt32(s[j++]);
				int b = Convert.ToInt32(s[j++]);
				int c = Convert.ToInt32(s[j++]);//暂不知意义
				BigInteger d = BigInteger.Parse(s[j++]);

				v = new Tuple<int, int, BigInteger>(a, b, d);
				party.Members.Add(v);
			}
			party.Bearing = Convert.ToSingle(s[j++]);
			return party;
		}
	}
}
