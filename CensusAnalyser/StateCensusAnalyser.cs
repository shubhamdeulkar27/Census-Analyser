using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace CensusAnalyser
{
	/// <summary>
	/// StateCensusAnalyser Class To Analyse The StateCensus Data.
	/// </summary>
    public class StateCensusAnalyser<T>
    {
		//Dictionary to Store The CSV Data.
		public static Dictionary<int,T> dataDictionary = null;

		//File path to Store JSON formated JSON file.
		static string outputPath = @"C:\Users\Shubham\source\repos\Census-Analyser\CensusAnalyser\Files\";

		/// <summary>
		/// ReadStateCensus Function Reads CSV File in Dictionary(MAP) and returns Dictionary(MAP) Count.
		/// </summary>
		/// <param name="country"></param>
		/// <param name="delimiter"></param>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public int ReadFile(CensusLoader<T>.Country country, string delimiter,params string[] filePath)
        {
			//IF File Type is invalid the throw CensusAnalysisException.
			if (!filePath[0].Contains(".csv"))
			{
				throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_FILE_TYPE, "Invalid File Type");
			}

			//If Delimiter is Invalid Then Throw CensusAnalysisException.
			if (!delimiter.Contains(","))
			{
				throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
			}

            dataDictionary = new AdapterCensusLoader<T>().LoadFile(country,delimiter,filePath);
			return dataDictionary.Count;
		}

		/// <summary>
		/// Function to sort the Dictionary(MAP) of CSVStates type and Convert it to Json Format.
		/// </summary>
		/// <param name="dataDictionary"></param>
		/// <returns></returns>
		public string SortCSVStatesByCode(Dictionary<int,CSVStates> dataDictionary)
		{
			var sortedDictionary = from entry in dataDictionary orderby entry.Value.StateCode1 ascending select entry;
			string jsonStringObject = JsonSerializer.Serialize(sortedDictionary);
			return jsonStringObject;
		}

		/// <summary>
		/// Function to Sort Dictionary(MAP) of CSVStateCensus Type and Convert it to Json Format.
		/// </summary>
		/// <param name="dictionary"></param>
		/// <param name="orderValue"></param>
		/// <param name="isFile"></param>
		/// <returns></returns>
		public string SortCSVStateCensus(Dictionary<int, CSVStateCensus> dictionary, string orderValue, Boolean isFile)
		{
			var sortedDictionary = from entry in dictionary orderby entry.Value.State ascending select entry;
			switch (orderValue)
			{
				case "Population":
					sortedDictionary = from entry in dictionary orderby Int32.Parse(entry.Value.Population ) descending select entry;
					break;
				case "PopulationDensity":
					sortedDictionary = from entry in dictionary orderby Int32.Parse(entry.Value.DenisityPerSqKm) descending select entry;
					break;
				case "TotalArea":
					sortedDictionary = from entry in dictionary orderby Int32.Parse(entry.Value.AreaInSqKm) descending select entry;
					break;
			}
			string jsonStringObject = JsonSerializer.Serialize(sortedDictionary);
			if (isFile)
			{
				File.WriteAllText(outputPath + $"StateCensusBy{orderValue}.json", jsonStringObject);
			}
			return jsonStringObject;
		}
	}
}
