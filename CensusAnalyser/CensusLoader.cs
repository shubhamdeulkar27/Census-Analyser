using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
	/// <summary>
	/// CensusLoader Class to Load CSV Data.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	class CensusLoader<T>
	{
		public static List<T> LoadFile(string filePath, string delimiter)
		{
			//Genric Type List
			List<T> list = new List<T>();
			StreamReader reader = new StreamReader(filePath);
			string header = reader.ReadLine();
			Type type = typeof(T);
			string[] lineArray;
			string[] values;

			//Checks The Generic Type And Loads Respective File.
			if (type.Equals(typeof(CSVStateCensus)))
			{
				//If File is Invalid then Throw CensusAnalysisException.
				if (!filePath.Contains("StateCensusData"))
				{
					throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.ENTERED_INVALID_FILES, "Invalid File");
				}
				//Throw Exception if File Header is Invalid.
				if (!header.Contains("State") || !header.Contains("Population") || !header.Contains("AreaInSqKm") || !header.Contains("DensityPerSqKm"))
				{
					throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_HEADER, "Invalid Header");
				}
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					lineArray = line.Split(delimiter);
					values = new string[]{ "", "", "", "" };
					try
					{
						values[0] = lineArray[0];
						values[1] = lineArray[1];
						values[2] = lineArray[2];
						values[3] = lineArray[3];
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
					list.Add((T)Convert.ChangeType(cSVStateCensus, typeof(T)));
				}
			}
			else if (type.Equals(typeof(CSVStates)))
			{
				//If File is Invalid then Throw CensusAnalysisException.
				if (!filePath.Contains("StateCode"))
				{
					throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.ENTERED_INVALID_FILES, "Invalid File");
				}
				//Throw Exception if File Header is Invalid.
				if (!header.Contains("SrNo") || !header.Contains("State") || !header.Contains("Name") || !header.Contains("TIN") || !header.Contains("StateCode"))
				{
					throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_HEADER, "Invalid Header");
				}
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					lineArray = line.Split(delimiter);
					values = new string[]{ "", "", "", "", "" };
					try
					{
						values[0] = lineArray[0];
						values[1] = lineArray[1];
						values[2] = lineArray[2];
						values[3] = lineArray[3];
						values[4] = lineArray[4];
					}
					catch (Exception exception)
					{
						Console.WriteLine(exception.Message);
					}
					CSVStates cSVStates = new CSVStates();
					cSVStates.SrNo1 = values[0];
					cSVStates.State1 = values[1];
					cSVStates.Name1 = values[2];
					cSVStates.Tin1 = values[3];
					cSVStates.StateCode1 = values[4];
					list.Add((T)Convert.ChangeType(cSVStates, typeof(T)));
				}
			}
			return list;
		}
	}
}