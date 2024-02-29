using AutoApp.DataProviders;
using AutoApp.Entities;
using AutoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.UserCommunication
{
    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<Car> _carRepository;
        private readonly ICarsProvider _carsProvider;
        public UserCommunication(IRepository<Car> carRepository, ICarsProvider carsProvider) 
        { 
            _carRepository = carRepository;
            _carsProvider = carsProvider;
        }
        public void AddCar()
        {
            Console.WriteLine("|*-------------------ADD CAR TO FILE--------------------*|");
            Console.WriteLine("BRAND: ");
            var name = Console.ReadLine();
            Console.WriteLine("TYPE OF FUEL: ");
            var fuel = Console.ReadLine();
            Console.WriteLine("TYPE OF DRIVE: (2D OR 4D)");
            var typeOfDrive = Console.ReadLine();
            Console.WriteLine("COLOR: ");
            var color = Console.ReadLine();
            Console.WriteLine("PRICE: ");
            var priceStr = Console.ReadLine();
            var priceInt = 0;
            if (int.TryParse(priceStr, out var quantity))
            {
                priceInt = quantity;
            }
            else
            {
                Console.WriteLine("Error value!!!");
            }
            _carRepository.Add(new Car
            {
                BrandName = name,
                TypeOfEngine = fuel,
                Price = priceInt,
                TypeOfDrive = typeOfDrive,
                Color = color
            });
            _carRepository.Save();
            Console.WriteLine();
            Console.WriteLine("|*----------------------MAIN MENU---------------------*|");
        }

        public void FindCarForBrand()
        {
            Console.WriteLine("Podaj markę której szukasz: ");
            var brand = Console.ReadLine();
            var cars = _carsProvider.GetSpecificCarsForBrand(brand.ToUpper());
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        public void FindCarForColor()
        {
            Console.WriteLine("Podaj kolor: ");
            var color = Console.ReadLine();
            var cars = _carsProvider.GetSpecificCarsForColor(color.ToUpper());
            foreach(var car in cars)
            {
                Console.WriteLine(car); 
            }
        }
        public void FindCarForStartLetters()
        {
            Console.WriteLine("Podaj początkowe litery: ");
            var leter = Console.ReadLine();
            var cars = _carsProvider.WhereStartsWith(leter.ToUpper());
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
        public void FindCarForPrice()
        {
            Console.WriteLine("Podaj cenę minimalną: ");
            var minPriceS = Console.ReadLine();
            Console.WriteLine("Podaj cenę maxymalną: ");
            var maxPriceS = Console.ReadLine();
            var minPrice = int.Parse(minPriceS);
            var maxPrice = int.Parse(maxPriceS);
            var cars = _carsProvider.GetSpecificCarsForPrice(minPrice, maxPrice);
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        public void FindCarForTypeOfDrive()
        {
            Console.WriteLine("Podaj typ napędu (2D lub 4D): ");
            var typeOfDrive = Console.ReadLine();
            var listCars = _carsProvider.GetSpecificCarsForTypeOfDrive(typeOfDrive);
            foreach(var car in listCars)
            {
                Console.WriteLine(car);
            }
        }

        public void RemoveCar()
        {
            Console.WriteLine("|*-------------------REMOVE MENU--------------------*|");
            var items = _carRepository.GetAll();

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("SET NUMBER TO REMOVE OR 'q' ");
            var num = Console.ReadLine();

            if (int.TryParse(num, out var result))
            {
                _carRepository.Remove(_carRepository.GetById(result));
                _carRepository.Save();
            }
            else
            {
                if (num == "q")
                {
                    Console.WriteLine();
                    Console.WriteLine("|*----------------------MAIN MENU---------------------*|");
                    return;
                }
                Console.WriteLine("SOMETHING BROKE !");
            }
        }

        public void ShowAllCars()
        {
            Console.WriteLine("|*-------------------ALL ITEMS--------------------*|");
            var items = _carsProvider.ChunkCars(50);

            foreach (var item in items)
            {
                foreach (var car in item)
                {
                    Console.WriteLine(car);
                }
                Console.WriteLine();
                Console.WriteLine("------------ End Page ------------");
                Console.WriteLine();
            }
            Console.WriteLine("q - wyjście");
            var num = Console.ReadLine();
            if (num == "q")
            {
                Console.WriteLine();
                Console.WriteLine("|*----------------------MAIN MENU---------------------*|");
                return;
            }
        }
    }
}
