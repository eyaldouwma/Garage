using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
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
