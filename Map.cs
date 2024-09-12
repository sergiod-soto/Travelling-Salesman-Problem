using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_Salesman_Problem
{
	public class Map
	{
		public Dictionary<string, Node> nodes;
		public Node mainNode;

		public Map(string[] n, int[][] matrix)
		{
			nodes = new Dictionary<string, Node>();

			// create each node
			foreach (string nodeName in n)
			{
				nodes.Add(nodeName, new Node(nodeName));
			}

			// add vertices
			int i = 0;
			foreach (string nodeName in n)
			{
				Node node = nodes[nodeName];
				int[] weights = matrix[i];
				i++;

				int nodeIterator = 0;
				foreach (int weight in weights)
				{
					Node nodeTo = nodes[n[nodeIterator]];
					try
					{
						node.connectTo(nodeTo, weight);
					}
					finally
					{
						nodeIterator++;
					}
				}
			}
		}


		public void Print()
		{
			if (nodes == null || nodes.Count == 0)
			{
				Console.WriteLine("\n\nMap empty or null\n\n");
				return;
			}
			PrintGraph(nodes);
		}

		static void PrintGraph(Dictionary<string, Node> map)
		{
			Console.WriteLine("Graph Representation:");
			Console.WriteLine("======================\n");
			foreach (var nodeEntry in map)
			{
				Node node = nodeEntry.Value;
				Console.WriteLine($"{node.name}:");

				foreach (var vertexEntry in node.vertices)
				{
					Vertex vertex = vertexEntry.Value;
					if (vertex.weight > 0)
					{
						Console.WriteLine($"  └──> {vertex.node2.name} (Weight: {vertex.weight})");
					}
				}
				Console.WriteLine();
			}
		}

		public class Node
		{
			public string name;
			public Dictionary<string, Vertex> vertices;

			public Node(string n)
			{
				name = n;
				vertices = new Dictionary<string, Vertex>();
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

		public class Vertex
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
