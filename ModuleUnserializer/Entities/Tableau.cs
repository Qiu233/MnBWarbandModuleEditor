using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Tableau
	{
		public string Index;
		public long Flags;
		public string MatName;
		public int Width;
		public int Height;

		public int MinX;
		public int MinY;

		public int MaxX;
		public int MaxY;
		public Statement_Block Statements;
		private Tableau()
		{

		}
		public static Tableau FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Tableau tab = new Tableau();
			tab.Index = s[j++];
			tab.Index = tab.Index.Substring(tab.Index.IndexOf("_") + 1);
			tab.Flags = Convert.ToInt64(s[j++]);
			tab.MatName = s[j++];

			tab.Width = Convert.ToInt32(s[j++]);
			tab.Height = Convert.ToInt32(s[j++]);

			tab.MinX = Convert.ToInt32(s[j++]);
			tab.MinY = Convert.ToInt32(s[j++]);

			tab.MaxX = Convert.ToInt32(s[j++]);
			tab.MaxY = Convert.ToInt32(s[j++]);
			tab.Statements = Statement_Block.FromString(mInfo, s, ref j);
			return tab;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
}
