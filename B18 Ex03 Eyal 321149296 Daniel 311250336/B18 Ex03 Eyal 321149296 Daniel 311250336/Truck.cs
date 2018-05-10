using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_CooledTrunk;
        private float m_TrunkVolume;

        public Truck(bool i_CooledTrunk, float i_TrunkVolume, List<Tire> i_Tires, Powersource i_Powersource)
        {
            m_CooledTrunk = i_CooledTrunk;
            m_TrunkVolume = i_TrunkVolume;
            m_Tires = i_Tires;
            m_Powersource = i_Powersource;
        }
    }
}
