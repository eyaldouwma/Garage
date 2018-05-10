﻿using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    public class Fuel : Powersource
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;
        

        public Fuel(float i_MaxCapacity, eFuelType i_FuelType) : base(i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
        }
        public void FillFuel(eFuelType i_FuelType, float i_HowMuchToFill)
        {

        }
    }
}