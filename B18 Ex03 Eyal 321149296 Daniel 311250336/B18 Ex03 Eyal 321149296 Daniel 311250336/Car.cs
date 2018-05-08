using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    public class Car : Vehicle
    {
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
        private eCarColor m_CarColor;

        public Car(eCarColor i_CarColor, eCarDoors i_NumOfDoors)
        {
            m_CarColor = i_CarColor;
            r_NumOfDoors = i_NumOfDoors;
        }

    }
}
