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
            m_VehiclesInGarage.Add(i_VehicleToAdd.TheVehicle.LicensePlate, i_VehicleToAdd);
        }
        public VehicleInGarage GetVehicleByLicensePlate(string i_LicensePlate)
        {
            VehicleInGarage TheVehicle = null;
            m_VehiclesInGarage.TryGetValue(i_LicensePlate, out TheVehicle);

            return TheVehicle;
        }
        public bool CheckIfVehicleExists(string i_LicensePlate)
        {
            bool exists = false;

            exists = m_VehiclesInGarage.ContainsKey(i_LicensePlate);

            return exists;
        }

        public List<VehicleInGarage> SortVehiclesByStatus(VehicleInGarage.eVehicleStatus i_VehicleStatusToPrint, bool i_PrintAll)
        {
            List<VehicleInGarage> vehiclesSorted = new List<VehicleInGarage>();

            foreach (VehicleInGarage v  in m_VehiclesInGarage.Values)
            {
                if ((v.VehicleStatus == i_VehicleStatusToPrint) || (i_PrintAll == true))
                {
                    vehiclesSorted.Add(v);
                }
            }

            return vehiclesSorted;
        }
    }
}
