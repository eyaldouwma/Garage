using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : Powersource
    {
        public Battery(float i_MaxCharge) : base(i_MaxCharge)
        {

        }
        public void ChargeBattery(float i_HowMuchToCharge)
        {
            if (this.m_CurrentState + i_HowMuchToCharge > this.r_MaxCapacity)
            {
                ValueOutOfRangeException valueOutOfRange = new ValueOutOfRangeException(this.r_MaxCapacity - this.m_CurrentState, 0f);
                throw valueOutOfRange;
            }

            this.m_CurrentState += i_HowMuchToCharge;
        }

    }
}
