using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
	/// <summary>
	/// StateCensusAnalyser Class To Analyse The StateCensus Data.
	/// </summary>
    public class StateCensusAnalyser
    {
		/// <summary>
		/// ReadStateCensus Function Reads CSV File in List and returns List Count. 
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="delimiter"></param>
		/// <returns></returns>
        public static int ReadStateCensus(string filePath, string delimiter)
        {
			//If File is Invalid then Throw CensusAnalysisException.
			if (!filePath.Contains("StateCensusData"))
			{
				throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.ENTERED_INVALID_FILES, "Invalid File");
			}

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
            List<CSVStateCensus> list = new List<CSVStateCensus>();
            StreamReader reader = new StreamReader(filePath);
            string header = reader.ReadLine();

			//Throw Exception if File Header is Invalid.
			if (!header.Contains("State") || !header.Contains("Population") || !header.Contains("AreaInSqKm") || !header.Contains("DensityPerSqKm"))
			{
				throw new CensusAnalysisException(CensusAnalysisException.ExceptionType.INVALID_HEADER, "Invalid Header");
			}
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
