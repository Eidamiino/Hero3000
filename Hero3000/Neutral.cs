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

		public Neutral(string name, int maxhp):base(name,maxhp)
		{
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
