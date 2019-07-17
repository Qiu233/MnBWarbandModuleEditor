using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Troop
	{
		public const int NUM_WEAPON_PROFICIENCIES = 7;
		public const int NUM_SKILL_WORDS = 6;
		public const int NUM_FACE_NUMERIC_KEYS = 4;
		public ModuleInfo Module;
		public string Index;
		public string NameEn;
		public string NameEn_Pl;
		public string Name;
		public BigInteger Flags;
		public int Scene;//还未实现
		public int Reserved;
		public Faction Faction;
		public List<KeyValuePair<int, int>> Inventory;
		public long Strength;
		public long Agility;
		public long Intelligence;
		public long Charisma;
		public long Starting_Level;

		public int WP_One_Handed;
		public int WP_Two_Handed;
		public int WP_Polearm;
		public int WP_Archery;
		public int WP_Crossbow;
		public int WP_Throwing;
		public int WP_Firearm;

		public BigInteger Skills;

		public BigInteger FaceKey1;
		public BigInteger FaceKey2;
		private Troop()
		{

		}
		public static Troop FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Troop trp = new Troop();
			trp.Index = s[j++];
			trp.Index = trp.Index.Substring(trp.Index.IndexOf("_") + 1);
			trp.NameEn = s[j++];
			trp.NameEn_Pl = s[j++];
			if (mInfo.F_Language["troops"].ContainsKey(trp.Index))
				trp.Name = mInfo.F_Language["troops"][trp.Index];
			j++;//暂不知意义
			trp.Flags = BigInteger.Parse(s[j++]);
			trp.Scene = Convert.ToInt32(s[j++]);
			trp.Reserved = Convert.ToInt32(s[j++]);
			trp.Faction = mInfo.F_Factions.Factions[Convert.ToInt32(s[j++])];
			j += 2;//暂不知意义
			trp.Inventory = new List<KeyValuePair<int, int>>(64);
			for (int i = 0; i < trp.Inventory.Capacity; i++)
			{
				KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(Convert.ToInt32(s[j++]), Convert.ToInt32(s[j++]));
				trp.Inventory.Add(kvp);
			}
			trp.Strength = Convert.ToInt64(s[j++]);
			trp.Agility = Convert.ToInt64(s[j++]);
			trp.Intelligence = Convert.ToInt64(s[j++]);
			trp.Charisma = Convert.ToInt64(s[j++]);
			trp.Starting_Level = Convert.ToInt64(s[j++]);

			trp.WP_One_Handed = Convert.ToInt32(s[j++]);
			trp.WP_Two_Handed = Convert.ToInt32(s[j++]);
			trp.WP_Polearm = Convert.ToInt32(s[j++]);
			trp.WP_Archery = Convert.ToInt32(s[j++]);
			trp.WP_Crossbow = Convert.ToInt32(s[j++]);
			trp.WP_Throwing = Convert.ToInt32(s[j++]);
			trp.WP_Firearm = Convert.ToInt32(s[j++]);

			for (int i = 0; i < NUM_SKILL_WORDS; i++)
			{
				var v = BigInteger.Parse(s[j++]);
				v <<= i * 32;
				trp.Skills |= v;
			}

			for (int i = 0; i < NUM_FACE_NUMERIC_KEYS; i++)
			{
				var v = BigInteger.Parse(s[j++]);
				v <<= i * 64;
				trp.FaceKey1 |= v;
			}
			for (int i = 0; i < NUM_FACE_NUMERIC_KEYS; i++)
			{
				var v = BigInteger.Parse(s[j++]);
				v <<= i * 64;
				trp.FaceKey2 |= v;
			}


			return trp;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
}
