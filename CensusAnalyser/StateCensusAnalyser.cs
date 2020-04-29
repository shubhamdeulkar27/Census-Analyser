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
		public static Dictionary<int,T> dataDictionary = null;
		
		/// <summary>
		/// ReadStateCensus Function Reads CSV File in List and returns List Count. 
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
		public static int ReadFile(string filePath, string delimiter)
        {
			//IF File Type is invalid the throw CensusAnalysisException.
			if (!filePath.Contains(".csv"))
			{
				throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_FILE_TYPE, "Invalid File Type");
			}

			//If Delimiter is Invalid Then Throw CensusAnalysisException.
			if (!delimiter.Contains(","))
			{
				throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
			}

            dataDictionary = CensusLoader<T>.LoadFile(filePath,delimiter);
			return dataDictionary.Count;
		}
		
		/// <summary>
		/// Function to sort the List of CSVStateCensus type and Convert it to Json Format. 
		/// </summary>
		/// <param name="dataList"></param>
		/// <returns></returns>
		public static string SortCSVStateCensusByState(Dictionary<int,CSVStateCensus> dataDictionary)
		{
			var sortedDictionary = from entry in dataDictionary orderby entry.Value.State ascending select entry;
			string jsonStringObject = JsonSerializer.Serialize(sortedDictionary);
			return jsonStringObject;
		}

		/// <summary>
		/// Function to sort the List of CSVStates type and Convert it to Json Format.
		/// </summary>
		/// <param name="dataList"></param>
		/// <returns></returns>
		public static string SortCSVStatesByCode(Dictionary<int,CSVStates> dataDictionary)
		{
			var sortedDictionary = from entry in dataDictionary orderby entry.Value.StateCode1 ascending select entry;
			string jsonStringObject = JsonSerializer.Serialize(sortedDictionary);
			return jsonStringObject;
		}

		/// <summary>
		/// Function to sort the Dictionary(Map) of CSVStateCensus type in High to Low Population Order and Convert it to Json Format.
		/// </summary>
		/// <param name="dictionary"></param>
		/// <returns></returns>
		public static string SortCSVStateCensusByPopulation(Dictionary<int, CSVStateCensus> dictionary,string path)
		{
			var sortedDictionary = from entry in dictionary orderby Int32.Parse(entry.Value.Population) descending select entry;
			string jsonStringObject = JsonSerializer.Serialize(sortedDictionary);
			File.WriteAllText(path + "Output.json", jsonStringObject);
			return jsonStringObject;
		}
	}
}
