using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public enum eVehicleStatus
        {
            InProgress,
            Fixed,
            Paid
        }

        private eVehicleStatus m_VehicleStatus = eVehicleStatus.InProgress;
        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }
        private Vehicle m_TheVehicle;
        public Vehicle TheVehicle
        {
            get
            {
                return m_TheVehicle;
            }
        }
        private readonly string r_OwnerName;
        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }
        private string m_OwnerPhoneNumber;
        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }

            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_TheVehicle)
        {
            r_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_TheVehicle = i_TheVehicle;
        }

    }
}
