using AutoApp.DataProviders;
using AutoApp.Entities;
using AutoApp.Repositories;
using AutoApp.UserCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp
{
    public class App : IApp
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IUserCommunication _userCommunication;
        
        public App(IRepository<Car> carRepository, IUserCommunication userCommunication)
        {
            _carRepository = carRepository;
            _userCommunication = userCommunication;
        }
        public void Run()
        {
            _carRepository.GetAll();
            _carRepository.ItemAdded += EventAdded;
            _carRepository.ItemDeleted += EventDeleted;

            var num = "";
            Console.WriteLine("|*----------------------MAIN MENU---------------------*|");
            while (num != "q")
            {
                
                Console.WriteLine();
                Console.WriteLine("-1- ADD CAR ");
                Console.WriteLine("-2- DELETE CAR ");
                Console.WriteLine("-3- READ ALL CARS ");
                Console.WriteLine("-4- FIND CAR FOR A BRAND ");
                Console.WriteLine("-5- FIND CAR FOR A VALUE OF PRICE (FROM - TO) ");
                Console.WriteLine("-6- FIND CAR FOR A TYPE OF DRIVE (2D OR 4D) ");
                Console.WriteLine("-7- FIND CAR FOR A COLOR ");
                Console.WriteLine("-8- FIND CAR FOR START LETTERS ");
                Console.WriteLine("-q- END ");

                num = Console.ReadLine();

                switch (num)
                {
                    case "1": _userCommunication.AddCar(); break;
                    case "2": _userCommunication.RemoveCar(); break;
                    case "3": _userCommunication.ShowAllCars(); break;
                    case "4": _userCommunication.FindCarForBrand(); break;
                    case "5": _userCommunication.FindCarForPrice(); break;
                    case "6": _userCommunication.FindCarForTypeOfDrive(); break;
                    case "7": _userCommunication.FindCarForColor(); break;
                    case "8": _userCommunication.FindCarForStartLetters(); break;
                    case "q": break;
                    default: break;
                }
            }

            Console.WriteLine("|*-------------------THANK YOU FOR COMING--------------------*|");

          
            void EventAdded(object? sender, Car e)
            {
                DateTime dateTime = DateTime.Now;
                Console.WriteLine($"{e.BrandName} added from {sender.GetType().Name}");
                using (var writer = File.AppendText("logs.txt"))
                {
                    writer.WriteLine($"[{dateTime}]-ItemAdded-[{e.BrandName}]");
                }
            }

            void EventDeleted(object? sender, Car e)
            {
                DateTime dateTime = DateTime.Now;
                Console.WriteLine($"{e.BrandName} deleted from {sender.GetType().Name}");
                using (var writer = File.AppendText("logs.txt"))
                {
                    writer.WriteLine($"[{dateTime}]-ItemDeleted-[{e.BrandName}]");
                }
            }
        }

        
        
    }
}
