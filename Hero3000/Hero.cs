using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Hero3000
{
	public class Hero
	{
		public const int criticalChance = 5;
		public const int criticalMultiplier = 2;
		public const double damageReturned = 0.25;
		public const int physicaldefCooldown= 1000;
		public const int magicaldefCooldown = 1000;

		public string name;
		private int currenthp;
		private Defense physicaldef;
		private Defense magicaldef;
		private Attack physicalatt;
		private Attack magicalatt;
		public Hero(string name, int maxhp, Program.Class classtype, int physicalatt, int magicalatt, int physicaldef, int magicaldef)
		{
			this.name = name;
			ClassType = classtype;
			Maxhp = maxhp;
			Currenthp = maxhp;
			this.physicaldef = new Defense(Program.Type.Physical, physicaldef, physicaldefCooldown);
			this.magicaldef = new Defense(Program.Type.Magical, magicaldef, magicaldefCooldown);
			this.physicalatt = new Attack("Punch", Program.Type.Physical, physicalatt);
			this.magicalatt = new Attack("Fireball", Program.Type.Magical, magicalatt);
		}
		public Program.Class ClassType { get; private set; }
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

		#region Attacking

		public void Attack(Hero whom, Stopwatch stopwatch)
		{
			int attackType = Helpers.GetRandom(0, 2);
			int critical = Helpers.GetRandom(1, 101);
			int currDmg, currDefense, currDefCooldown;
			string currAtt;
			if (attackType == 0)
			{
				currAtt = physicalatt.attname;
				currDmg = physicalatt.Basedmg;
				currDefense = whom.physicaldef.Basedef;
				currDefCooldown = whom.physicaldef.Cooldown;
			}
			else
			{
				currAtt = magicalatt.attname;
				currDmg = magicalatt.Basedmg;
				currDefense = whom.magicaldef.Basedef;
				currDefCooldown = whom.magicaldef.Cooldown;
			}
			int dealtDamage = currDmg - Convert.ToInt32(currDefense);

			PrintAttackInfo(whom, currAtt, currDefense,  currDmg);

			dealtDamage = CriticalAttack(critical, dealtDamage);
			whom.Currenthp -= dealtDamage;

			ReturnAttack(stopwatch, currDefCooldown, dealtDamage);
		}

		private void ReturnAttack(Stopwatch stopwatch, int currDefCooldown, int dealtDamage)
		{
			if (Convert.ToInt32(stopwatch.ElapsedMilliseconds) > currDefCooldown)
			{
				Console.WriteLine($"{damageReturned * 100}% damage was sent back!");
				Currenthp -= Convert.ToInt32(dealtDamage * damageReturned);
				stopwatch.Reset();
			}
		}

		private static int CriticalAttack(int critical, int dealtDamage)
		{
			if (critical <= criticalChance)
			{
				Console.WriteLine($"Critical attack! The DMG has been amplified {criticalMultiplier}x!");
				dealtDamage *= criticalMultiplier;
			}

			return dealtDamage;
		}

		#endregion

		#region Printing

		private void PrintAttackInfo(Hero whom, string currAtt, int currDefense, int currDmg)
		{
			Console.WriteLine($"{name} has attacked {whom.name} with {currAtt}, dealing {currDmg}DMG!");
			Console.WriteLine($"{whom.name} has resisted {Convert.ToInt32(currDefense)}DMG!");
		}

		public static void PrintStats(Hero hero)
		{
			Console.WriteLine($"Fighter: {hero.name}\t{hero.ClassType}\t{hero.Maxhp}HP\t{hero.physicalatt.Basedmg}DMG\t{hero.magicalatt.Basedmg}mDMG\t{hero.physicaldef.Basedef}DEF\t{hero.magicaldef.Basedef}mDEF\n");
		}

		#endregion
		public static bool DeathCheck(Hero hero)
		{
			if (hero.Currenthp <= 0) return true;
			return false;
		}

	}
}
