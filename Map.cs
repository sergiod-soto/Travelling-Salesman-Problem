﻿using System;
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
		}
	}
}
