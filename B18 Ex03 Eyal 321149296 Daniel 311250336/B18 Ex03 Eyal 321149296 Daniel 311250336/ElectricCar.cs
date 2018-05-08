using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    public class ElectricCar : Car
    {
        private Battery m_Battery;

        public ElectricCar (eCarColor i_CarColor, eCarDoors i_NumberOfDoors, List<float> i_AirPressure, float i_EnergyLeft, string i_LicensePlate)
            : base(i_CarColor, i_NumberOfDoors)
        {
            m_LicensePlate = i_LicensePlate;
            m_Battery = new Battery(3.2f);
            m_Battery.ChargeBattery(i_EnergyLeft);

            m_Tires = new List<Tire>(4);

            for (int i = 0; i < 4; i++)
            {
                m_Tires[i] = new Tire(32);
            }

            for (int i = 0; i < 4; i++)
            {
                m_Tires[i].Inflate(i_AirPressure[i]);
            }

            m_EnergyMeterPrecentage = i_EnergyLeft / 3.2f;
        }
    }
}
