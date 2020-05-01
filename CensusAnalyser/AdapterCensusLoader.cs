using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// Adapter Class Adapts Thw Functionality of Both ICensusLoader and CensusLoader.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class AdapterCensusLoader<T>:CensusLoader<T>,ICensusLoader<T>
    {
        /// <summary>
        /// Function to Load CSV File.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="delimiter"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Dictionary<int, T> LoadFile(ICensusLoader<T>.Country country, string delimiter, params string[] filePath)
        {
            if (country.Equals(Country.INDIA))
                return this.LoadFile(AdapterCensusLoader<T>.Country.INDIA, ",", filePath);
            return this.LoadFile(AdapterCensusLoader<T>.Country.US, ",", filePath);
        }
    }
}
