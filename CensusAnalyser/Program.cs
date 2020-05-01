using System;
using System.Collections.Generic;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loading StateCensus Data.
            string StateCensusDataFilePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCensusData.csv";
            int numberOfRecords1 = new StateCensusAnalyser<CSVStateCensus>().ReadFile(CensusLoader<CSVStateCensus>.Country.INDIA, ",", StateCensusDataFilePath);
            Console.WriteLine($"StateCensusData Records are {numberOfRecords1}");
            
            //Loading StateCode Data.
            string StateCodeFilePath= @"C:\Users\Shubham\source\repos\Census-Analyser\StateCode.csv";
            int numberOfRecords2 = new StateCensusAnalyser<CSVStates>().ReadFile(CensusLoader<CSVStates>.Country.INDIA, ",", StateCodeFilePath);
            Console.WriteLine($"StateCode Records are {numberOfRecords2}");
            
            //Loading UCCensusData.
            string USCensusFilePath = @"C:\Users\Shubham\source\repos\Census-Analyser\USCensusData.csv";
            int numberOfRecords3 = new StateCensusAnalyser<CSVUSCensus>().ReadFile(CensusLoader<CSVUSCensus>.Country.US, ",", USCensusFilePath);
            Dictionary<int,CSVUSCensus> usDataDictionary = StateCensusAnalyser<CSVUSCensus>.dataDictionary;
            foreach(KeyValuePair<int,CSVUSCensus> pair in usDataDictionary)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value.State_Id1} : {pair.Value.State1} : {pair.Value.Total_Area1} : {pair.Value.Population1} : {pair.Value.Population_Density1}");
            }

            //Sorting Function.
            Dictionary<int, CSVStateCensus> dataDictionary = StateCensusAnalyser<CSVStateCensus>.dataDictionary;
            string json = new StateCensusAnalyser<CSVStateCensus>().SortCSVStateCensus(dataDictionary,"State",true);
            Console.WriteLine(json);
        }
    }
}
