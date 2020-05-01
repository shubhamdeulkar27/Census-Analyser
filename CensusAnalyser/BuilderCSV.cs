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
			values = new string[]{ "", "0", "0", "0" };
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
			cSVStateCensus = new CensusDAO(cSVStateCensus,values).GetCSVStateCensus();

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


		public CSVUSCensus SetCSVUSCensus(string[] lineArray)
		{
			values = new string[] { "", "", "", "", "", "", "", "", "" };
			try
			{
				values[0] = lineArray[0];
				values[1] = lineArray[1];
				values[2] = lineArray[2];
				values[3] = lineArray[3];
				values[4] = lineArray[4];
				values[5] = lineArray[5];
				values[6] = lineArray[6];
				values[7] = lineArray[7];
				values[8] = lineArray[8];
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
			CSVUSCensus cSVUSCensus = new FactoryCSV<CSVUSCensus>().CreateCSV();
			cSVUSCensus = new CensusDAO(cSVUSCensus, values).GetCSVUSCensus();

			//Throw CSVException if Field is set to null.
			if (cSVUSCensus.State_Id1 == null || cSVUSCensus.State1 == null || cSVUSCensus.Population1 == null || cSVUSCensus.Total_Area1 == null  || cSVUSCensus.Population_Density1 == null)
			{
				throw new CSVException(CSVException.ExceptionType.EMPTY_FEILD, "Entered Empty Field");
			}
			return cSVUSCensus;
		}
	}
}
