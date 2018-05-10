using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public enum eVehicleType
        {
            ElectricCar,
            ElectricMotorcycle,
            FueledCar,
            FueledMotorcycle,
            Truck
        }

        public static Vehicle CreateVehicle(string i_LicensePlate, eVehicleType i_VehicleType, string i_ModelName, List<float> i_AirPressure, params object[] i_VehicleProperties)
        {
            Vehicle vehicleCreated = null;
            Powersource sourceOfPower = null;
            List<Tire> tires = null;
            if (i_VehicleType == eVehicleType.ElectricCar)
            {
                sourceOfPower = new Battery(3.2f);
                tires = CreateTires(i_AirPressure, 4, 32f);
                vehicleCreated = new Car((Car.eCarColor)i_VehicleProperties[0], (Car.eCarDoors)i_VehicleProperties[1], tires, sourceOfPower);
            }
            else if (i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                sourceOfPower = new Battery(1.8f);
                tires = CreateTires(i_AirPressure, 2, 30f);
                vehicleCreated = new Motorcycle((int)i_VehicleProperties[0], (Motorcycle.eMotorcycleLicenseType)i_VehicleProperties[1], tires, sourceOfPower);
            }
            else if (i_VehicleType == eVehicleType.FueledCar)
            {
                sourceOfPower = new Fuel(45f, (Fuel.eFuelType)i_VehicleProperties[2]);
                tires = CreateTires(i_AirPressure, 4, 32f);
                vehicleCreated = new Car((Car.eCarColor)i_VehicleProperties[0], (Car.eCarDoors)i_VehicleProperties[1], tires, sourceOfPower);
            }
            else if (i_VehicleType == eVehicleType.FueledMotorcycle)
            {
                sourceOfPower = new Fuel(6f, (Fuel.eFuelType)i_VehicleProperties[2]);
                tires = CreateTires(i_AirPressure, 2, 30f);
                vehicleCreated = new Motorcycle((int)i_VehicleProperties[0], (Motorcycle.eMotorcycleLicenseType)i_VehicleProperties[1], tires, sourceOfPower);
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                sourceOfPower = new Fuel(115f, (Fuel.eFuelType)i_VehicleProperties[2]);
                tires = CreateTires(i_AirPressure, 12, 28f);
                vehicleCreated = new Truck((bool)i_VehicleProperties[0], (float)i_VehicleProperties[1], tires, sourceOfPower);
            }
            return vehicleCreated;
        }
        public static List<Tire> CreateTires(List<float>i_AirPressure, int i_NumOfWheels, float i_MaxPressure)
        {
            List<Tire> tires = new List<Tire>(i_NumOfWheels);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                tires[i] = new Tire(i_MaxPressure);
                tires[i].Inflate(i_AirPressure[i]);
            }

            return tires;
        }
    }
}
