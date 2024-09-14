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
		string[] text;
		Solution solution;





		public TravellingSalesmanProblem() { }

		class Solution
		{
			public string[] path;
			public int weight;

			public Solution(string[] path, int weight)
			{
				this.path = path;
				this.weight = weight;
			}
			public void print()
			{
				// capitalize first letter
				for (int i = 0; i < path.Length; i++)
				{
					path[i] = path[i].ToLower();
					path[i] = char.ToUpper(path[i][0]) + path[i].Substring(1);
				}

				Console.Write("Best route found:\n\n└──>");
				for (int i = 0; i < path.Length - 1; i++)
				{
					Console.Write(path[i] + " -> ");
				}
				Console.Write(path[path.Length - 1]);
			}
		}

		public string[] solve()
		{
			if (map == null ||
				text == null)
			{
				Console.WriteLine("Error. Be sure to configure parameters before solving.");
				return null;
			}

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
						return null;
					}

				}
				weightMatrix[i] = matrixRow;
			}
			map = new Map(nodes, weightMatrix);


			// TODO
			//
			// falta la parte que resuelve


			return null;
		}
		public void setMap(string path)
		{
			text = CSVParser.readMapGraph(path);
		}
		public bool setMainNode(string nodeName)
		{
			nodeName = nodeName.ToLower();
			if (map == null ||
				map.nodes == null ||
				map.nodes.Count == 0 ||
				map.nodes.ContainsKey(nodeName) == false)
			{
				return false;
			}

			map.mainNode = map.nodes[nodeName];
			return true;
		}

		public void print()
		{
			if (solution == null)
			{
				Console.WriteLine("No solution found");
				return;
			}
			solution.print();
		}
	}
}
