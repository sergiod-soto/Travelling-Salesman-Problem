using System;

namespace Travelling_Salesman_Problem
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] text = CSVParser.readMapGraph(@"G:\Portfolio\Algoritmos\Problema del viajante\Travelling Salesman Problem\CSV\map.csv");
			string[] nodesLine = CSVParser.parseLine(text[0]);

			string[] nodes = new string[nodesLine.Length - 1];
			Array.Copy(nodesLine, nodes, 1);     // nodes' names

			int[][] weightMatrix = new int[text.Length - 1][];
			for (int i = 0; i < text.Length - 1; i++)
			{
				string[] row = CSVParser.parseLine(text[i + 1]);
				for (int j = 0; j < nodes.Length; j++)
				{
					try
					{
						weightMatrix[i][j] = Int32.Parse(row[j + 1]);
					}
					catch (FormatException)
					{
						Console.WriteLine($"Format error on CSV, line: {i}");
						return;
					}

				}
			}
			for (int i = 0; i < weightMatrix.Length; i++)
			{
				Console.WriteLine("\ni: " + i);
				for (int j = 0; j < weightMatrix[i].Length; j++)
				{
					Console.Write(weightMatrix[i][j]);
				}
			}
		}
	}
}
