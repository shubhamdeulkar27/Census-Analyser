using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// Class For Custom Exception.
    /// </summary>
    class CensusAnalysisException:Exception
    {
        /// <summary>
        /// Exception Types.
        /// </summary>
        public enum ExceptionType 
        {
            ENTERED_INVALID_FILES, INVALID_FILE_TYPE, INVALID_DELIMITER, INVALID_HEADER,
            ENTERED_INVALID_ORDER
        }

        ExceptionType type;

        /// <summary>
        /// Function to Throw Custom Exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public CensusAnalysisException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
