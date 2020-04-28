using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
	/// <summary>
	/// BuilderCSV Class to set the data to the respective CSV objects.
	/// </summary>
	public class BuilderCSV
	{
		static string[] values;

		/// <summary>
		/// Function to set CSVStateCensus Data.
		/// </summary>
		/// <param name="lineArray"></param>
		/// <returns></returns>
		public static CSVStateCensus SetCSVStateCensus(string[] lineArray)
		{
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
			CSVStateCensus cSVStateCensus = FactoryCSV<CSVStateCensus>.CreateCSV();
			cSVStateCensus.State = values[0];
			cSVStateCensus.Population = values[1];
			cSVStateCensus.AreaInSqKm = values[2];
			cSVStateCensus.DenisityPerSqKm = values[3];
			return cSVStateCensus;
		}

		/// <summary>
		/// Function To Set CSVStates Data.
		/// </summary>
		/// <param name="lineArray"></param>
		/// <returns></returns>
		public static CSVStates SetCSVStates(string[] lineArray)
		{
			values = new string[] { "", "", "", "", "" };
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
			CSVStates cSVStates = FactoryCSV<CSVStates>.CreateCSV();
			cSVStates.SrNo1 = values[0];
			cSVStates.State1 = values[1];
			cSVStates.Name1 = values[2];
			cSVStates.Tin1 = values[3];
			cSVStates.StateCode1 = values[4];
			return cSVStates;
		}	
	}
}
