using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    public class Tire
    {
        private string m_TireManufcaturer;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressure;

        public Tire(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }
        public void Inflate(float i_AirPressureToAdd)
        {

        }
    }
}
