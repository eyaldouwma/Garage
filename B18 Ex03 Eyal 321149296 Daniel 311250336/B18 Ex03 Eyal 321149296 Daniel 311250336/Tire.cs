using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private string m_TireManufacturer;
        public string TireManufacturer
        {
            set
            {
                m_TireManufacturer = value;
            }
        }
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
