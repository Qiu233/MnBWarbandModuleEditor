using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer.Entities
{
	/// <summary>
	/// 指出指令参数的类型
	/// 表来自模组"Native"的源码
	/// </summary>
	public enum ParamType : int
	{
		Register = 1,
		Variable = 2,
		String = 3,
		Item = 4,
		Troop = 5,
		Faction = 6,
		Quest = 7,
		Party_Tpl = 8,
		Party = 9,
		Scene = 10,
		Mission_Tpl = 11,
		Menu = 12,
		Script = 13,
		Particle_Sys = 14,
		Scene_Prop = 15,
		Sound = 16,
		Local_Variable = 17,
		Map_Icon = 18,
		Skill = 19,
		Mesh = 20,
		Presentation = 21,
		Quick_String = 22,
		Track = 23,
		Tableau = 24,
		Animation = 25,
		End = 26,
	}

	/// <summary>
	/// 骑砍使用一个大于32+24位的数据来保存指令的参数
	/// 其中低32+24位保存的数据是Index
	/// 比32+24位更高的位置储存类型
	/// 在用来做测试的版本(1.168)中，整个数据只有60位，也就是只有最高四位用来保存类型
	/// </summary>
	public class Param
	{
		public ParamType Type;
		public long Value;
		private Param()
		{

		}
		public static Param FromString(string s)
		{
			Param p = new Param();
			long l = Convert.ToInt64(s);
			long tag = l >> 56;
			if ((tag | 0x00) != 0)
			{
				p.Type = (ParamType)tag;
			}
			else
			{
				long a = 0xFF_FFFF_FFFF_FFFF;
				p.Value = a & l;
			}
			return p;
		}
	}

	/// <summary>
	/// 骑砍储存一条语句的结构是：
	/// opcode paramlength params....
	/// 其中opcode为操作码
	/// paramlength指出这条指令共有多少个参数
	/// 而后的params就是指令的参数表
	/// 此结构多次叠加，再在头部加上语句数量便可组成语句块
	/// 有特例，即neg和this_or_next，指令本身就是由参数和指令标识组成的
	/// </summary>
	public class Statement
	{
		public long Opcode;
		public List<Param> Params;
		private Statement()
		{

		}
		/// <summary>
		/// 可能会加载到neg或者this_or_next，这两条指令的参数在指令的低七位，而最高位标识了是neg还是this_or_next
		/// </summary>
		/// <param name="s"></param>
		/// <param name="j"></param>
		/// <returns></returns>
		public static Statement FromString(string[] s, ref int j)
		{
			Statement stmt = new Statement();
			stmt.Opcode = Convert.ToInt64(s[j++]);
			int m = Convert.ToInt32(s[j++]);
			stmt.Params = new List<Param>(m);
			for (int i = 0; i < m; i++)
			{
				stmt.Params.Add(Param.FromString(s[j++]));
			}
			return stmt;
		}
	}
}
