using System;
using System.Collections.Generic;
using System.Text;

namespace Hero3000
{
	public class Attack
	{
		public string attname;

		public Attack(string attname, Program.Type type, int basedmg)
		{
			this.attname = attname;
			Type = type;
			Basedmg = basedmg;
		}
		public int Basedmg { get; private set; }
		public Program.Type Type { get; private set; }
	}
}
