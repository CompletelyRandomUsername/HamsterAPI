using System;
using System.Collections.Generic;
using System.Resources;
using Microsoft.EntityFrameworkCore;


namespace HamsterAPI
{
    public class Hamster
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

        private int _year_of_birth;
        public int year_of_birth
        {
            get
            {
                return _year_of_birth;
            }
            set
            {
                if (_year_of_birth != value)
                {
                    _year_of_birth = value;
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

        public Hamster() 
        {

        }

        public Hamster(string type, int weight_grams, int year_of_birth, string ration)
        {
            this._type = type;
            this._weight_grams = weight_grams;
            this._year_of_birth = year_of_birth;
            this._ration = ration;
        }
    }
}
