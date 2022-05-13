using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Hero3000
{
	public class Program
	{
		public enum Class { Wizard, Fighter, Pussy }
		public enum Type { Physical, Magical }

		public const int minCooldown = 500;
		public const int maxCooldown = 2000;
		public static List<Hero> heroes = new List<Hero>();
		static void Main(string[] args)
		{
			Random random = new Random();
			heroes.Add(Helpers.GenerateHero("Ondra", Class.Wizard));
			heroes.Add(Helpers.GenerateHero("Albert", Class.Fighter));
			heroes.Add(Helpers.GenerateHero("Filip", Class.Wizard));
			heroes.Add(Helpers.GenerateHero("Honza", Class.Pussy));
			heroes.Add(Helpers.GenerateHero("AdamH", Class.Fighter));
			heroes.Add(Helpers.GenerateHero("AdamK", Class.Pussy));
			heroes.Add(Helpers.GenerateHero("AdamP", Class.Wizard));
			heroes.Add(Helpers.GenerateHero("Matej", Class.Pussy));
			heroes.Add(Helpers.GenerateHero("Mirek", Class.Fighter));
			heroes.Add(Helpers.GenerateHero("Radek", Class.Pussy));

			int heroAmount = heroes.Count;

			Hero first = heroes[random.Next(0,heroAmount)];
			Hero second = heroes[random.Next(0,heroAmount)];
			while (first.name == second.name)
			{
				second = heroes[random.Next(0, heroAmount)];
			}
			Hero.PrintStats(first);
			Hero.PrintStats(second);
			Fight(first, second);
		}
		static void Fight(Hero first, Hero second)
		{
			while (first.Currenthp > 0 && second.Currenthp > 0)
			{
				Stopwatch stopWatch1 = new Stopwatch();
				stopWatch1.Start();
				Stopwatch stopWatch2 = new Stopwatch();
				stopWatch2.Start();

				first.Attack(second, stopWatch1);
				Helpers.PrintHPStatus(first, second);
				Thread.Sleep(Helpers.GetRandom(minCooldown, maxCooldown));
				if (Hero.DeathCheck(second))
				{
					Console.WriteLine($"{second.name} has died! {first.name} won the battle!");
					break;
				}


				second.Attack(first, stopWatch2);
				Helpers.PrintHPStatus(first, second);
				Thread.Sleep(Helpers.GetRandom(minCooldown, maxCooldown));
				if (Hero.DeathCheck(first))
				{
					Console.WriteLine($"{first.name} has died! {second.name} won the battle!");
					break;
				}
			}
		}
	}

}

