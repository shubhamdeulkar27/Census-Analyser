using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
	/// <summary>
	/// StateCensusAnalyser Class To Analyse The StateCensus Data.
	/// </summary>
    public class StateCensusAnalyser<T>
    {
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

            List<T> dataList = CensusLoader<T>.LoadFile(filePath,delimiter);
			return dataList.Count;
		}

	}
}
