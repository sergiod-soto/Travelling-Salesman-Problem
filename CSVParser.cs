﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Travelling_Salesman_Problem
{
	public static class CSVParser
	{

		/**
		 *  Read the CSV with the graph that represent 
		 *  all differents destinations and weights
		 **/
		public static string[] readMapGraph(string path)
		{
			using (var reader = new StreamReader(path))
			{
				List<string> listA = new List<string>();
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(';');

					listA.Add(values[0]);
				}
				return listA.ToArray();
			}
		}

		static void writeCSV(string path)
		{

		}


		public static string[] parseLine(string line)
		{
			return line.Split(',');
		}
	}
}
