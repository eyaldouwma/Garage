using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const byte k_NumOfTires = 2;
        private const float k_MaxTirePressure = 30f;

        public static byte NumOfTires
        {
            get
            {
                return k_NumOfTires;
            }
        }

        public static float MaxTirePressure
        {
            get
            {
                return k_MaxTirePressure;
            }
        }

        public enum eMotorcycleLicenseType
        {
            A,
            A1,
            B1,
            B2
        }

        private readonly eMotorcycleLicenseType r_MotorcycleLicense;

        public string MotorcycleLicense
        {
            get
            {
                return Enum.GetName(typeof(eMotorcycleLicenseType), r_MotorcycleLicense);
            }
        }

        private readonly int r_EngineVolume;

        public int EngineVolume
        {
            get
            {
                return r_EngineVolume;
            }
        }

        public Motorcycle(int i_EngineVolume, eMotorcycleLicenseType i_LicenseType, List<Tire> i_Tires, Powersource i_Powersource, string i_LicensePlate, string i_ModelName) : base(i_LicensePlate, i_ModelName)
        {
            m_Powersource = i_Powersource;
            m_Tires = i_Tires;
            r_EngineVolume = i_EngineVolume;
            r_MotorcycleLicense = i_LicenseType;
        }
    }
}
