using System;
using System.Collections.Generic;
using System.Text;

namespace Hero3000
{
	internal class Helpers
	{
		public const int minMaxHP = 350;
		public const int maxMaxHP = 501;

		public static int GetRandom(int min, int max)
		{
			Random rand = new Random();
			int randNum = rand.Next(min, max);
			return randNum;
		}
		public static void PrintHPStatus(Hero first, Hero second)
		{
			Console.WriteLine($"{first.name} has {first.Currenthp}HP\t{second.name} has {second.Currenthp}HP\n");
		}
		public static Hero GenerateHero(string name, Program.Class heroClass)
		{
			int maxhp = GetRandom(minMaxHP, maxMaxHP), physicalatt, magicalatt, physicaldef, magicaldef;
			switch (heroClass)
			{
				case Program.Class.Fighter:
					physicalatt = GetRandom(50, 100);
					magicalatt = GetRandom(25, 40);
					physicaldef = GetRandom(10, 20);
					magicaldef = GetRandom(8, 15);
					break;
				case Program.Class.Wizard:
					physicalatt = GetRandom(25, 40);
					magicalatt = GetRandom(50, 100);
					physicaldef =GetRandom(8, 15);
					magicaldef = GetRandom(10, 20);
					break;
				default:
					physicalatt = GetRandom(37, 70);
					magicalatt = GetRandom(37, 70);
					physicaldef = GetRandom(9, 17);
					magicaldef = GetRandom(9, 17);
					break;
			}
			return new Hero(name, maxhp, heroClass, physicalatt, magicalatt, physicaldef, magicaldef);
		}
	}
}
