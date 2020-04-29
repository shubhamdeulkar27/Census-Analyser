using System;
using System.Collections.Generic;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string StateCensusDataFilePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCensusData.csv";
            int numberOfRecords1 = StateCensusAnalyser<CSVStateCensus>.ReadFile(StateCensusDataFilePath, ",");
            Console.WriteLine($"StateCensusData Records are {numberOfRecords1}");

            string StateCodeFilePath= @"C:\Users\Shubham\source\repos\Census-Analyser\StateCode.csv";
            int numberOfRecords2 = StateCensusAnalyser<CSVStates>.ReadFile(StateCodeFilePath, ",");
            Console.WriteLine($"StateCode Records are {numberOfRecords2}");
            
            string USCensusFilePath = @"C:\Users\Shubham\source\repos\Census-Analyser\USCensusData.csv";
            int numberOfRecords3 = StateCensusAnalyser<CSVUSCensus>.ReadFile(USCensusFilePath, ",");
            Dictionary<int,CSVUSCensus> dataDictionary = StateCensusAnalyser<CSVUSCensus>.dataDictionary;
            foreach(KeyValuePair<int,CSVUSCensus> pair in dataDictionary)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value.State_Id1} : {pair.Value.State1} : {pair.Value.Total_Area1} : {pair.Value.Population1} : {pair.Value.Population_Density1}");
            }
        }
    }
}
