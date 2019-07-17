using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleUnserializer
{
	public class CompilationContext
	{
		public List<string> Variables
		{
			get;
		}
		public List<string> Tags
		{
			get;
		}
		public List<string> QuickStrings
		{
			get;
		}
		private CompilationContext()
		{
			Variables = new List<string>();
			Tags = new List<string>();
			QuickStrings = new List<string>();
		}
		public static CompilationContext Create()
		{
			return new CompilationContext();
		}
		public int GetVariable(string name)
		{
			if (Variables.Contains(name))
				return Variables.IndexOf(name);
			Variables.Add(name);
			return Variables.Count - 1;
		}
	}
}
