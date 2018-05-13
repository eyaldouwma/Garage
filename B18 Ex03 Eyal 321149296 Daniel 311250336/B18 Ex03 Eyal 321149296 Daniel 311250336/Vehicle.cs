using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        public enum ePowersource
        {
            Battery,
            Fuel
        }
        protected Powersource m_Powersource = null;
        protected string m_ModelName;
        protected readonly string r_LicensePlate;
        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }
        protected float m_EnergyMeterPrecentage;
        protected List<Tire> m_Tires = null;
    }
}
