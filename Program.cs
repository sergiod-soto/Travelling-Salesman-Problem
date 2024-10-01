using System;
using System.Diagnostics;
using static Travelling_Salesman_Problem.TravellingSalesmanProblem;

namespace Travelling_Salesman_Problem
{
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();
			int numOfTries = 10;

			TravellingSalesmanProblem tsp = new TravellingSalesmanProblem();

			tsp.setMap(@"G:\Portfolio\Algorithms\Travelling Salesman Problem\CSV\map.csv");
			tsp.setMainNode("Ampuero");

			tsp.map.Print();

			Solution solution = null;
			long totalTime = 0;
			for (int i = 0; i < numOfTries; i++)
			{
				sw.Start();
				solution = tsp.Solve(Solution.SolvingMethods.NearestN_Solver);
				sw.Stop();
				totalTime += sw.ElapsedMilliseconds;
			}

			if (solution != null)
			{
				solution.Print();
				Console.WriteLine($"Time elapsed: {sw.ElapsedMilliseconds / numOfTries}ms on ({numOfTries} tries) average");
			}
		}
	}
}
