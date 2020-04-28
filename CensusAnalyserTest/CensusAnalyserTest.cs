using CensusAnalyser;
using Newtonsoft.Json.Linq;
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
            int records = StateCensusAnalyser<CSVStateCensus>.ReadFile(StateCensusFilePath, delimiter);
            Assert.AreEqual(expectedNoOFRecords, records);
        }

        /// <summary>
        /// Test Case 1.2 Given Invalid File Should Throw Custom Exception.
        /// </summary>
        [Test]
        public void GivenInvalidFileShouldThrowException()
        {
            string expected = "Invalid File";
            string filePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCode.csv";
            try
            {
                int records = StateCensusAnalyser<CSVStateCensus>.ReadFile(filePath, delimiter);
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
                int records = StateCensusAnalyser<CSVStateCensus>.ReadFile(filePath, delimiter);
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
                int records = StateCensusAnalyser<CSVStateCensus>.ReadFile(StateCensusFilePath,custom_Delimiter);
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
                int records = StateCensusAnalyser<CSVStateCensus>.ReadFile(filePath, delimiter);
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
            int records = StateCensusAnalyser<CSVStates>.ReadFile(StateCodeFilePath, delimiter);
            Assert.AreEqual(expectedNoOFRecords, records);
        }

        /// <summary>
        /// Test Case 2.2 Given Invalid File Should Throw CesnsusAnalysisException.
        /// </summary>
        [Test]
        public void GivenIncorrectStatCoDeFileShouldThrowCustomException()
        {
            string filepath = @"C:\Users\Shubham\source\repos\Census-Analyzer-Problem\StateCensusData.csv";
            string expected = "Invalid File";
            try
            {
                int records = StateCensusAnalyser<CSVStates>.ReadFile(filepath, delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// Test Case 2.3 Given Invalid Type File Should Throw CensusAnalysisException.
        /// </summary>
        [Test]
        public void GivenInvalidFileTypeShouldThrowCensusAnalyssiException()
        {
            string filepath = @"C:\Users\Shubham\source\repos\Census-Analyzer-Problem\StateCode.txt";
            string expected = "Invalid File Type";
            try
            {
                int records = StateCensusAnalyser<CSVStates>.ReadFile(filepath, delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// Test Case 2.4 Given Invalid Delimiter should Throw CensusAnalysisException.
        /// </summary>
        [Test]
        public void GivenInCorrectDelimiterShouldThrowCensusAnalysisException()
        {
            string custom_Delimiter = ";";
            string expected = "Invalid Delimiter";
            try
            {
                int records = StateCensusAnalyser<CSVStates>.ReadFile(StateCodeFilePath, custom_Delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// Test Case 2.5 Given File With Incorrecct Header Should throw CensusAnalysisException.
        /// </summary>
        [Test]
        public void GivenFileWithIncorrectHeaderShouldThrowCensusAnalysisExcption()
        {
            string filepath = @"C:\Users\Shubham\source\repos\Census-Analyser\CensusAnalyser\StateCode.csv";
            string expected = "Invalid Header";
            try
            {
               int records = StateCensusAnalyser<CSVStates>.ReadFile(filepath, delimiter);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// Test Case To Check Json Formated Data Sorted Or Not.
        /// </summary>
        [Test]
        public void GivenListShouldReturnSortedJsonFormat()
        {
            string expectedFirstState = "Andhra Pradesh";
            string expectedLastState = "West Bengal";
            int records = StateCensusAnalyser<CSVStateCensus>.ReadFile(StateCensusFilePath, delimiter);
            var dataList = StateCensusAnalyser<CSVStateCensus>.dataList;
            string sortedJson = StateCensusAnalyser<CSVStateCensus>.Sort(dataList);
            var jArray = JArray.Parse(sortedJson);
            string firstState = jArray[0]["State"].Value<string>();
            string lastState = jArray[28]["State"].Value<string>();
            Assert.AreEqual(expectedFirstState, firstState);
            Assert.AreEqual(expectedLastState, lastState);
        }
    }
}