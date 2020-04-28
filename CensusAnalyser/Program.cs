using System;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCensusData.csv";
            int nummberOfRecords = StateCensusAnalyser.ReadFile(filePath,",");
            Console.WriteLine($"Records are {nummberOfRecords}");
        }
    }
}
