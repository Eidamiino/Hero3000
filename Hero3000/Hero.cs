using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Hero3000
{
	public class Hero:FighterBase
	{
		public const int CriticalChance = 5;
		public const int CriticalMultiplier = 2;
		public const double DamageReturned = 0.25;
		public const int PhysicaldefCooldown= 1000;
		public const int MagicaldefCooldown = 1000;

		private Defense physicaldef;
		private Defense magicaldef;
		private Attack physicalatt;
		private Attack magicalatt;
		public Hero(string name, int maxhp, Constants.Class classtype, int physicalatt, int magicalatt, int physicaldef, int magicaldef):base(name, maxhp, physicalatt, magicalatt, physicaldef, magicaldef)
		{
			ClassType = classtype;
			this.physicaldef = new Defense(Constants.Type.Physical, physicaldef, PhysicaldefCooldown);
			this.magicaldef = new Defense(Constants.Type.Magical, magicaldef, MagicaldefCooldown);
			this.physicalatt = new Attack("Punch", Constants.Type.Physical, physicalatt);
			this.magicalatt = new Attack("Fireball", Constants.Type.Magical, magicalatt);
		}
		public Constants.Class ClassType { get; private set; }

		#region Attacking

		public void Attack(FighterBase whom, Stopwatch stopwatch)
		{
			int attackType = Helpers.GetRandom(0, 2);
			int currDmg, currDefense, currDefCooldown;
			string currAtt;

			currAtt = GetAttackType(whom, attackType, out currDmg, out currDefense, out currDefCooldown);
			int dealtDamage = currDmg - Convert.ToInt32(currDefense);

			PrintAttackInfo(whom, currAtt, currDefense,  currDmg);

			dealtDamage = CriticalAttack(dealtDamage);
			whom.DecreaseHealth(dealtDamage);
			ReturnAttack(stopwatch, currDefCooldown, dealtDamage);
		}

		private string GetAttackType(FighterBase whom, int attackType, out int currDmg, out int currDefense, out int currDefCooldown)
		{
			string currAtt;
			if (attackType == 0)
			{
				currAtt = PhysicalAtt.Attname;
				currDmg = PhysicalAtt.Basedmg;
				currDefense = whom.PhysicalDef.Basedef;
				currDefCooldown = whom.PhysicalDef.Cooldown;
			}
			else
			{
				currAtt = MagicalAtt.Attname;
				currDmg = MagicalAtt.Basedmg;
				currDefense = whom.MagicalDef.Basedef;
				currDefCooldown = whom.MagicalDef.Cooldown;
			}
			return currAtt;
		}

		private static int CriticalAttack(int dealtDamage)
		{
			int critical = Helpers.GetRandom(1, 101);
			if (critical <= CriticalChance)
			{
				Console.WriteLine($"Critical attack! The DMG has been amplified {CriticalMultiplier}x!");
				dealtDamage *= CriticalMultiplier;
			}

			return dealtDamage;
		}
		public void ReturnAttack(Stopwatch stopwatch, int currDefCooldown, int dealtDamage)
		{
			if (Convert.ToInt32(stopwatch.ElapsedMilliseconds) <= currDefCooldown) return;
			Console.WriteLine($"{DamageReturned * 100}% damage was sent back!");
			Currenthp -= Convert.ToInt32(dealtDamage * DamageReturned);
			stopwatch.Reset();
			stopwatch.Start();
		}

		#endregion

		#region Printing

		private void PrintAttackInfo(FighterBase whom, string currAtt, int currDefense, int currDmg)
		{
			Console.WriteLine($"{Name} has attacked {whom.Name} with {currAtt}, dealing {currDmg}DMG!");
			Console.WriteLine($"{whom.Name} has resisted {Convert.ToInt32(currDefense)}DMG!");
		}

		public static void PrintStats(Hero hero)
		{
			Console.WriteLine($"Fighter: {hero.Name}\t{hero.ClassType}\t{hero.MaxHp}HP\t{hero.physicalatt.Basedmg}DMG\t{hero.magicalatt.Basedmg}mDMG\t{hero.physicaldef.Basedef}DEF\t{hero.magicaldef.Basedef}mDEF\n");
		}

		#endregion
		public static bool DeathCheck(Hero hero)
		{
			return hero.Currenthp <= 0;
		}
	}
}
