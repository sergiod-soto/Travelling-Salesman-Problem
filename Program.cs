using System;

namespace Travelling_Salesman_Problem
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] text = CSVParser.readMapGraph(@"G:\Portfolio\Algoritmos\Problema del viajante\Travelling Salesman Problem\CSV\map.csv");
			string[] nodes = CSVParser.parseLine(text[0]); // nodes' names

			int[][] weightMatrix = new int[text.Length - 1][];
			for (int i = 0; i < text.Length - 1; i++)
			{
				string[] row = CSVParser.parseLine(text[i]);
				for (int j = 0; j < text.Length - 1; j++)
				{
					try
					{
						int parsedWeight = Int32.Parse(row[j + 1]);
						weightMatrix[i][j] = parsedWeight;
					}
					catch (FormatException)
					{
						Console.WriteLine($"Format error on CSV, line: {i}");
						return;
					}

				}
			}
		}
	}
}
