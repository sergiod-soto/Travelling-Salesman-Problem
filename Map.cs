using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_Salesman_Problem
{
	public class Map
	{
		private class Node
		{
			string name;
			HashSet<Vertex> vertices;

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
	}
}
