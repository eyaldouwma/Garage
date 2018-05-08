using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    class FueledCar : Car
    {
        private FuelTank m_FuelTank;
      
        public FueledCar(eCarColor i_CarColor, eCarDoors i_NumberOfDoors, List<float> i_AirPressure, float i_FuelLeft, string i_LicensePlate)
            : base(i_CarColor, i_NumberOfDoors)
        {
            m_LicensePlate = i_LicensePlate;
            m_FuelTank = new FuelTank(45f, FuelTank.eFuelType.Octan98);
            m_FuelTank.FillFuel(FuelTank.eFuelType.Octan98, i_FuelLeft);
            m_Tires = new List<Tire>(4);

            for (int i = 0; i < 4; i++)
            {
                m_Tires[i] = new Tire(32);
            }

            for (int i = 0; i < 4; i++)
            {
                m_Tires[i].Inflate(i_AirPressure[i]);
            }

            m_EnergyMeterPrecentage = i_FuelLeft / 45f;
        }
    }
}
