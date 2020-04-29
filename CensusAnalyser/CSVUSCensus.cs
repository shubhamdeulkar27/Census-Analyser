using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    /// <summary>
    /// POCO class for USCensus Data.
    /// </summary>
    public class CSVUSCensus
    {
        //Variables.
        private string state_Id;
        private string state;
        private string population;
        private string housing_Units;
        private string total_Area;
        private string water_Area;
        private string land_Area;
        private string population_Density;
        private string housing_Density;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CSVUSCensus() { }

        /// <summary>
        /// Parameter Constructor.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stateCode"></param>
        /// <param name="population"></param>
        /// <param name="populationDensity"></param>
        /// <param name="totalArea"></param>
        public CSVUSCensus(string state, string stateCode, string population, string populationDensity, string totalArea)
        {
            this.state = state;
            this.state_Id = stateCode;
            this.population = population;
            this.population_Density = populationDensity;
            this.total_Area = totalArea;
        }

        //Getters And Setters.
        public string State_Id1 { get => state_Id; set => state_Id = value; }
        public string State1 { get => state; set => state = value; }
        public string Population1 { get => population; set => population = value; }
        public string Housing_Units1 { get => housing_Units; set => housing_Units = value; }
        public string Total_Area1 { get => total_Area; set => total_Area = value; }
        public string Water_Area1 { get => water_Area; set => water_Area = value; }
        public string Land_Area1 { get => land_Area; set => land_Area = value; }
        public string Population_Density1 { get => population_Density; set => population_Density = value; }
        public string Housing_Density1 { get => housing_Density; set => housing_Density = value; }
    }
}
