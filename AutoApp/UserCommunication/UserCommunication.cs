
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
using AutoApp.Data;

namespace AutoApp.UserCommunication
{

    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<Car> _carRepository;
        private readonly ICsvReader _csvReader;
        private readonly AutoAppDbContext _dbContext;
        public UserCommunication(IRepository<Car> carRepository, ICsvReader csvReader, AutoAppDbContext dbContext) 
        { 
            _carRepository = carRepository;
            _csvReader = csvReader;
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }
        public void AddCar()
        {
        
            
        }

        public void FindCarForBrand()
        {
           
        }

        public void FindCarForColor()
        {
           
        }
        public void FindCarForStartLetters()
        {
          
        }
        public void FindCarForPrice()
        {
          
        }

        public void FindCarForTypeOfDrive()
        {
          
        }

        public void RemoveCar()
        {
           
        }

        public void ShowAllCars()
        {
            
        }

        public void FindCarFromCsvFile()
        {
            var columns = _csvReader.ProcessCars("Resources/Files/fuel.csv");
            
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

        public void ReadCarsFromCsvFileEndAddToDatabase()
        {
            var cars = _csvReader.ProcessCars("Resources/Files/fuel.csv");

            foreach(var car in cars)
            {
               _dbContext.Cars.Add(new Car()
               {
                   Manufacturer = car.Manufacturer,
                   Name = car.Name,
                   Year = car.Year,
                   City = car.City,
                   Combined = car.Combined,
                   Cylinders = car.Cylinders,
                   Displacement = car.Displacement,
                   Higway = car.Higway,
               });
            }
            
            _dbContext.SaveChanges();
        }
    }
}
