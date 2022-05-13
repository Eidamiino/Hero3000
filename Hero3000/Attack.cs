using System;
using System.Collections.Generic;
using System.Text;

namespace Hero3000
{
	public class Attack
	{
		public string attname;
		public Program.Type type;

		public Attack(string attname, Program.Type type, int basedmg)
		{
			this.attname = attname;
			this.type = type;
			Basedmg = basedmg;
		}
		public int Basedmg { get; private set; }
	}
}
