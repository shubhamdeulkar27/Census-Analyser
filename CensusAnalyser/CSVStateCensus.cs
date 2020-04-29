using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// POCO Class for StateCensusData File.
    /// </summary>
    public class CSVStateCensus
    {
        //Variables.
        private string state;
        private string population;
        private string areaInSqKm;
        private string denisityPerSqKm;

        public CSVStateCensus() { } 

        public CSVStateCensus(string state, string poplation, string populationDensity, string totalArea)
        {
            this.state = state;
            this.population = poplation;
            this.denisityPerSqKm = populationDensity;
            this.areaInSqKm = totalArea;
        }

        /// <summary>
        /// Setters And Getters.
        /// </summary>
        public string State { get => state; set => state = value; }
        public string Population { get => population; set => population = value; }
        public string AreaInSqKm { get => areaInSqKm; set => areaInSqKm = value; }
        public string DenisityPerSqKm { get => denisityPerSqKm; set => denisityPerSqKm = value; }
    }
}
