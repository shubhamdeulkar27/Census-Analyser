using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyser
{
	/// <summary>
	/// CensusLoader Class to Load CSV Data.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class CensusLoader<T>
	{
		/// <summary>
		/// Enum Types For Country.
		/// </summary>
		public enum Country { INDIA,US }

		/// <summary>
		/// Function To Load CSV File.
		/// </summary>
		/// <param name="country"></param>
		/// <param name="delimiter"></param>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public  Dictionary<int, T> LoadFile(Country country, string delimiter, params string[] filePath)
		{
			Dictionary<int, T> dataDictionary = new Dictionary<int, T>();
			StreamReader streamReader;
			string header;
			string[] lineArray;
			int counter = 0;
			Type type = typeof(T);
			if (country.Equals(Country.INDIA))
			{
				if (type.Equals(typeof(CSVStateCensus)))
				{
					//Code For CSVStateCensus Data.
					streamReader = new StreamReader(filePath[0]);
					header = streamReader.ReadLine().ToString();

					//If File is Invalid then Throw CensusAnalysisException.
					if (!filePath[0].Contains("StateCensusData"))
					{
						throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.ENTERED_INVALID_FILES, "Invalid File");
					}

					//Throw Exception if File Header is Invalid.
					if (!header.Contains("State") || !header.Contains("Population") || !header.Contains("AreaInSqKm") || !header.Contains("DensityPerSqKm"))
					{
						throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_HEADER, "Invalid Header");
					}
					while (!streamReader.EndOfStream)
					{
						string line = streamReader.ReadLine();
						lineArray = line.Split(delimiter);
						CSVStateCensus cSVStateCensus = new BuilderCSV().SetCSVStateCensus(lineArray);
						dataDictionary.Add(++counter, (T)Convert.ChangeType(cSVStateCensus, typeof(T)));
					}
				}
				else if (type.Equals(typeof(CSVStates)))
				{
					//Code For CSVStates Data.
					streamReader = new StreamReader(filePath[0]);
					header = streamReader.ReadLine().ToString();

					//If File is Invalid then Throw CensusAnalysisException.
					if (!filePath[0].Contains("StateCode"))
					{
						throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.ENTERED_INVALID_FILES, "Invalid File");
					}

					//Throw Exception if File Header is Invalid.
					if (!header.Contains("SrNo") || !header.Contains("State") || !header.Contains("Name") || !header.Contains("TIN") || !header.Contains("StateCode"))
					{
						throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_HEADER, "Invalid Header");
					}
					while (!streamReader.EndOfStream)
					{
						string line = streamReader.ReadLine();
						lineArray = line.Split(delimiter);
						CSVStates cSVStates = new BuilderCSV().SetCSVStates(lineArray);
						dataDictionary.Add(++counter, (T)Convert.ChangeType(cSVStates, typeof(T)));
					}
				}
			}
			else if (country.Equals(Country.US))
			{
				streamReader = new StreamReader(filePath[0]);
				header = streamReader.ReadLine().ToString();

				//If File is Invalid then Throw CensusAnalysisException.
				if (!filePath[0].Contains("USCensusData"))
				{
					throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.ENTERED_INVALID_FILES, "Invalid File");
				}
				//Throw Exception if File Header is Invalid.
				if (!header.Contains("State Id") || !header.Contains("State") || !header.Contains("Population") || !header.Contains("Housing units") || !header.Contains("Total area") || !header.Contains("Water area") || !header.Contains("Land area") || !header.Contains("Population Density") || !header.Contains("Housing Density"))
				{
					throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_HEADER, "Invalid Header");
				}
				while (!streamReader.EndOfStream)
				{
					string line = streamReader.ReadLine();
					lineArray = line.Split(delimiter);
					CSVUSCensus cSVUSCensus = new BuilderCSV().SetCSVUSCensus(lineArray);
					dataDictionary.Add(++counter, (T)Convert.ChangeType(cSVUSCensus, typeof(T)));
				}
			}
			return dataDictionary;
		}
	}
}