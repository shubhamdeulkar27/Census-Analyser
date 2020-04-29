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
            int expectedRecordsOfStateCode = 37;
            int expectedRecordsOfStateCensus = 29;
            int stateCodeRecords = StateCensusAnalyser<CSVStates>.ReadFile(StateCodeFilePath, delimiter);
            int statCensusRecords = StateCensusAnalyser<CSVStateCensus>.ReadFile(StateCensusFilePath, delimiter);
            Assert.AreEqual(expectedRecordsOfStateCode, stateCodeRecords);
            Assert.AreEqual(expectedRecordsOfStateCensus, statCensusRecords);
        }

        /// <summary>
        /// Test Case 2.2 Given Invalid File Should Throw CesnsusAnalysisException.
        /// </summary>
        [Test]
        public void GivenIncorrectStatCoDeFileShouldThrowCustomException()
        {
            string expected = "Invalid File";
            try
            {
                int stateCodeRecords = StateCensusAnalyser<CSVStates>.ReadFile(StateCensusFilePath, delimiter);
                int stateCensusRecords = StateCensusAnalyser<CSVStateCensus>.ReadFile(StateCodeFilePath, delimiter);
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
            string filepath1 = @"C:\Users\Shubham\source\repos\Census-Analyzer-Problem\StateCode.txt";
            string filepath2 = @"C:\Users\Shubham\source\repos\Census-Analyzer-Problem\StateCensusData.txt";
            string expected = "Invalid File Type";
            try
            {
                int stateCodeRecords = StateCensusAnalyser<CSVStates>.ReadFile(filepath1, delimiter);
                int stateCensusRecords = StateCensusAnalyser<CSVStateCensus>.ReadFile(filepath2, delimiter);
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
                int stateCodeRecords = StateCensusAnalyser<CSVStates>.ReadFile(StateCodeFilePath, custom_Delimiter);
                int stateCensusRecords = StateCensusAnalyser<CSVStateCensus>.ReadFile(StateCensusFilePath, custom_Delimiter);
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
            string filepath1 = @"C:\Users\Shubham\source\repos\Census-Analyser\CensusAnalyser\StateCode.csv";
            string filepath2 = @"C:\Users\Shubham\source\repos\Census-Analyser\CensusAnalyser\StateCensusData.csv";
            string expected = "Invalid Header";
            try
            {
               int stateCodeRecords = StateCensusAnalyser<CSVStates>.ReadFile(filepath1, delimiter);
                int stateCensusRecords = StateCensusAnalyser<CSVStateCensus>.ReadFile(filepath2, delimiter);
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
            var dataDictionary = StateCensusAnalyser<CSVStateCensus>.dataDictionary;
            string sortedJson = StateCensusAnalyser<CSVStateCensus>.SortCSVStateCensusByState(dataDictionary);
            var jArray = JArray.Parse(sortedJson);
            string firstState = jArray[0]["Value"]["State"].Value<string>();
            string lastState = jArray[28]["Value"]["State"].Value<string>();
            Assert.AreEqual(expectedFirstState, firstState);
            Assert.AreEqual(expectedLastState, lastState);
        }

        /// <summary>
        ///Test Case Checks if json formated CSVStates data is sorted or not.
        /// </summary>
        [Test]
        public void SortAndJsonTestCSVStates()
        {
            //Code For StateCode
            string expectedStateCodeFirstState = "Andaman and Nicobar Islands";
            string expectedStateCodeLastState = "West Bengal";
            int stateCodeRecords = StateCensusAnalyser<CSVStates>.ReadFile(StateCodeFilePath, delimiter);
            var stateCodeDictionary = StateCensusAnalyser<CSVStates>.dataDictionary;
            string sortedStateCodeJson = StateCensusAnalyser<CSVStates>.SortCSVStatesByCode(stateCodeDictionary);
            var jArray1 = JArray.Parse(sortedStateCodeJson);
            string stateCodeFirstState = jArray1[0]["Value"]["State1"].Value<string>();
            string stateCodeLastState = jArray1[jArray1.Count-1]["Value"]["State1"].Value<string>();
            Assert.AreEqual(expectedStateCodeFirstState, stateCodeFirstState);
            Assert.AreEqual(expectedStateCodeLastState, stateCodeLastState);

            //Code For StateCensus
            string expectedStateCensusFirstState = "Andhra Pradesh";
            string expectedStateCensusLastState = "West Bengal";
            int stateCensusRecords = StateCensusAnalyser<CSVStateCensus>.ReadFile(StateCensusFilePath, delimiter);
            var stateCensusDictionary = StateCensusAnalyser<CSVStateCensus>.dataDictionary;
            string sortedStateCensusJson = StateCensusAnalyser<CSVStateCensus>.SortCSVStateCensusByState(stateCensusDictionary);
            var jArray2 = JArray.Parse(sortedStateCensusJson);
            string stateCensusFirstState = jArray2[0]["Value"]["State"].Value<string>();
            string stateCensusLastState = jArray2[jArray2.Count-1]["Value"]["State"].Value<string>();
            Assert.AreEqual(expectedStateCensusFirstState, stateCensusFirstState);
            Assert.AreEqual(expectedStateCensusLastState, stateCensusLastState);
        }
    }
}