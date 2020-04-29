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
		public static List<T> dataList = null;
		
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

            dataList = CensusLoader<T>.LoadFile(filePath,delimiter);
			return dataList.Count;
		}

		/// <summary>
		/// Function to sort the List of CSVStateCensus type and Convert it to Json Format. 
		/// </summary>
		/// <param name="dataList"></param>
		/// <returns></returns>
		public static string SortCSVStateCensusByState(List<CSVStateCensus> dataList)
		{
			List<CSVStateCensus> sortedList = dataList.OrderBy(o => o.State).ToList();
			string jsonStringObject = JsonSerializer.Serialize(sortedList);
			return jsonStringObject;
		}

		/// <summary>
		/// Function to sort the List of CSVStates type and Convert it to Json Format.
		/// </summary>
		/// <param name="dataList"></param>
		/// <returns></returns>
		public static string SortCSVStatesByCode(List<CSVStates> dataList)
		{
			List<CSVStates> sortedList = dataList.OrderBy(o => o.StateCode1).ToList();
			string jsonStringObject = JsonSerializer.Serialize(sortedList);
			return jsonStringObject;
		}
	}
}
