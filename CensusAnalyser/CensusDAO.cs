using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// CensusDao Class For Setting Data.
    /// </summary>
    class CensusDAO
    {
        //Variabels.
        public string state;
        public string stateCode;
        public string population;
        public string populationDensity;
        public string totalArea;

        /// <summary>
        /// Parameter Constructor For Setting Data for StateCensus.
        /// </summary>
        /// <param name="cSVStateCensus"></param>
        /// <param name="values"></param>
        public CensusDAO(CSVStateCensus cSVStateCensus,string[] values)
        {
            state = values[0];
            population = values[1];
            totalArea = values[2];
            populationDensity= values[3];
        }

        /// <summary>
        /// Parameter Constructor For Setting Data For USCensus.
        /// </summary>
        /// <param name="cSVUSCensus"></param>
        /// <param name="values"></param>
        public CensusDAO(CSVUSCensus cSVUSCensus, string[] values)
        {
            stateCode = values[0];
            state = values[1];
            population = values[2];
            totalArea = values[4];
            populationDensity = values[7];
        }

        /// <summary>
        /// Function TO Return CSVStateCensus Instance.
        /// </summary>
        /// <returns></returns>
        public CSVStateCensus GetCSVStateCensus()
        {
            return new CSVStateCensus(state,population,populationDensity,totalArea);
        }

        /// <summary>
        /// Function TO Return CSVUSCensus Instance.
        /// </summary>
        /// <returns></returns>
        public CSVUSCensus GetCSVUSCensus()
        {
            return new CSVUSCensus(state, stateCode, population, populationDensity,totalArea);
        }
    }
}
