using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage = null;

        public void AddVehicleToGarage(VehicleInGarage i_VehicleToAdd)
        {
            m_VehiclesInGarage.Add(i_VehicleToAdd.LicensePlate, i_VehicleToAdd);
        }
    }
}
