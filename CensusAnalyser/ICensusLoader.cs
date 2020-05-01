using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// Interface for Implemeting Adapter Design Pattern.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICensusLoader<T>
    {
        /// <summary>
        /// enum of Type Country.
        /// </summary>
        public enum Country { INDIA, US }

        /// <summary>
        /// Abstract Method For Loading File.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="delimiter"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public abstract Dictionary<int, T> LoadFile(Country country, string delimiter, params string[] filePath);
    }
}
