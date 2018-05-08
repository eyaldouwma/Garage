using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    public class Motorcycle : Vehicle
    {
        public enum eMotorcycleLicenseType
        {
            A,
            A1,
            B1,
            B2
        }

        private readonly eMotorcycleLicenseType r_MotorcycleLicense;
        private readonly int r_EngineVolume;

        public Motorcycle(int i_EngineVolume, eMotorcycleLicenseType i_LicenseType)
        {
            r_EngineVolume = i_EngineVolume;
            r_MotorcycleLicense = i_LicenseType;
        }

    }
}
