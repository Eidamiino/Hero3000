using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hero3000
{
	public class Neutral : FighterBase
	{
		public const int ReturnChanceMin = 10;
		public const int ReturnChanceMax = 85;
		public const double DamageReturned = 0.35;

		public string name;
		private int currenthp;
		public Neutral(string name, int maxhp)
		{
			this.name = name;
			Maxhp = maxhp;
			Currenthp = maxhp;

		}
		public int Maxhp { get; private set; }
		public int Currenthp
		{
			get { return currenthp; }
			private set
			{
				if (value > Maxhp)
				{
					Console.WriteLine("blbečku");
				}
				else
				{
					currenthp = value;
				}
			}
		}

		public override void Attack(Hero whom, Stopwatch stopwatch)
		{
			int returnAtt = Helpers.GetRandom(0, 101);
			if (returnAtt <= GetReturnChance())
			{
				//whom.Currenthp-=whom.
			}
		}

		public int GetReturnChance()
		{
			var returnChance = Helpers.GetRandom(ReturnChanceMin, ReturnChanceMax);
			return returnChance;
		}
	}
}
