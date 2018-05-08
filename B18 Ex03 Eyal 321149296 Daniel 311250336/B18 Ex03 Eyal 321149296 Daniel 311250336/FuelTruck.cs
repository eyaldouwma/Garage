using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    class FuelTruck : Truck
    {
        private FuelTank m_FuelTank;

        public FuelTruck(string i_LicenesPlate, List<float> i_AirPressure, float i_FuelLeft)
        {
            m_LicensePlate = i_LicenesPlate;
            m_FuelTank = new FuelTank(115f, FuelTank.eFuelType.Soler);
            m_FuelTank.FillFuel(FuelTank.eFuelType.Soler, i_FuelLeft);
            m_Tires = new List<Tire>(12);

            for (int i = 0; i < 12; i++)
            {
                m_Tires[i] = new Tire(28);
            }

            for (int i = 0; i < 12; i++)
            {
                m_Tires[i].Inflate(i_AirPressure[i]);
            }

            m_EnergyMeterPrecentage = i_FuelLeft / 115f;
        }
    }
}
