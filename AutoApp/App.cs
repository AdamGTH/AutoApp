using AutoApp.Data.Repositories;
using AutoApp.Components.DataProviders;
using AutoApp.Events;
using AutoApp.Data.Repositories.Extensions;
using AutoApp.UserCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoApp.Data.Entities;
using AutoApp.Data.UserCommunication;

namespace AutoApp
{
    public class App : IApp
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IUserCommunication _userCommunication;
        private readonly IEventsMethods _eventsMethods;
        public App(IRepository<Car> carRepository, IUserCommunication userCommunication, IEventsMethods eventsMethods)
        {
            _carRepository = carRepository;
            _userCommunication = userCommunication;
            _eventsMethods = eventsMethods;
        }
        public void Run()
        {
            _carRepository.GetAll();
            _carRepository.ItemAdded += _eventsMethods.EventAdded;
            _carRepository.ItemDeleted += _eventsMethods.EventDeleted;

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
                Console.WriteLine("-9- READ DATA FROM CSV FILE ");
                Console.WriteLine("-10- JOIN METHOD LINQ WITH CSV FILES ");
                Console.WriteLine("-11- GROUP END JOIN METHOD ");
                Console.WriteLine("-12- CREATE XML FILE ");
                Console.WriteLine("-13- READ XML ");
                Console.WriteLine("-14- XML TO HOME WORK ");
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
                    case "9": _userCommunication.FindCarFromCsvFile(); break;
                    case "10": _userCommunication.JoinMethods(); break;
                    case "11": _userCommunication.GroupJoinMethod(); break;
                    case "12": _userCommunication.CreateXml(); break;
                    case "13": _userCommunication.ReadXml(); break;
                    case "14": _userCommunication.CreateXmlToHomeWork(); break;
                    case "q": break;
                    default: break;
                }
            }

            Console.WriteLine("|*-------------------THANK YOU FOR COMING--------------------*|");

                     
        }

        
        
    }
}
