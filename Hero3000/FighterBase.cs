using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hero3000
{
	public abstract class FighterBase
	{
		public FighterBase(string name, int maxhp)
		{
			Name = name;
			MaxHp = maxhp;
			Currenthp = maxhp;
			PhysicalAtt = new Attack("Punch", Constants.Type.Physical, 0);
			MagicalAtt= new Attack("Fireball", Constants.Type.Magical, 0);
			PhysicalDef = new Defense(Constants.Type.Physical, 0, 0);
			MagicalDef = new Defense(Constants.Type.Magical, 0, 0);
		}
		public string Name { get; protected set; } = "TestingEntity";
		public int MaxHp { get; protected set; } = 100;
		public Attack PhysicalAtt { get; protected set; }
		public Attack MagicalAtt { get; protected set; }
		public Defense PhysicalDef { get; protected set; }
		public Defense MagicalDef { get; protected set; }

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
