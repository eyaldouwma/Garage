using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
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
