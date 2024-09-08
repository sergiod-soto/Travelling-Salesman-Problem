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

		public void Print()
		{
			if (map == null || map.Count == 0)
			{
				Console.WriteLine("\n\nMap empty or null\n\n");
				return;
			}
			PrintGraph(map);



		}

		// Método para imprimir el grafo
		static void PrintGraph(Dictionary<string, Node> map)
		{
			Console.WriteLine("Graph Representation:");
			Console.WriteLine("======================");
			foreach (var nodeEntry in map)
			{
				Node node = nodeEntry.Value;
				Console.WriteLine($"{node.name}:");

				foreach (var vertexEntry in node.vertices)
				{
					Vertex vertex = vertexEntry.Value;
					// Imprimimos la conexión con peso y nodo conectado
					Console.WriteLine($"  └──> {vertex.node1.name} (Weight: {vertex.weight})");
				}
				Console.WriteLine();
			}
		}

		private class Node
		{
			public string name;
			public Dictionary<string, Vertex> vertices;

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
			public int weight;
			public Node node1;
			public Node node2;


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
