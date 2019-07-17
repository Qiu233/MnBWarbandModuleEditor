using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class MenuItem
	{

		public ModuleInfo Module;
		public string Name;
		public Statement_Block Condition;
		public string Label;
		public Statement_Block Action;
		public string DoorName;

		private MenuItem()
		{

		}
		public static MenuItem FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			MenuItem party = new MenuItem();
			party.Name = s[j++];
			party.Condition = Statement_Block.FromString(mInfo, s, ref j);
			party.Label = s[j++];
			party.Action = Statement_Block.FromString(mInfo, s, ref j);
			party.DoorName = s[j++];
			return party;
		}
	}
	public class Menu
	{

		public ModuleInfo Module;
		public string Index;
		public BigInteger Flags;
		public string TextEn;
		public string Text;
		public string Mesh;
		public Statement_Block Statements;
		public List<MenuItem> MenuItems;
		private Menu()
		{

		}
		public static Menu FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Menu party = new Menu();
			party.Module = mInfo;
			party.Index = s[j++];
			party.Index = party.Index.Substring(party.Index.IndexOf("_") + 1);
			party.Flags = BigInteger.Parse(s[j++]);
			party.TextEn = s[j++];
			if (mInfo.F_Language["game_menus"].ContainsKey(party.Index))
				party.Text = mInfo.F_Language["game_menus"][party.Index];
			party.Mesh = s[j++];
			party.Statements = Statement_Block.FromString(mInfo, s, ref j);
			party.MenuItems = new List<MenuItem>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < party.MenuItems.Capacity; i++)
				party.MenuItems.Add(MenuItem.FromString(mInfo, s, ref j));
			return party;
		}

		public string Compile(CompilationContext ctx)
		{
			throw new NotImplementedException();
		}
	}
}
