﻿using System;
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

        public void InflateTiresToMax()
        {
            foreach (Tire t in m_Tires)
            {
                t.Inflate(t.MaxAirPressure - t.CurrentAirPressure);
            }
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
        }
    }
}
