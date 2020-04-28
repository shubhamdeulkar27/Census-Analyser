using CensusAnalyser;
using NUnit.Framework;
using System;

namespace CensusAnalyserTest
{
    /// <summary>
    /// Class For Test Cases.
    /// </summary>
    public class Tests
    {
        static string StateCensusFilePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCensusData.csv";
        static string delimiter = ",";
        static string StateCodeFilePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCode.csv";

        /// <summary>
        /// Test Case 1.1 Ensuring the number Of Record Matches.
        /// </summary>
        [Test]
        public void GivenStateCensusDataFileShouldReturnValidRecords()
        {
            int expectedNoOFRecords = 29;
            int records = StateCensusAnalyser.ReadStateCensus(StateCensusFilePath, delimiter);
            Assert.AreEqual(expectedNoOFRecords, records);
        }

        /// <summary>
        /// Test Case 1.2 Given Invalid File Should Throw Custom Exception.
        /// </summary>
        [Test]
        public void GivenInvalidFileShouldThrowException()
        {
            string expected = "Invalid File";
            string filePath = @"C:\Users\Shubham\source\repos\Census-Analyser\AnyFile.csv";
            try
            {
                int records = StateCensusAnalyser.ReadStateCensus(filePath, delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// Test Case 1.3 Given Invalid File Type Should throw Exception.
        /// </summary>
        [Test]
        public void GivenFileWithAnyTypeShouldThrowException()
        {
            string expected = "Invalid File Type";
            string filePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCensusData.csv";
            try
            {
                int records = StateCensusAnalyser.ReadStateCensus(filePath, delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// Test Case 1.4 Given Invalid Delimiter Should Throw Exception.
        /// </summary>
        [Test]
        public void GivenInvalidDelimiterShouldThrowException()
        {
            string expected = "Invalid Delimiter";
            string custom_Delimiter = ";";
            try
            {
                int records = StateCensusAnalyser.ReadStateCensus(StateCensusFilePath,custom_Delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// Test Case 1.5 Given File with Invalid Header Should Exception.
        /// </summary>
        [Test]
        public void GivenFileWithInvalidHeaderShouldThrowException()
        {
            string expected = "Invalid Header";
            string filePath = @"C:\Users\Shubham\source\repos\Census-Analyser\CensusAnalyser\StateCensusData.csv";
            try
            {
                int records = StateCensusAnalyser.ReadStateCensus(filePath, delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// Test Case 2.1 Ensuring the number Of Record Matches.
        /// </summary>
        [Test]
        public void GivenStateCodeFileShouldReturnValidRecords()
        {
            int expectedNoOFRecords = 37;
            int records = StateCensusAnalyser.ReadStates(StateCodeFilePath, delimiter);
            Assert.AreEqual(expectedNoOFRecords, records);
        }

        /// <summary>
        /// Test Case 2.2 Given Invalid File Should Throw CesnsusAnalysisException.
        /// </summary>
        [Test]
        public void GivenIncorrectStatCoDeFileShouldThrowCustomException()
        {
            string filepath = @"C:\Users\Shubham\source\repos\Census-Analyzer-Problem\AnyFileName.csv";
            string expected = "Invalid File";
            try
            {
                int records = StateCensusAnalyser.ReadStates(filepath, delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}