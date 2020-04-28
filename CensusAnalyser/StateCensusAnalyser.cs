using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public static int ReadFile(string filePath, string delimiter)
        {
            List<CSVStateCensus> list = new List<CSVStateCensus>();
            StreamReader reader = new StreamReader(filePath);
            string header = reader.ReadLine();
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				string[] lines = line.Split(delimiter);
				string[] values = { "", "", "", "" };
				try
				{
					values[0] = lines[0];
					values[1] = lines[1];
					values[2] = lines[2];
					values[3] = lines[3];
				}
				catch (Exception exception)
				{
					Console.WriteLine(exception.Message);
				}
				CSVStateCensus cSVStateCensus = new CSVStateCensus();
				cSVStateCensus.State = values[0];
				cSVStateCensus.Population = values[1];
				cSVStateCensus.AreaInSqKm = values[2];
				cSVStateCensus.DenisityPerSqKm = values[3];
				list.Add(cSVStateCensus);
			}
			return list.Count;
		}
    }
}
