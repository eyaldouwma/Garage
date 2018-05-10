using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    class VehicleInGarage
    {
        public enum eVehicleStatus
        {
            InProgress,
            Fixed,
            Paid
        }

        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InProgress;
        private Vehicle m_TheVehicle;
        private readonly string r_OwnerName;
        private string m_OwnerPhoneNumber;

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_TheVehicle)
        {
            r_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_TheVehicle = i_TheVehicle;
        }

    }
}
