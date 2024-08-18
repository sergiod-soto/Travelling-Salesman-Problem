using System;

namespace Travelling_Salesman_Problem
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] text = CSVParser.readMapGraph(@"G:\Portfolio\Algoritmos\Problema del viajante\Travelling Salesman Problem\CSV\map.csv");
			Console.WriteLine("linea 0");
			Console.WriteLine(text[0]);
			Console.WriteLine("\nlinea 1");
			Console.WriteLine(text[1] + "\n");
			string[] lineas = CSVParser.parseLine(text[1]);
			for (int i = 0; i < lineas.Length; i++)
			{
				Console.WriteLine(lineas[i]);
			}
		}
	}
}
