using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex03_Eyal_321149296_Daniel_311250336
{
    public class Powersource
    {
        protected float m_CurrentState;
        protected readonly float r_MaxCapacity;

        public Powersource(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
        }

    }
}
