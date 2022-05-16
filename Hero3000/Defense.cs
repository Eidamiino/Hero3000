using System;
using System.Collections.Generic;
using System.Text;

namespace Hero3000
{
	public class Defense
	{
		public int Basedef { get; private set; }
		public int Cooldown { get; private set; }
		public Constants.Type Type { get; private set; }
		public Defense(Constants.Type type, int basedef, int cooldown)
		{
			Type = type;
			Basedef = basedef;
			Cooldown = cooldown;
		}
	}
}
