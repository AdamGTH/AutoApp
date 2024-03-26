using AutoApp.Data.Repositories;

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
using AutoApp.Data;
using AutoApp.Components;

namespace AutoApp
{
    public class App : IApp
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IUserCommunication _userCommunication;
        private readonly IEventsMethods _eventsMethods;
        private readonly IMenu _menu;
        
        public App(IRepository<Car> carRepository, IUserCommunication userCommunication, IEventsMethods eventsMethods, IMenu menu)
        {
            
            _carRepository = carRepository;
            _userCommunication = userCommunication;
            _eventsMethods = eventsMethods;
            _menu = menu;
            
        }
        public void Run()
        {
            _carRepository.ItemAdded += _eventsMethods.EventAdded;
            _carRepository.ItemDeleted += _eventsMethods.EventDeleted;
            _carRepository.ItemSaved += _eventsMethods.EventSaved;

            var num = "";
            _menu.ShowMainMenu();
            while (num != "q")
            {
                Console.WriteLine();
                Console.WriteLine("-1- ADD CAR ");
                Console.WriteLine("-2- DELETE CAR ");
                Console.WriteLine("-3- READ ALL CARS FROM DATABASE ");
                Console.WriteLine("-4- READ ALL CARS FROM FILE AND ADD TO DATABASE ");
                Console.WriteLine("-5- GET CAR BY ID ");
                Console.WriteLine("-6- UPDATE CAR ");

                Console.WriteLine("-q- END ");

                num = Console.ReadLine();

                switch (num)
                {
                    case "1": _userCommunication.AddCar(); break;
                    case "2": _userCommunication.RemoveCar(); break;
                    case "3": _userCommunication.ReadAllCars(); break;
                    case "4": _userCommunication.ReadCarsFromFileAndAddToDB(); break;
                    case "5": _userCommunication.ReadById(); break;
                    case "6": _userCommunication.UpdateCar(); break;

                    case "q": break;
                    default: break;
                }
            }

            _menu.Goodby();

                     
        }

        
        
    }
}
