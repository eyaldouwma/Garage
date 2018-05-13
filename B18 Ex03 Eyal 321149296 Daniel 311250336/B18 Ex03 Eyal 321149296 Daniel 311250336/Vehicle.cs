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
        public Powersource Powersource
        {
            get
            {
                return m_Powersource;
            }
        }
        protected readonly string r_ModelName;
        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }
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
        public List<Tire> Tires
        {
            get
            {
                return m_Tires;
            }
        }
        public void InflateTiresToMax()
        {
            foreach (Tire t in m_Tires)
            {
                t.Inflate(t.MaxAirPressure - t.CurrentAirPressure);
            }
        }

        public Vehicle(string i_LicensePlate, string i_ModelName)
        {
            r_LicensePlate = i_LicensePlate;
            r_ModelName = i_ModelName;
        }
        public void FillPowerSource(params object[] i_ChargeData)
        {
            if (this.m_Powersource is Battery)
            {
                ((Battery) m_Powersource).ChargeBattery((float) i_ChargeData[0]);
            }
            else if(this.m_Powersource is Fuel)
            {
                ((Fuel) m_Powersource).FillFuel((Fuel.eFuelType)i_ChargeData[1], (float)i_ChargeData[0]);
                
            }
            m_EnergyMeterPrecentage = m_Powersource.CurrentState / m_Powersource.MaxCapacity;
        }
    }
}
