using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    class CensusAnalysisException:Exception
    {
        public enum ExceptionType 
        {
            ENTERED_INVALID_FILES
        }

        ExceptionType type;

        public CensusAnalysisException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
