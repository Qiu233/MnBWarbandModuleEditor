using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Mesh
	{
		public string Index;
		public long Flags;
		public string ResourceName;
		public float TranslationX;
		public float TranslationY;
		public float TranslationZ;

		public float RotationX;
		public float RotationY;
		public float RotationZ;

		public float ScaleX;
		public float ScaleY;
		public float ScaleZ;

		private Mesh()
		{

		}
		public static Mesh FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Mesh msh = new Mesh();
			msh.Index = s[j++];
			msh.Index = msh.Index.Substring(msh.Index.IndexOf("_") + 1);
			msh.Flags = Convert.ToInt64(s[j++]);
			msh.ResourceName = s[j++];
			msh.TranslationX = Convert.ToSingle(s[j++]);
			msh.TranslationY = Convert.ToSingle(s[j++]);
			msh.TranslationZ = Convert.ToSingle(s[j++]);

			msh.RotationX = Convert.ToSingle(s[j++]);
			msh.RotationY = Convert.ToSingle(s[j++]);
			msh.RotationZ = Convert.ToSingle(s[j++]);

			msh.ScaleX = Convert.ToSingle(s[j++]);
			msh.ScaleY = Convert.ToSingle(s[j++]);
			msh.ScaleZ = Convert.ToSingle(s[j++]);

			return msh;
		}
	}
}
