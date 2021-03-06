using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hero3000
{
	public abstract class FighterBase
	{
		public FighterBase(string name, int maxhp, int physicalatt, int magicalatt, int physicaldef, int magicaldef)
		{
			Name = name;
			MaxHp = maxhp;
			Currenthp=maxhp;
			PhysicalAtt = new Attack("Punch", Constants.Type.Physical, physicalatt);
			MagicalAtt= new Attack("Fireball", Constants.Type.Magical, magicalatt);
			PhysicalDef = new Defense(Constants.Type.Physical, physicaldef, 1000);
			MagicalDef = new Defense(Constants.Type.Magical, magicaldef, 1000);
		}
		public string Name { get; protected set; } = "TestingEntity";
		public int MaxHp { get; protected set; } = 100;
		public int Currenthp { get; set; } = 100;
		public Attack PhysicalAtt { get; protected set; }
		public Attack MagicalAtt { get; protected set; }
		public Defense PhysicalDef { get; protected set; }
		public Defense MagicalDef { get; protected set; }
		public virtual void DecreaseHealth(int damage)
		{
			Currenthp -= damage;
		}
	}
}
