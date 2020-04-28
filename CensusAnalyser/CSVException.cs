using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// CSVException class to handell CSV Custom CSV Exceptions.
    /// </summary>
    class CSVException : Exception
    {
        //Defining Exception Types.
        public enum ExceptionType
        {
            EMPTY_FEILD
        }

        ExceptionType type;

        /// <summary>
        /// Parameter Constructor To Throw Exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public CSVException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }

}
