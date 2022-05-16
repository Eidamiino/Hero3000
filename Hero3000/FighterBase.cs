using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hero3000
{
	public abstract class FighterBase
	{
		public string Name { get; protected set; } = "TestingEntity";
		public int CurrentHp { get; set; } = 100;
		public int MaxHp { get; protected set; } = 100;
		public abstract void Attack(Hero oponnent, Stopwatch stopwatch);

	}
}
