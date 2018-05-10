using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
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
        protected string m_LicensePlate;
        protected float m_EnergyMeterPrecentage;
        protected List<Tire> m_Tires = null;
    }
}
