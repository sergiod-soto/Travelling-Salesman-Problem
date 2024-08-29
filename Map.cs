using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_Salesman_Problem
{
	public class Map
	{
		private Dictionary<string, Node> map;
		private Node mainNode;

		public Map(string[] nodes, int[][] matrix)
		{
			// first node becomes main node

		}

		public void print()
		{
			if (map == null || map.Count == 0)
			{
				Console.WriteLine("Map empty or null");
				return;
			}




		}

		// TODO
		static void DrawGraph(Dictionary<string, List<string>> graph)
		{
			// Vamos a usar un diccionario para almacenar las posiciones de los nodos
			var positions = new Dictionary<string, (int x, int y)>
		{
			{ "A", (2, 1) },
			{ "B", (8, 1) },
			{ "C", (2, 3) },
			{ "D", (8, 3) }
		};

			char[,] grid = new char[5, 11]; // 5 rows, 11 columns

			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 11; j++)
				{
					grid[i, j] = ' ';
				}
			}

			// Draw vertices
			foreach (var node in graph)
			{
				var pos1 = positions[node.Key];
				foreach (var neighbor in node.Value)
				{
					var pos2 = positions[neighbor];
					DrawLine(grid, pos1, pos2);
				}
			}

			// Draw nodes
			foreach (var node in positions)
			{
				grid[node.Value.y, node.Value.x] = node.Key[0];
			}

			// Print
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 11; j++)
				{
					Console.Write(grid[i, j]);
				}
				Console.WriteLine();
			}

		}
		static void DrawLine(char[,] grid, (int x, int y) start, (int x, int y) end)
		{
			// Draw horizontal line
			if (start.y == end.y)
			{
				int minX = Math.Min(start.x, end.x);
				int maxX = Math.Max(start.x, end.x);
				for (int x = minX + 1; x < maxX; x++)
				{
					grid[start.y, x] = '-';
				}
			}
			// Draw vertical line
			else if (start.x == end.x)
			{
				int minY = Math.Min(start.y, end.y);
				int maxY = Math.Max(start.y, end.y);
				for (int y = minY + 1; y < maxY; y++)
				{
					grid[y, start.x] = '|';
				}
			}
			// Draw diagonal line
			else
			{
				int deltaX = end.x - start.x;
				int deltaY = end.y - start.y;

				if (Math.Abs(deltaX) == Math.Abs(deltaY))
				{
					int xStep = deltaX / Math.Abs(deltaX);
					int yStep = deltaY / Math.Abs(deltaY);

					int x = start.x + xStep;
					int y = start.y + yStep;

					while (x != end.x && y != end.y)
					{
						grid[y, x] = '\\';
						x += xStep;
						y += yStep;
					}
				}
			}
		}


		private class Node
		{
			string name;
			Dictionary<string, Vertex> vertices;

			public Node(string n)
			{
				name = n;
			}


			/*
			 *  connect actual node to a new one
			 */
			public void connectTo(Node node, int weight)
			{
				if (vertices.ContainsKey(node.name))
				{
					throw new MapException($"Already connected to node \"{node.name}\"");
				}

				Vertex vertex = new Vertex(weight, this, node);
				vertices.Add(node.name, vertex);
			}
		}

		private class Vertex
		{
			int weight;
			Node node1;
			Node node2;


			public Vertex(int w, Node n1, Node n2)
			{
				weight = w;
				node1 = n1;
				node2 = n2;
			}

			public Node[] getNodes()
			{
				return new Node[] { node1, node2 };
			}

			public int getWeight()
			{
				return weight;
			}
		}

		private class MapException : Exception
		{
			public MapException(string message) : base(message) { }
		}
	}
}
