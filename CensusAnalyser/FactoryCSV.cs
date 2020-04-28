using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// FactoryCSV Class to Create Instance of CSVStateCensus and CSVStates.
    /// </summary>
    public class FactoryCSV<T>:IFactoryCSV<T>
    {
        /// <summary>
        /// Function to create instance of type T.
        /// </summary>
        /// <returns></returns>
        public T CreateCSV()
        {
            Type type = typeof(T);
            object newObject = Activator.CreateInstance(type);
            return ((T)Convert.ChangeType(newObject, typeof(T)));
        }
    }
}
