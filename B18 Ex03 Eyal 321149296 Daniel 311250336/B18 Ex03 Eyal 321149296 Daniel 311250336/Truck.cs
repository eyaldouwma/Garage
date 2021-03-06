﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const float k_MaxTirePressure = 28f;
        private const byte k_NumOfTires = 12;
        private const float k_MaxFuelTankSize = 115f;

        public static float MaxFuelTankSize
        {
            get
            {
                return k_MaxFuelTankSize;
            }
        }

        public static float MaxTirePressure
        {
            get
            {
                return k_MaxTirePressure;
            }
        }

        public static byte NumOfTires
        {
            get
            {
                return k_NumOfTires;
            }
        }

        private bool m_CooledTrunk;

        public string CooledTrunk
        {
            get
            {
                if (m_CooledTrunk == true)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
        }

        private float m_TrunkVolume;

        public float TrunkVolume
        {
            get
            {
                return m_TrunkVolume;
            }
        }

        public Truck(bool i_CooledTrunk, float i_TrunkVolume, List<Tire> i_Tires, Powersource i_Powersource, string i_LicensePlate, string i_ModelName) : base(i_LicensePlate, i_ModelName)
        {
            m_CooledTrunk = i_CooledTrunk;
            m_TrunkVolume = i_TrunkVolume;
            m_Tires = i_Tires;
            m_Powersource = i_Powersource;
        }
    }
}
