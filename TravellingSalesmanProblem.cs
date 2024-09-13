using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_Salesman_Problem
{
	class TravellingSalesmanProblem
	{
		public Map map;
		Map.Node mainNode;

		public TravellingSalesmanProblem(string mapRoute, string mainNodeName)
		{
			string[] text = CSVParser.readMapGraph(mapRoute);

			string[] nodesLine = CSVParser.parseLine(text[0]);
			string[] nodes = nodesLine.Skip(1).ToArray();

			// 
			int[][] weightMatrix = new int[text.Length - 1][];
			for (int i = 0; i < text.Length - 1; i++)
			{
				string[] row = CSVParser.parseLine(text[i + 1]);
				int[] matrixRow = new int[row.Length - 1];
				for (int j = 0; j < nodes.Length; j++)
				{
					try
					{
						matrixRow[j] = Int32.Parse(row[j + 1]);
					}
					catch (FormatException)
					{
						Console.WriteLine($"Format error on CSV, line: {i}");
						return;
					}

				}
				weightMatrix[i] = matrixRow;
			}
			map = new Map(nodes, weightMatrix);
			mainNode = map.nodes[mainNodeName];
		}

		public string[] solve()
		{
			return solve(map, mainNode);
		}

		public string[] solve(Map map, Map.Node mainNode)
		{
			return null;
		}
	}
}
