using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private Garage m_Garage = new Garage();

        private enum eUserChoice 
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
                runMenuChoice(userChoice);
            }
            while (userChoice != eUserChoice.Quit);
        }

        private eUserChoice getUserInput()
        {
            eUserChoice userChoice;
            int userInput = 0;
            bool validInput = false;

            do
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    validInput = Enum.IsDefined(typeof(eUserChoice), userInput);
                    if (validInput == false)
                    {
                        Console.WriteLine("Invalid Option");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input");
                    validInput = false;
                }
            }
            while (validInput == false);

            userChoice = (eUserChoice)userInput;
         
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
                presentCarLicensePlateList();
            }
            else if (i_UserChoice == eUserChoice.ChangeVehicleStatus)
            {
                changeVehicleStatus();
            }
            else if (i_UserChoice == eUserChoice.InflateVehicleTires)
            {
                inflateVehicleTires();
            }
            else if (i_UserChoice == eUserChoice.FillVehicleFuel)
            {
                fillVehicleFuel();
            }
            else if (i_UserChoice == eUserChoice.ChargeVehicleBattery)
            {
                chargeVehicleBattery();
            }
            else if (i_UserChoice == eUserChoice.ShowVehicleInformation)
            {
                showVehicleInformation();
            }
        }

        private void addVehicle()
        {
            bool validInput = false;
            uint userChoice;
            string licensePlate = null;
            string ownerName = null;
            string ownerPhoneNumber;
            string vehicleOptions;

            vehicleOptions = string.Format(
                                    "Please choose the vehicle you want to enter{0}" +
                                    "For Car press 1{0}" +
                                    "For Motorcycle press 2{0}" +
                                    "For Truck press 3", 
                                    Environment.NewLine);
            Console.WriteLine("Please enter the License Plate number: ");
            do
            {
                licensePlate = Console.ReadLine();
                if (licensePlate == string.Empty)
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            while (licensePlate == string.Empty);
           
            if (m_Garage.CheckIfVehicleExists(licensePlate) == true)
            {
                m_Garage.GetVehicleByLicensePlate(licensePlate).VehicleStatus = VehicleInGarage.eVehicleStatus.InProgress;
            }
            else
            {
                Console.WriteLine("Please enter the owner name: ");
                do
                {
                    ownerName = Console.ReadLine();
                    if (ownerName == string.Empty)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                while (ownerName == string.Empty);

                Console.WriteLine("Please enter the owner phone number: ");
                do
                {
                    ownerPhoneNumber = Console.ReadLine();
                    try
                    {
                        validInput = Regex.IsMatch(ownerPhoneNumber, @"^\d+$");
                        if (validInput == false)
                        {
                            Console.WriteLine("Invalid phone number");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid phone number");
                        validInput = false;
                    }     
                }
                while (validInput == false);

                Console.WriteLine(vehicleOptions);
                parsingValidity(out userChoice, VehicleFactory.NumberOfSupportedVehicles);
                if (userChoice == 1)
                {
                    addCar(licensePlate, ownerName, ownerPhoneNumber);
                }
                else if (userChoice == 2)
                {
                    addMotorcycle(licensePlate, ownerName, ownerPhoneNumber);
                }
                else if (userChoice == 3)
                {
                    addTruck(licensePlate, ownerName, ownerPhoneNumber);
                }
            }

            Console.WriteLine("-------------");
        }

        private void addCar(string i_LicensePlate, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string userChoice;
            string modelName;
            bool correctChoice;
            Car.eCarDoors numOfDoors;
            Car.eCarColor carColor;
            List<string> tireManufacturer;
            List<float> airPressure;
            Vehicle car = null;

            Console.WriteLine("Please enter the model name of the car:");
            modelName = Console.ReadLine();
            Console.WriteLine("Please enter the names of all the tires manufacturers:");
            tireManufacturer = createTireManufacturerList(Car.NumOfTires);
            airPressure = checkAndCreateAirPressureList(Car.NumOfTires, Car.MaxTirePressure);

            do
            {
                Console.WriteLine("Please choose how many doors the car has:");
                printEnumNames(typeof(Car.eCarDoors));
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
                Console.WriteLine("Please choose the color of the car:");
                printEnumNames(typeof(Car.eCarColor));
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

            if (userChoice == "Battery")
            {
                car = VehicleFactory.CreateVehicle(i_LicensePlate, VehicleFactory.eVehicleType.ElectricCar, modelName, airPressure, tireManufacturer, carColor, numOfDoors);
            }
            else if (userChoice == "Fuel")
            {
                car = VehicleFactory.CreateVehicle(i_LicensePlate, VehicleFactory.eVehicleType.FueledCar, modelName, airPressure, tireManufacturer, carColor, numOfDoors);
            }

            VehicleInGarage carInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, car);
            m_Garage.AddVehicleToGarage(carInGarage);
        }

        private void addMotorcycle(string i_LicensePlate, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string userChoice;
            string modelName;
            bool correctChoice;
            Motorcycle.eMotorcycleLicenseType licenseType;
            List<string> tireManufacturer;
            int engineVolume;
            List<float> airPressure;
            Vehicle motorcycle = null;

            Console.WriteLine("Please enter the model name of the motorcycle:");
            modelName = Console.ReadLine();
            Console.WriteLine("Please enter the names of all the tires manufacturers:");

            tireManufacturer = createTireManufacturerList(Motorcycle.NumOfTires);
            airPressure = checkAndCreateAirPressureList(Motorcycle.NumOfTires, Motorcycle.MaxTirePressure);

            do
            {
                Console.WriteLine("Please choose the license type of the motorcycle:");
                printEnumNames(typeof(Motorcycle.eMotorcycleLicenseType));
                userChoice = Console.ReadLine();
                correctChoice = Enum.IsDefined(typeof(Motorcycle.eMotorcycleLicenseType), userChoice);
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

            if (userChoice == "Battery")
            {
                motorcycle = VehicleFactory.CreateVehicle(i_LicensePlate, VehicleFactory.eVehicleType.ElectricMotorcycle, modelName, airPressure, tireManufacturer, engineVolume, licenseType);
            }
            else if (userChoice == "Fuel")
            {
                motorcycle = VehicleFactory.CreateVehicle(i_LicensePlate, VehicleFactory.eVehicleType.FueledMotorcycle, modelName, airPressure, tireManufacturer, engineVolume, licenseType);
            }

            VehicleInGarage carInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, motorcycle);
            m_Garage.AddVehicleToGarage(carInGarage);
        }

        private void addTruck(string i_LicensePlate, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string modelName;
            bool correctChoice;
            bool cooledTrunk = false;
            float trunkVolume = 0f;
            List<string> tireManufacturer;
            List<float> airPressure;
            Vehicle truck = null;

            Console.WriteLine("Please enter the model name of the truck:");
            modelName = Console.ReadLine();
            Console.WriteLine("Please enter the names of all the tires manufacturers:");

            tireManufacturer = createTireManufacturerList(Truck.NumOfTires);
            airPressure = checkAndCreateAirPressureList(Truck.NumOfTires, Truck.MaxTirePressure);

            do
            {
                Console.WriteLine("Type true for cooled trunk, false else");
                try
                {
                    cooledTrunk = bool.Parse(Console.ReadLine());
                    correctChoice = true;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please enter valid value.");
                    correctChoice = false;
                }
            }
            while (correctChoice == false);
           
            do
            {
                Console.WriteLine("Please enter the trunk volume:");
                try
                {
                    trunkVolume = float.Parse(Console.ReadLine());
                    correctChoice = true;
                }
                catch(FormatException)
                {
                    correctChoice = false;
                    Console.WriteLine("Please enter a valid value.");
                }
            }
            while (correctChoice == false);
            
            truck = VehicleFactory.CreateVehicle(i_LicensePlate, VehicleFactory.eVehicleType.Truck, modelName, airPressure, tireManufacturer, cooledTrunk, trunkVolume);

            VehicleInGarage carInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, truck);
            m_Garage.AddVehicleToGarage(carInGarage);
        }

        private List<float> checkAndCreateAirPressureList(byte i_NumOfTires, float i_MaxTirePressure)
        {
            List<float> airPressure = new List<float>(i_NumOfTires);
            string airPressureToAdd;
            int currentTire = 0;

            while (airPressure.Count < i_NumOfTires)
            {
                Console.WriteLine("Please enter the air pressure of tire number {0}", airPressure.Count + 1);
                airPressureToAdd = Console.ReadLine();
                try
                {
                    airPressure.Add(float.Parse(airPressureToAdd));
                    if (airPressure[currentTire] > i_MaxTirePressure)
                    {
                        ValueOutOfRangeException ex = new ValueOutOfRangeException();

                        throw ex;
                    }

                    currentTire++;
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("Invalid value.");
                    airPressure.RemoveAt(currentTire);
                    currentTire--;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid value.");
                }
            }

            return airPressure;
        }

        private List<string> createTireManufacturerList(byte i_NumOfTires)
        {
            List<string> tireManufacturerList = new List<string>(i_NumOfTires);

            for(int i = 0; i < i_NumOfTires; i++)
            {
                tireManufacturerList.Add(Console.ReadLine());
            }

            return tireManufacturerList;
        }

        private string checkAndChoosePowersource()
        {
            string userChoice;
            bool correctChoice = false;

            do
            {
                Console.WriteLine("Please choose your car power source:");
                printEnumNames(typeof(Vehicle.ePowersource));
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

        private void presentCarLicensePlateList()
        {
            string userMessage;
            uint userChoice;
            bool v_UnFilteredResults = true;
            List<VehicleInGarage> vehiclesToPrint = null;

            userMessage = string.Format(
                                 "Please choose the sorting method of the vehicles:{0}" +
                                 "For Vehicles {1} press 1{0}" +
                                 "For Vehicles {2} press 2{0}" +
                                 "For Vehicles {3} press 3{0}" +
                                 "For all the vehicles press 4", 
                                 Environment.NewLine,
                                 Enum.GetName(typeof(VehicleInGarage.eVehicleStatus), 1),
                                 Enum.GetName(typeof(VehicleInGarage.eVehicleStatus), 2),
                                 Enum.GetName(typeof(VehicleInGarage.eVehicleStatus), 3));
            Console.WriteLine(userMessage);
            parsingValidity(out userChoice, 4);
            Console.WriteLine("The vehicles are:");
            if (userChoice == 1)
            {
                vehiclesToPrint = m_Garage.SortVehiclesByStatus(VehicleInGarage.eVehicleStatus.InProgress, !v_UnFilteredResults);
            }
            else if (userChoice == 2)
            {
                vehiclesToPrint = m_Garage.SortVehiclesByStatus(VehicleInGarage.eVehicleStatus.Fixed, !v_UnFilteredResults);
            }
            else if (userChoice == 3)
            {
                vehiclesToPrint = m_Garage.SortVehiclesByStatus(VehicleInGarage.eVehicleStatus.Paid, !v_UnFilteredResults);
            }
            else if (userChoice == 4)
            {
                vehiclesToPrint = m_Garage.SortVehiclesByStatus(VehicleInGarage.eVehicleStatus.InProgress, v_UnFilteredResults);
            }

            foreach (VehicleInGarage v in vehiclesToPrint)
            {
                Console.WriteLine(v.TheVehicle.LicensePlate);
            }

            Console.WriteLine("-------------");
        }

        private void changeVehicleStatus()
        {
            uint newStatus;
            string userMessage;
            string licensePlate;
            VehicleInGarage vehicleToChangeStatus;

            userMessage = string.Format(
                                 "Please choose the new status of the vehicle:{0}" +
                                 "For {1} press 1{0}" +
                                 "For {2} press 2{0}" +
                                 "For {3} press 3", 
                                 Environment.NewLine,
                                 Enum.GetName(typeof(VehicleInGarage.eVehicleStatus), 1),
                                 Enum.GetName(typeof(VehicleInGarage.eVehicleStatus), 2),
                                 Enum.GetName(typeof(VehicleInGarage.eVehicleStatus), 3));
            Console.WriteLine("Please enter the license plate of the vehicle:");
            licensePlate = Console.ReadLine();
            vehicleToChangeStatus = m_Garage.GetVehicleByLicensePlate(licensePlate);
            if (vehicleToChangeStatus != null)
            {
                Console.WriteLine(userMessage);
                parsingValidity(out newStatus, 3);
                vehicleToChangeStatus.VehicleStatus = (VehicleInGarage.eVehicleStatus)newStatus;
            }
            else
            {
                Console.WriteLine("Vehicle doesn't exist.");
            }

            Console.WriteLine("-------------");
        }

        private void parsingValidity(out uint o_UserChoice, uint i_MaxValue)
        {
            bool validChoice = false;
            o_UserChoice = 0;

            do
            {
                try
                {
                    o_UserChoice = uint.Parse(Console.ReadLine());
                    if ((o_UserChoice > i_MaxValue) || (o_UserChoice == 0))
                    {
                        Console.WriteLine("Invalid choice, please try again:");
                        validChoice = false;
                    }
                    else
                    {
                        validChoice = true;
                    }
                }
                catch(FormatException)
                {
                    validChoice = false;
                    Console.WriteLine("Please enter a valid choice.");
                }
            }
            while (validChoice == false);
        }

        private void inflateVehicleTires()
        {
            string licensePlate;
            VehicleInGarage vehicleToInflateTiresTo;

            Console.WriteLine("Please enter the license plate of the vehicle:");
            licensePlate = Console.ReadLine();
            vehicleToInflateTiresTo = m_Garage.GetVehicleByLicensePlate(licensePlate);
            if (vehicleToInflateTiresTo != null)
            {
                vehicleToInflateTiresTo.TheVehicle.InflateTiresToMax();
            }
            else
            {
                Console.WriteLine("Vehicle doesn't exist.");
            }

            Console.WriteLine("-------------");
        }

        private void fillVehicleFuel()
        {
            string licensePlate;
            string fuelType;
            bool validFuelType;
            bool validFuelAmount;
            float amountToFill = 0f;
            VehicleInGarage vehicleToAddFuel;
            Fuel.eFuelType fuelToFill;

            Console.WriteLine("Please enter the license plate of the vehicle:");
            licensePlate = Console.ReadLine();
            vehicleToAddFuel = m_Garage.GetVehicleByLicensePlate(licensePlate);
            if ((vehicleToAddFuel != null) && (vehicleToAddFuel.TheVehicle.Powersource is Fuel))
            {
                Console.WriteLine("Please enter the type of fuel to fill:");
                do
                {
                    fuelType = Console.ReadLine();
                    validFuelType = Enum.IsDefined(typeof(Fuel.eFuelType), fuelType);
                    if (validFuelType == false)
                    {
                        Console.WriteLine("Invalid fuel type, please try again:");
                    }
                }
                while(validFuelType == false);

                fuelToFill = (Fuel.eFuelType)Enum.Parse(typeof(Fuel.eFuelType), fuelType);
                Console.WriteLine("Please enter the amount of fuel to fill");
                do
                {
                    try
                    {
                        amountToFill = float.Parse(Console.ReadLine());
                        validFuelAmount = true;
                    }
                    catch(FormatException)
                    {
                        validFuelAmount = false;
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
                while(validFuelAmount == false);

                try
                {
                    vehicleToAddFuel.TheVehicle.FillPowerSource(amountToFill, fuelToFill);
                }
                catch(ValueOutOfRangeException)
                {
                    Console.WriteLine("Can't fill the tank with the current amount.");
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Invalid fuel type.");
                }
            }
            else
            {
                Console.WriteLine("Vehicle doesn't exist or doesn't use fuel.");
            }

            Console.WriteLine("-------------");
        }

        private void chargeVehicleBattery()
        {
            string licensePlate;
            float amountToCharge = 0f;
            bool validChargeAmount;
            VehicleInGarage vehicleToCharge;

            Console.WriteLine("Please enter the license plate of the vehicle:");
            licensePlate = Console.ReadLine();
            vehicleToCharge = m_Garage.GetVehicleByLicensePlate(licensePlate);
            if ((vehicleToCharge != null) && (vehicleToCharge.TheVehicle.Powersource is Battery))
            {
                Console.WriteLine("Please enter the amount of electricity to charge");
                do
                {
                    try
                    {
                        amountToCharge = float.Parse(Console.ReadLine());
                        validChargeAmount = true;
                    }
                    catch(FormatException)
                    {
                        validChargeAmount = false;
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
                while (validChargeAmount == false);

                try
                {
                    vehicleToCharge.TheVehicle.FillPowerSource(amountToCharge);
                }
                catch(ValueOutOfRangeException)
                {
                    Console.WriteLine("Can't charge the battery with the current amount.");
                }
            }
            else
            {
                Console.WriteLine("Vehicle doesn't exist or doesn't use a battery.");
            }

            Console.WriteLine("-------------");
        }

        private void showVehicleInformation()
        {
            string licensePlate;
            string displayInformation;

            VehicleInGarage theVehicle;

            Console.WriteLine("Please enter the vehicle license plate:");

            licensePlate = Console.ReadLine();

            theVehicle = m_Garage.GetVehicleByLicensePlate(licensePlate);

            if(theVehicle != null)
            {
                displayInformation = string.Format(
                                            "Vehicle Information:{0}License Plate:{1}{0}Model Name:{2}{0}Owner's Name:{3}{0}Garage Status:{4}",
                                            Environment.NewLine,
                                            licensePlate,
                                            theVehicle.TheVehicle.ModelName,
                                            theVehicle.OwnerName,
                                            theVehicle.VehicleStatus);
                
                Console.WriteLine(displayInformation);
                if (theVehicle.TheVehicle.Powersource is Fuel)
                {
                    displayInformation = string.Format(
                                                "Current Fuel stats: {1}{0}Fuel Type: {2}",
                                                Environment.NewLine,
                                                theVehicle.TheVehicle.Powersource.CurrentState,
                                                ((Fuel)theVehicle.TheVehicle.Powersource).FuelType);
                }
                else
                {
                    displayInformation = string.Format("Current Battery stats: {0}", theVehicle.TheVehicle.Powersource.CurrentState);
                }

                Console.WriteLine(displayInformation);
                Console.WriteLine("Tire Information: ");

                foreach (Tire tire in theVehicle.TheVehicle.Tires)
                {
                    displayInformation = string.Format("Model name: {1}, Air pressure: {2}", Environment.NewLine, tire.TireManufacturer, tire.CurrentAirPressure);
                    Console.WriteLine(displayInformation);
                }

                if (theVehicle.TheVehicle is Car)
                {
                    displayInformation = string.Format(
                                                "Number of doors in car: {1}{0}" +
                                                "Car color {2}",
                                                Environment.NewLine,
                                                ((Car)theVehicle.TheVehicle).NumOfDoors,
                                                ((Car)theVehicle.TheVehicle).CarColor);
                    Console.WriteLine(displayInformation);
                }
                else if (theVehicle.TheVehicle is Motorcycle)
                {
                    displayInformation = string.Format(
                                                "Engine Volume: {1}{0}" +
                                                "License Type: {2}",
                                                Environment.NewLine,
                                                ((Motorcycle)theVehicle.TheVehicle).EngineVolume,
                                                ((Motorcycle)theVehicle.TheVehicle).LicensePlate);
                    Console.WriteLine(displayInformation);
                }
                else if (theVehicle.TheVehicle is Truck)
                {
                    displayInformation = string.Format(
                                                "Cooled Trunk: {1}{0}" +
                                                "Trunk Volume: {2}",
                                                Environment.NewLine,
                                                ((Truck)theVehicle.TheVehicle).CooledTrunk,
                                                ((Truck)theVehicle.TheVehicle).TrunkVolume);
                    Console.WriteLine(displayInformation);
                }
            }
            else
            {
                Console.WriteLine("Vehicle doesn't exist.");
            }

            Console.WriteLine("-------------");
        }

        private void printEnumNames(Type i_EnumType)
        {
            string[] toPrint = Enum.GetNames(i_EnumType);

            for(int i = 0, j = 1; i < toPrint.Length; i++, j++)
            {
                Console.WriteLine("{0}.{1}", j, toPrint[i]);
            }
        }
    }
}
