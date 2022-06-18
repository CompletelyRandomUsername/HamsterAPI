using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterAPI
{
    public class OutHamster
    {
        private int _id;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

        private string _type;
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;
                }
            }
        }

        private int _weight_grams;
        public int weight_grams
        {
            get
            {
                return _weight_grams;
            }
            set
            {
                if (_weight_grams != value)
                {
                    _weight_grams = value;
                }
            }
        }

        private int _age_years;
        public int age_years
        {
            get
            {
                return _age_years;
            }
            set
            {
                if (_age_years != value)
                {
                    _age_years = value;
                }
            }
        }

        private string _ration;
        public string ration
        {
            get
            {
                return _ration;
            }
            set
            {
                if (_ration != value)
                {
                    _ration = value;
                }
            }
        }

        public OutHamster()
        {
            
        }

        public OutHamster(string type, int weight_grams, int age_years, string ration)
        {
            this._type = type;
            this._weight_grams = weight_grams;
            this._age_years = age_years;
            this._ration = ration;
        }
    }
}
