using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    class FueledMotorcycle : Motorcycle
    {
        private FuelTank m_FuelTank;

        public FueledMotorcycle(eMotorcycleLicenseType i_LicenseType, string i_LicensePlate, int i_EngineVolume, List<float> i_AirPressure, float i_FuelLeft)
            : base(i_EngineVolume, i_LicenseType)
        {
            m_LicensePlate = i_LicensePlate;
            m_FuelTank = new FuelTank(6f, FuelTank.eFuelType.Octan96);
            m_FuelTank.FillFuel(FuelTank.eFuelType.Octan96, i_FuelLeft);

            m_Tires = new List<Tire>(2);

            m_Tires[0] = new Tire(30);
            m_Tires[0].Inflate(i_AirPressure[0]);

            m_Tires[1] = new Tire(30);
            m_Tires[1].Inflate(i_AirPressure[1]);

            m_EnergyMeterPrecentage = i_FuelLeft / 6f;
        }
    }
}
