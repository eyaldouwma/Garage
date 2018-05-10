using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageUI
    {
        private Garage m_Garage = new Garage();

        private enum eUserChoice : byte
        {
            AddVehicle = 1,
            PresentCarLicensePlateList,
            ChangeVehicleStatus,
            InflateVehicleTires,
            FillVehicleFuel,
            ChargeVehicleBattery,
            ShowVehicleInformation,
            Quit
        }

        public void Run()
        {
            eUserChoice userChoice;

            string menu;

            menu = string.Format(
                "Please choose one of the options:{0}1.Add a vehicle{0}2.Present car license plate list{0}3.Change vehicle status" +
                "{0}4.Inflate vehicle tires{0}5.Fill vehicle fuel{0}6.Charge vehicle Battery{0}7.Show vehicle information{0}8.Quit",
                Environment.NewLine);
            do
            {
                Console.WriteLine(menu);
                userChoice = getUserInput();
            }
            while (userChoice != eUserChoice.Quit);
        }

        private eUserChoice getUserInput()
        {
            eUserChoice userChoice;
            int userInput;

            do
            {
                int.TryParse(Console.ReadLine(), out userInput);
            }
            while (Enum.IsDefined(typeof(eUserChoice), userInput) == false);

            userChoice = (eUserChoice) userInput;

            return userChoice;
        }

        private void runMenuChoice(eUserChoice i_UserChoice)
        {
            if (i_UserChoice == eUserChoice.AddVehicle)
            {
                addVehicle();
            }
            else if (i_UserChoice == eUserChoice.PresentCarLicensePlateList)
            {

            }
            else if (i_UserChoice == eUserChoice.ChangeVehicleStatus)
            {

            }
            else if (i_UserChoice == eUserChoice.InflateVehicleTires)
            {

            }
            else if (i_UserChoice == eUserChoice.FillVehicleFuel)
            {

            }
            else if (i_UserChoice == eUserChoice.ChargeVehicleBattery)
            {

            }
            else if (i_UserChoice == eUserChoice.ShowVehicleInformation)
            {

            }
        }

        private void addVehicle()
        {
            string userInput;
            string licensePlate;
            string ownerName;
            string ownerPhoneNumber;

        }

        private void addCar(string i_LicenePlate, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string userChoice;
            string modelName;
            bool correctChoice;
            Car.eCarDoors numOfDoors;
            Car.eCarColor carColor;
            List<float> airPressure;
            Vehicle car = null;

            Console.WriteLine("Please enter the model name of the car:");
            modelName = Console.ReadLine();
            airPressure = checkAndCreateAirPressureList(Car.NumOfTires, Car.MaxTirePressure);

            do
            {
                Console.WriteLine("Please choose how many doors the car has ({0}/{1}/{2}/{3}):",
                    Enum.GetName(typeof(Car.eCarDoors), 2),
                    Enum.GetName(typeof(Car.eCarDoors), 3),
                    Enum.GetName(typeof(Car.eCarDoors), 4),
                    Enum.GetName(typeof(Car.eCarDoors), 5));
                userChoice = Console.ReadLine();
                correctChoice = Enum.IsDefined(typeof(Car.eCarDoors), userChoice);
                if (correctChoice == false)
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            while (correctChoice == false);

            Enum.TryParse<Car.eCarDoors>(userChoice, out numOfDoors);
            correctChoice = false;

            do
            {
                Console.WriteLine("Please choose the color of the car ({0}/{1}/{2}/{3}):",
                    Enum.GetName(typeof(Car.eCarColor), 0),
                    Enum.GetName(typeof(Car.eCarColor), 1),
                    Enum.GetName(typeof(Car.eCarColor), 2),
                    Enum.GetName(typeof(Car.eCarColor), 3));
                userChoice = Console.ReadLine();
                correctChoice = Enum.IsDefined(typeof(Car.eCarColor), userChoice);
                if (correctChoice == false)
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            while (correctChoice == false);

            Enum.TryParse<Car.eCarColor>(userChoice, out carColor);
            userChoice = checkAndChoosePowersource();

            if (userChoice == "1")
            {
                car = VehicleFactory.CreateVehicle(i_LicenePlate, VehicleFactory.eVehicleType.ElectricCar, modelName, airPressure, carColor, numOfDoors);
            }
            else if (userChoice == "2")
            {
                car = VehicleFactory.CreateVehicle(i_LicenePlate, VehicleFactory.eVehicleType.FueledCar, modelName, airPressure, carColor, numOfDoors);
            }

            VehicleInGarage carInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, car);
            m_Garage.AddVehicleToGarage(carInGarage);
        }

        private void addMotorcycle(string i_LicenePlate, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string userChoice;
            string modelName;
            bool correctChoice;
            Motorcycle.eMotorcycleLicenseType licenseType;
            int engineVolume;
            List<float> airPressure;
            Vehicle motorcycle = null;

            Console.WriteLine("Please enter the model name of the motorcycle:");
            modelName = Console.ReadLine();
            airPressure = checkAndCreateAirPressureList(Motorcycle.NumOfTires, Motorcycle.MaxTirePressure);

            do
            {
                Console.WriteLine("Please choose the license type of the motorcycle({0}/{1}/{2}/{3}):",
                    Enum.GetName(typeof(Motorcycle.eMotorcycleLicenseType), 0),
                    Enum.GetName(typeof(Motorcycle.eMotorcycleLicenseType), 1),
                    Enum.GetName(typeof(Motorcycle.eMotorcycleLicenseType), 2),
                    Enum.GetName(typeof(Motorcycle.eMotorcycleLicenseType), 3));
                userChoice = Console.ReadLine();
                correctChoice = Enum.IsDefined(typeof(Car.eCarDoors), userChoice);
                if (correctChoice == false)
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            while (correctChoice == false);

            Enum.TryParse<Motorcycle.eMotorcycleLicenseType>(userChoice, out licenseType);

            do
            {
                Console.WriteLine("Please enter the engine volume:");
                userChoice = Console.ReadLine();
            }
            while (int.TryParse(userChoice, out engineVolume) == false);

            userChoice = checkAndChoosePowersource();

            if (userChoice == "1")
            {
                motorcycle = VehicleFactory.CreateVehicle(i_LicenePlate, VehicleFactory.eVehicleType.ElectricMotorcycle, modelName, airPressure, engineVolume, licenseType);
            }
            else if (userChoice == "2")
            {
                motorcycle = VehicleFactory.CreateVehicle(i_LicenePlate, VehicleFactory.eVehicleType.FueledMotorcycle, modelName, airPressure, engineVolume, licenseType);
            }

            VehicleInGarage carInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, motorcycle);
            m_Garage.AddVehicleToGarage(carInGarage);
        }

        private void addTruck(string i_LicensePlate, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string userChoice;
            string modelName;
            bool correctChoice;
            bool cooledTrunk;
            float trunkVolume; 
            List<float> airPressure;
            Vehicle truck = null;

            Console.WriteLine("Please enter the model name of the truck:");
            modelName = Console.ReadLine();
            airPressure = checkAndCreateAirPressureList(Truck.NumOfTires, Truck.MaxTirePressure);

            do
            {
                Console.WriteLine("Type true for cooled trunk, false else");
                correctChoice = bool.TryParse(Console.ReadLine(), out cooledTrunk);
                if (correctChoice == false)
                {
                    Console.WriteLine("Invalid input");
                }
            }
            while (correctChoice == false);
           
            do
            {
                Console.WriteLine("Please enter the trunk volume:");
                userChoice = Console.ReadLine();
                correctChoice = float.TryParse(Console.ReadLine(), out trunkVolume);
                if (correctChoice == false)
                {
                    Console.WriteLine("Invalid input");
                }
            }
            while (correctChoice == false);

            userChoice = checkAndChoosePowersource();

            if (userChoice == "1")
            {
                truck = VehicleFactory.CreateVehicle(i_LicensePlate, VehicleFactory.eVehicleType.ElectricMotorcycle, modelName, airPressure, cooledTrunk, trunkVolume);
            }
            else if (userChoice == "2")
            {
                truck = VehicleFactory.CreateVehicle(i_LicensePlate, VehicleFactory.eVehicleType.FueledMotorcycle, modelName, airPressure, cooledTrunk, trunkVolume);
            }

            VehicleInGarage carInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, truck);
            m_Garage.AddVehicleToGarage(carInGarage);
        }

        private List<float> checkAndCreateAirPressureList(byte i_NumOfTires, float i_MaxTirePressure)
        {
            List<float> airPressure = new List<float>(i_NumOfTires);
            string airPressureToAdd;

            while (airPressure.Count < i_NumOfTires)
            {
                Console.WriteLine("Please enter the air pressure of tire number {0}", airPressure.Count + 1);
                airPressureToAdd = Console.ReadLine();
                try
                {
                    airPressure.Add(float.Parse(airPressureToAdd));
                    if (airPressure[airPressure.Count] > i_MaxTirePressure)
                    {
                        ValueOutOfRangeException ex = new ValueOutOfRangeException();

                        throw ex;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid value.");
                }

            }

            return airPressure;
        }

        private string checkAndChoosePowersource()
        {
            string userChoice;
            bool correctChoice = false;

            do
            {
                Console.WriteLine("Please choose your car power source{0}1.{1}{0}2.{2}", Environment.NewLine,
                    Enum.GetName(typeof(Vehicle.ePowersource), Vehicle.ePowersource.Battery),
                    Enum.GetName(typeof(Vehicle.ePowersource), Vehicle.ePowersource.Fuel));
                userChoice = Console.ReadLine();
                correctChoice = Enum.IsDefined(typeof(Vehicle.ePowersource), userChoice);
                if (correctChoice == false)
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            while (correctChoice == false);

            return userChoice;
        }
    }
}
