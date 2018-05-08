using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    public class FuelTank
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;
        private float m_CurrentFuel;
        private readonly float r_MaxFuelCapacity;

        public FuelTank(float i_MaxCapacity, eFuelType i_FuelType)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelCapacity = i_MaxCapacity;
        }
        public void FillFuel(eFuelType i_FuelType, float i_HowMuchToFill)
        {

        }
    }
}
