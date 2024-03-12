using AutoApp.Components.DataProviders;
using AutoApp.Components.CsvReader;
using AutoApp.Data.Entities;
using AutoApp.Data.Repositories;
using AutoApp.Data.UserCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Net.Sockets;

namespace AutoApp.UserCommunication
{
    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<Car> _carRepository;
        private readonly ICarsProvider _carsProvider;
        private readonly ICsvReader _csvReader;
        public UserCommunication(IRepository<Car> carRepository, ICarsProvider carsProvider, ICsvReader csvReader) 
        { 
            _carRepository = carRepository;
            _carsProvider = carsProvider;
            _csvReader = csvReader;
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

        public void FindCarFromCsvFile()
        {
            var columns = _csvReader.ProcessCars("Resources/Files/fuel.csv");
            //foreach (var column in columns)
            //{
            //    Console.WriteLine($"{column.Manufacturer} {column.Name} " +
            //        $"{column.Year} {column.Combined} {column.Displacement} {column.City} {column.Cylinders}");
            //}

            var groups = columns.GroupBy(x => x.Manufacturer)
                   .Select(g => new
                   {
                       Name = g.Key,
                       Max = g.Max(c => c.Combined),
                       Average = g.Average(c => c.Combined),
                   })
                   .OrderBy(x => x.Average);
            foreach (var group in groups)
            {
                Console.WriteLine($"Name: {group.Name}");
                Console.WriteLine($"\t Max: {group.Max}");
                Console.WriteLine($"\t Average: {group.Average:F2}");
                Console.WriteLine();
            }
        }

        public void JoinMethods()
        {
            var cars = _csvReader.ProcessCars("Resources/Files/fuel.csv");
            var manufacturers = _csvReader.ProcessManufacturer("Resources/Files/manufacturers.csv");

            var carsIcountry = cars.Join(manufacturers, x=>x.Manufacturer, x=>x.Name,
                (car, manufacturer)=> 
                new
                {
                    manufacturer.Country,
                    car.Name,
                    car.Combined
                })
                .OrderByDescending(x=>x.Combined)
            .ThenBy(x=>x.Name);

            foreach (var group in carsIcountry)
            {
                Console.WriteLine($"Country: {group.Country}");
                Console.WriteLine($"\t name: {group.Name}");
                Console.WriteLine($"\t Combined: {group.Combined}");
                Console.WriteLine();
            }
        }

        public void GroupJoinMethod()
        {
            var cars = _csvReader.ProcessCars("Resources/Files/fuel.csv");
            var manufacturers = _csvReader.ProcessManufacturer("Resources/Files/manufacturers.csv");

            var groups = manufacturers.GroupJoin(
                cars,
                manufacturers => manufacturers.Name,
                car => car.Manufacturer,
                (m, g) =>
                new
                {
                    Manufacturer = m,
                    Cars = g
                })
                .OrderBy(x => x.Manufacturer.Name);

            foreach (var group in groups)
            {
                Console.WriteLine($"Manufacturer: {group.Manufacturer.Name}");
                Console.WriteLine($"\t Cars: {group.Cars.Count()}");
                Console.WriteLine($"\t Max: {group.Cars.Max(x=>x.Combined)}");
                Console.WriteLine($"\t Min: {group.Cars.Min(x=>x.Combined)}");
                Console.WriteLine($"\t Average: {group.Cars.Average(x => x.Combined)}");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void CreateXml()
        {
            var records = _csvReader.ProcessCars("Resources/Files/fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars", records
                .Select(x =>
                new XElement("Car",
                    new XAttribute("Name", x.Name),
                    new XAttribute("Combined", x.Combined),
                    new XAttribute("Manufacturer", x.Manufacturer)
                )));

            document.Add(cars);
            document.Save("fuel.xml");
        }

        public void ReadXml()
        {
            var document = XDocument.Load("fuel.xml");
            var names = document
                .Element("Cars")?
                .Elements("Car")
                .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
                .Select(x => x.Attribute("Name")?.Value);

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
          
        }

        public void CreateXmlToHomeWork()
        {
            var cars = _csvReader.ProcessCars("Resources/Files/fuel.csv");
            var manufacturers = _csvReader.ProcessManufacturer("Resources/Files/manufacturers.csv");
            var joinedRecords = cars.Join(manufacturers, x => x.Manufacturer, x => x.Name,
                (car, manufacturer) =>
                new
                {
                   Country =  manufacturer.Country,
                   Manufacturer =  manufacturer.Name,
                   Model =  car.Name,
                   Combined =  car.Combined
                });
            var groupByManufacturer = joinedRecords.GroupBy(g => g.Manufacturer);
            
            var document = new XDocument();

            var dataXml = new XElement("Manufacturers", groupByManufacturer.Select(x =>
                            new XElement("Manufacturer", new XAttribute("Name", x.Key), 
                                                         new XAttribute("Country", x.Select(y=>y.Country).First()), 
                               new XElement("Cars", new XAttribute("Country", x.Select(y => y.Country).First()),
                                                    new XAttribute("CombinedSum", x.Sum(c=>c.Combined)) ),x.Select(y=>
                                  new XElement("Car", new XAttribute("Model", y.Model),
                                                      new XAttribute("Combined", y.Combined))))).OrderBy(o=>o.Name));
              
            document.Add(dataXml);
            document.Save("HomeWork.xml");
        }
    }
}
