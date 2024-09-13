using System;

namespace Travelling_Salesman_Problem
{
	class Program
	{
		static void Main(string[] args)
		{
			TravellingSalesmanProblem tsp = new TravellingSalesmanProblem(
				@"G:\Portfolio\Algoritmos\Problema del viajante\Travelling Salesman Problem\CSV\map.csv",
				"Ampuero");
			tsp.map.Print("Map 1:");
		}
	}
}
