using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// IFactoryCSV Interface For Implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IFactoryCSV<T>
    {
        /// <summary>
        /// Abstract CreateCSV Function.
        /// </summary>
        /// <returns></returns>
        public abstract T CreateCSV();
    }
}
