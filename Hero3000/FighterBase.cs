using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hero3000
{
	public abstract class FighterBase
	{
		public FighterBase(string name, int maxhp, int physicalatt=0, int magicalatt=0, int physicaldef=0, int magicaldef=0)
		{
			Name = name;
			MaxHp = maxhp;
			Currenthp = maxhp;
			PhysicalAtt = physicalatt;
			MagicalAtt= magicalatt;
			PhysicalDef = physicaldef;
			MagicalDef = magicaldef;
		}
		public string Name { get; protected set; } = "TestingEntity";
		public int MaxHp { get; protected set; } = 100;
		public int PhysicalAtt { get; protected set; }
		public int MagicalAtt { get; protected set; }
		public int PhysicalDef { get; protected set; }
		public int MagicalDef { get; protected set; }

		private int currenthp;
		public int Currenthp
		{
			get { return currenthp; }
			protected set
			{
				if (value > MaxHp)
				{
					Console.WriteLine("blbečku");
				}
				else
				{
					currenthp = value;
				}
			}
		}
		public abstract void Attack(Hero oponnent, Stopwatch stopwatch);
	}
}
