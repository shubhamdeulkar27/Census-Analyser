﻿using System;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string StateCensusDataFilePath = @"C:\Users\Shubham\source\repos\Census-Analyser\StateCensusData.csv";
            int numberOfRecords1 = StateCensusAnalyser.ReadStateCensus(StateCensusDataFilePath, ",");
            Console.WriteLine($"StateCensusData Records are {numberOfRecords1}");

            string StateCodeFilePath= @"C:\Users\Shubham\source\repos\Census-Analyser\StateCode.csv";
            int numberOfRecords2 = StateCensusAnalyser.ReadStates(StateCodeFilePath, ",");
            Console.WriteLine($"StateCode Records are {numberOfRecords2}");
        }
    }
}
