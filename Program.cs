using System;
using static Travelling_Salesman_Problem.TravellingSalesmanProblem;

namespace Travelling_Salesman_Problem
{
	class Program
	{
		static void Main(string[] args)
		{
			TravellingSalesmanProblem tsp = new TravellingSalesmanProblem();

			tsp.setMap(@"G:\Portfolio\Algorithms\Travelling Salesman Problem\CSV\map.csv");
			tsp.setMainNode("Ampuero");

			tsp.map.Print();

			Solution solution = tsp.Solve();
			solution.Print();
		}
	}
}
