using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using Hero3000.Constants;

namespace Hero3000
{
	public class Program
	{
		public const int minCooldown = 250;
		public const int maxCooldown = 500;
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
			int heroAmount = heroes.Count;

			Hero first = heroes[random.Next(0,heroAmount)];
			Hero second = heroes[random.Next(0,heroAmount)];
			while (first.Name == second.Name)
			{
				second = heroes[random.Next(0, heroAmount)];
			}
			Hero.PrintStats(first);
			Hero.PrintStats(second);
			Fight(first, second);
		}
		static void Fight(Hero first, Hero second)
		{
			Stopwatch stopwatchFirst = new Stopwatch();
			stopwatchFirst.Start();
			Stopwatch stopwatchSecond = new Stopwatch();
			stopwatchSecond.Start();

			while (IsEveryoneAlive(first, second))
			{
				first.Attack(second, stopwatchSecond);

				Helpers.PrintHPStatus(first, second);
				Thread.Sleep(Helpers.GetRandom(minCooldown, maxCooldown));
				if (Hero.DeathCheck(second))
				{
					Console.WriteLine($"{second.Name} has died! {first.Name} won the battle!");
					break;
				}
				second.Attack(first, stopwatchFirst);
				Helpers.PrintHPStatus(first, second);
				Thread.Sleep(Helpers.GetRandom(minCooldown, maxCooldown));
				if (Hero.DeathCheck(first))
				{
					Console.WriteLine($"{first.Name} has died! {second.Name} won the battle!");
					break;
				}
			}
		}

		private static bool IsEveryoneAlive(Hero first, Hero second)
		{
			return first.Currenthp > 0 && second.Currenthp > 0;
		}
	}

}

