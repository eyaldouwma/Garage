using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel : Powersource
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;
        
        public string FuelType
        {
            get
            {
                return Enum.GetName(typeof(eFuelType), r_FuelType);
            }
        }

        public Fuel(float i_MaxCapacity, eFuelType i_FuelType) : base(i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
        }
        public void FillFuel(eFuelType i_FuelType, float i_HowMuchToFill)
        {
            if (i_FuelType != r_FuelType)
            {
                ArgumentException typeMismatch = new ArgumentException();
                throw typeMismatch;
            }

            if (this.m_CurrentState + i_HowMuchToFill > this.r_MaxCapacity)
            {
                ValueOutOfRangeException valueOutOfRange = new ValueOutOfRangeException(this.r_MaxCapacity-this.m_CurrentState,0f);
                throw valueOutOfRange;
            }

            this.m_CurrentState += i_HowMuchToFill;

            
        }
    }
}
