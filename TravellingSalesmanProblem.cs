using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Travelling_Salesman_Problem.Map;

namespace Travelling_Salesman_Problem
{
	class TravellingSalesmanProblem
	{
		public Map map;
		string[] text;
		public Solution solution;





		public TravellingSalesmanProblem() { }

		public class Solution
		{
			public enum SolvingMethods
			{
				NearestN_Solver,
				otro
			}


			public string[] path;
			public int weight;

			public Solution(string[] path, int weight)
			{
				this.path = path;
				this.weight = weight;
			}
			public void Print()
			{
				// capitalize first letter
				for (int i = 0; i < path.Length; i++)
				{
					path[i] = path[i].ToLower();
					path[i] = char.ToUpper(path[i][0]) + path[i].Substring(1);
				}

				Console.Write(
					"\n" +
					"\n" +
					"\n" +
					"\n" +
					"Best route found:" +
					"\n" +
					"\n" +
					"└──>  ");
				for (int i = 0; i < path.Length - 1; i++)
				{
					Console.Write(path[i] + " -> ");
				}
				Console.WriteLine(path[path.Length - 1]);
				Console.WriteLine("Weight: " + weight);
			}
		}


		public Solution Solve(Solution.SolvingMethods method)
		{
			switch (method)
			{
				case (Solution.SolvingMethods.NearestN_Solver):
					Solution solution = NearestNeightbor_Solver(map);

					solution.weight = map.routeWeight(map.nodes, solution.path);
					return solution;

				case (Solution.SolvingMethods.otro):

					break;
			}
			return null;
		}

		public void setMap(string path)
		{
			text = CSVParser.readMapGraph(path);

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


		/*
		 *  method based on nearest neighbord
		 */
		public Solution NearestNeightbor_Solver(Map map)
		{
			if (map == null || map.nodes == null || map.nodes.Count == 0 || map.mainNode == null)
			{
				Console.WriteLine("Error. Be sure to configure parameters before solving.");
				return null;
			}

			// Inicializar variables
			List<string> visitedNodes = new List<string>(); // Para rastrear los nodos visitados
			Node currentNode = map.mainNode; // Comenzamos desde el nodo principal
			int totalWeight = 0;

			// Añadir el nodo principal a los visitados
			visitedNodes.Add(currentNode.name);

			// Mientras queden nodos sin visitar
			while (visitedNodes.Count < map.nodes.Count)
			{
				Vertex nearestVertex = null;
				int minWeight = int.MaxValue;

				// Buscar el nodo vecino no visitado más cercano
				foreach (var vertexEntry in currentNode.vertices)
				{
					Vertex vertex = vertexEntry.Value;
					if (!visitedNodes.Contains(vertex.node2.name) && vertex.weight < minWeight && vertex.weight > 0)
					{
						nearestVertex = vertex;
						minWeight = vertex.weight;
					}
				}

				// Si encontramos un nodo cercano, lo visitamos
				if (nearestVertex != null)
				{
					currentNode = nearestVertex.node2;
					visitedNodes.Add(currentNode.name);
					totalWeight += nearestVertex.weight;
				}
				else
				{
					// No hay más nodos que visitar desde aquí
					break;
				}
			}

			// Volver al nodo inicial para cerrar el ciclo
			if (visitedNodes.Count == map.nodes.Count)
			{
				if (currentNode.vertices.ContainsKey(map.mainNode.name))
				{
					totalWeight += currentNode.vertices[map.mainNode.name].weight;
					visitedNodes.Add(map.mainNode.name); // Añadir nodo inicial al final
				}
			}

			// Guardar y mostrar la solución
			solution = new Solution(visitedNodes.ToArray(), totalWeight);
			return solution;
		}
	}
}
