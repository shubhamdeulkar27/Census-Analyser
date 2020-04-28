﻿using System;
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
			List<T> dataList = new List<T>();
			StreamReader reader = new StreamReader(filePath);
			string header = reader.ReadLine();
			Type type = typeof(T);
			string[] lineArray;

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
					CSVStateCensus cSVStateCensus = new BuilderCSV().SetCSVStateCensus(lineArray);
					dataList.Add((T)Convert.ChangeType(cSVStateCensus, typeof(T)));
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
					CSVStates cSVStates = new BuilderCSV().SetCSVStates(lineArray);
					dataList.Add((T)Convert.ChangeType(cSVStates, typeof(T)));
				}
			}
			return dataList;
		}
	}
}