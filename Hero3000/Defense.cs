using System;
using System.Collections.Generic;
using System.Text;

namespace Hero3000
{
	public class Defense
	{
		private Program.Type type;

		public Defense(Program.Type type, int basedef, int cooldown)
		{
			this.type = type;
			Basedef = basedef;
			Cooldown = cooldown;
		}
		public int Basedef { get; set; }
		public int Cooldown { get; set; }
	}
}
