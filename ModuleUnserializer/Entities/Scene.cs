using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Scene
	{
		public ModuleInfo Module;
		public string Index;
		public BigInteger Flags;
		public string MeshName;
		public string BodyName;
		public KeyValuePair<float, float> MinPos;
		public KeyValuePair<float, float> MaxPos;
		public float WaterLevel;
		public string TerrainCode;
		public string Scene_Outer_Terrain;

		public List<int> Passages;
		public List<Troop> ChestTroops;

		public static Scene FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Scene scn = new Scene();

			scn.Index = s[j++];
			scn.Index = scn.Index.Substring(scn.Index.IndexOf("_") + 1);
			j++;
			scn.Flags = BigInteger.Parse(s[j++]);
			scn.MeshName = s[j++];
			scn.BodyName = s[j++];
			scn.MinPos = new KeyValuePair<float, float>(Convert.ToSingle(s[j++]), Convert.ToSingle(s[j++]));
			scn.MaxPos = new KeyValuePair<float, float>(Convert.ToSingle(s[j++]), Convert.ToSingle(s[j++]));
			scn.WaterLevel = Convert.ToSingle(s[j++]);
			scn.TerrainCode = s[j++];

			scn.Passages = new List<int>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < scn.Passages.Capacity; i++)
				scn.Passages.Add(Convert.ToInt32(s[j++]));
			
			scn.ChestTroops = new List<Troop>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < scn.ChestTroops.Capacity; i++)
				scn.ChestTroops.Add(mInfo.F_Troops.Troops[Convert.ToInt32(s[j++])]);

			scn.Scene_Outer_Terrain = s[j++];

			return scn;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
}
