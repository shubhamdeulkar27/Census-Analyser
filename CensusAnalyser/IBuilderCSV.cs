using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// IBuilderCSV Interface For SetCSV Functions.
    /// </summary>
    interface IBuilderCSV
    {
        /// <summary>
        /// Abstract SetCSVStateCensus Function.
        /// </summary>
        /// <param name="lineArray"></param>
        /// <returns></returns>
        public abstract CSVStateCensus SetCSVStateCensus(string[] lineArray);

        /// <summary>
        /// Abstract SetCSVStates Function.
        /// </summary>
        /// <param name="lineArray"></param>
        /// <returns></returns>
        public abstract CSVStates SetCSVStates(string[] lineArray);
    }
}
