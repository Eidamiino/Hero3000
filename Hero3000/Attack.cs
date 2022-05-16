using System;
using System.Collections.Generic;
using System.Text;

namespace Hero3000
{
	public class Attack
	{
		public string Attname { get; private set; }
		public int Basedmg { get; private set; }
		public Constants.Type Type { get; private set; }
		public Attack(string attname, Constants.Type type, int basedmg)
		{
			Attname = attname;
			Type = type;
			Basedmg = basedmg;
		}
	}
}
