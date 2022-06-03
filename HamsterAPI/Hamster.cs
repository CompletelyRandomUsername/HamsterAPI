using System;
using System.Collections.Generic;

namespace HamsterAPI
{
    public class Hamster
    {
        public string Type { get; set; }
        public int WeightGrams { get; set; }
        public int AgeYears { get; set; }
        public string Ration { get; set; }

        public Hamster()
        {
            
        }
        public Hamster(string Type, int WeightGrams, int AgeYears, string Ration)
        {
            this.Type = Type;
            this.WeightGrams = WeightGrams;
            this.AgeYears = AgeYears;
            this.Ration = Ration;
        }



    }
}
