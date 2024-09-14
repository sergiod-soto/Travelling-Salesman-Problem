using System;

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

			//string[] solution = tsp.solve();


		}
	}
}
