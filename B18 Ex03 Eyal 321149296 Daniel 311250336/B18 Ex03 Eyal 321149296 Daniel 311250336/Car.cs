using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const float k_MaxTirePressure = 32f;
        private const byte k_NumOfTires = 4;

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

        public enum eCarColor
        {
            Blue,
            White,
            Gray,
            Black
        }

        public enum eCarDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }
        
        private readonly eCarDoors r_NumOfDoors;
        public string NumOfDoors
        {
            get
            {
                return Enum.GetName(typeof(eCarDoors), r_NumOfDoors);
            }
        }
        private eCarColor m_CarColor;
        public string CarColor
        {
            get
            {
                return Enum.GetName(typeof(eCarColor), m_CarColor);
            }
        }
        public Car(eCarColor i_CarColor, eCarDoors i_NumOfDoors ,List<Tire> i_Tires ,Powersource i_Powersource)
        {
            m_Tires = i_Tires;
            i_Powersource = m_Powersource;
            m_CarColor = i_CarColor;
            r_NumOfDoors = i_NumOfDoors;
        }

    }
}
