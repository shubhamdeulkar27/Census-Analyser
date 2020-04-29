using System;
using System.Collections.Generic;
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
        /// Parameter Constructor For Setting Data.
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
        /// Function TO Return CSVStateCensus Instance.
        /// </summary>
        /// <returns></returns>
        public CSVStateCensus GetCSVStateCensus()
        {
            return new CSVStateCensus(state,population,populationDensity,totalArea);
        }
    }
}
