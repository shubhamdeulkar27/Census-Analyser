using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
	/// <summary>
	/// BuilderCSV Class to set the data to the respective CSV objects.
	/// </summary>
	public class BuilderCSV : IBuilderCSV
	{
		static string[] values;

		/// <summary>
		/// Function to set CSVStateCensus Data.
		/// </summary>
		/// <param name="lineArray"></param>
		/// <returns></returns>
		public CSVStateCensus SetCSVStateCensus(string[] lineArray)
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
			CSVStateCensus cSVStateCensus = new FactoryCSV<CSVStateCensus>().CreateCSV();
			cSVStateCensus.State = values[0];
			cSVStateCensus.Population = values[1];
			cSVStateCensus.AreaInSqKm = values[2];
			cSVStateCensus.DenisityPerSqKm = values[3];

			//Throw CSVException if Field is set to null.
			if (cSVStateCensus.State == null || cSVStateCensus.Population == null || cSVStateCensus.AreaInSqKm == null || cSVStateCensus.DenisityPerSqKm == null)
			{
				throw new CSVException(CSVException.ExceptionType.EMPTY_FEILD, "Entered Empty Field");
			}
			return cSVStateCensus;

		}

		/// <summary>
		/// Function To Set CSVStates Data.
		/// </summary>
		/// <param name="lineArray"></param>
		/// <returns></returns>
		public  CSVStates SetCSVStates(string[] lineArray)
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
			CSVStates cSVStates = new FactoryCSV<CSVStates>().CreateCSV();
			cSVStates.SrNo1 = values[0];
			cSVStates.State1 = values[1];
			cSVStates.Name1 = values[2];
			cSVStates.Tin1 = values[3];
			cSVStates.StateCode1 = values[4];

			//Throw CSVException if Field is set to null.
			if (cSVStates.SrNo1 == null || cSVStates.State1 == null || cSVStates.Name1 == null || cSVStates.Tin1 == null || cSVStates.StateCode1 == null)
			{
				throw new CSVException(CSVException.ExceptionType.EMPTY_FEILD, "Entered Empty Field");
			}
			return cSVStates;
		}	
	}
}
