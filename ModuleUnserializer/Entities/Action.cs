using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Action
	{
		public string Index;
		public long Flags;
		public long MasterFlags;
		public List<Animation> Animations;
		private Action()
		{

		}
		public static Action FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Action mi = new Action();
			mi.Index = s[j++];
			mi.Flags = Convert.ToInt64(s[j++]);
			mi.MasterFlags = Convert.ToInt64(s[j++]);
			mi.Animations = new List<Animation>(Convert.ToInt32(s[j++]));
			for (int i = 0; i < mi.Animations.Capacity; i++)
				mi.Animations.Add(Animation.FromString(mInfo, s, ref j));
			return mi;
		}
	}
	public class Animation
	{
		public float Duration;
		public string Name;
		public int BeginningFrame;
		public int EndingFrame;
		public long Flags;
		public long _Unknown1;
		public float _Unknown2;
		public float _Unknown3;
		public float _Unknown4;
		public float _Unknown5;
		private Animation()
		{

		}
		public static Animation FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Animation a = new Animation();
			a.Duration = Convert.ToSingle(s[j++]);
			a.Name = s[j++];
			a.BeginningFrame = Convert.ToInt32(s[j++]);
			a.EndingFrame = Convert.ToInt32(s[j++]);
			a.Flags = Convert.ToInt64(s[j++]);
			a._Unknown1 = Convert.ToInt64(s[j++]);
			a._Unknown2 = Convert.ToSingle(s[j++]);
			a._Unknown3 = Convert.ToSingle(s[j++]);
			a._Unknown4 = Convert.ToSingle(s[j++]);
			a._Unknown5 = Convert.ToSingle(s[j++]);
			return a;
		}
	}
}
