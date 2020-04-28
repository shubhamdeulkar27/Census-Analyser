using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    /// <summary>
    /// Class For Test Cases.
    /// </summary>
    public class Tests
    {
        static string StateCensusFilePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCensusData.csv";
        static string delimiter = ",";

        /// <summary>
        /// Test Case 1.1 Ensuring the number Of Record Matches.
        /// </summary>
        [Test]
        public void Test1()
        {
            int expectedNoOFRecords = 29;
            int records = StateCensusAnalyser.ReadFile(StateCensusFilePath, delimiter);
            Assert.AreEqual(expectedNoOFRecords,records);
        }
    }
}