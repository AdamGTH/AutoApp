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

namespace AutoApp
{
    public class App : IApp
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IUserCommunication _userCommunication;
        private readonly IEventsMethods _eventsMethods;
        
        public App(IRepository<Car> carRepository, IUserCommunication userCommunication, IEventsMethods eventsMethods, AutoAppDbContext dbContext)
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
                Console.WriteLine("-4- ADD CARS TO DATABASE FROM CSV FILE ");

                Console.WriteLine("-q- END ");

                num = Console.ReadLine();

                switch (num)
                {
                    case "1": _userCommunication.AddCar(); break;
                    case "2": _userCommunication.RemoveCar(); break;
                    case "3": _userCommunication.ShowAllCars(); break;
                    case "4": _userCommunication.ReadCarsFromCsvFileEndAddToDatabase(); break;
                    
                    case "q": break;
                    default: break;
                }
            }

            Console.WriteLine("|*-------------------THANK YOU FOR COMING--------------------*|");

                     
        }

        
        
    }
}
