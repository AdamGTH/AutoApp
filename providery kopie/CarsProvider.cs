using AutoApp.Data.Entities;
using AutoApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoApp.Components.DataProviders
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carRepository;

        public CarsProvider(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public List<Car[]> ChunkCars(int size)
        {
            var cars = _carRepository.GetAll();
            return cars.Chunk(size).ToList();
        }

        public Car FirstByName(string name)
        {
            var cars = _carRepository.GetAll();
            return cars.First(car => car.BrandName == name);
        }

        public Car? FirstOrDefaultByName(string name)
        {
            var cars = _carRepository.GetAll();
            return cars.FirstOrDefault(car => car.BrandName == name);
        }

        public Car FirstOrDefaultByNameWithDefault(string name)
        {
            var cars = _carRepository.GetAll();
            return cars.FirstOrDefault(car => car.BrandName == name, new Car { Id = -1, BrandName = "NOT FOUND" });
        }

        public List<Car> GetSpecificCarsForTypeOfDrive(string type)
        {
            var cars = _carRepository.GetAll();
            var listCars = cars.Where(car => car.TypeOfDrive == type).ToList();
            return listCars;
        }

        public List<Car> GetSpecificCarsForPrice(int minPrice, int maxPrice)
        {
            var cars = _carRepository.GetAll();
            var specList = cars.Where(car => car.Price > minPrice && car.Price < maxPrice).ToList();
            return specList;
        }
        public List<Car> GetSpecificCarsForBrand(string brand)
        {
            var cars = _carRepository.GetAll();
            var specList = cars.Where(car => car.BrandName == brand).ToList();
            return specList;
        }
        public List<Car> GetSpecificCarsForColor(string color)
        {
            var cars = _carRepository.GetAll();
            var specList = cars.Where(car => car.Color == color).ToList();
            return specList;
        }

        public List<Car> GetSpecificColumns()
        {
            var cars = _carRepository.GetAll();
            var specList = cars.Select(car => new Car
            {
                Id = car.Id,
                BrandName = car.BrandName
            }).ToList();

            return specList;
        }

        public Car LastByName(string name)
        {
            var cars = _carRepository.GetAll();
            return cars.Last(car => car.BrandName == name);
        }

        public List<Car> OrderbyName()
        {
            var cars = _carRepository.GetAll();
            return cars.OrderBy(car => car.BrandName).ToList();
        }

        public List<Car> OrderbyNameDescending()
        {
            var cars = _carRepository.GetAll();
            return cars.OrderByDescending(car => car.BrandName).ToList();
        }

        public Car SingleById(int id)
        {
            var cars = _carRepository.GetAll();
            return cars.Single(car => car.Id == id);
        }

        public Car? SingleOrDefaultById(int id)
        {
            var cars = _carRepository.GetAll();
            return cars.SingleOrDefault(car => car.Id == id);
        }

        public List<Car> SkipCars(int howMany)
        {
            throw new NotImplementedException();
        }

        public List<Car> SkipCarsWhileNameStartsWith(string prefix)
        {
            throw new NotImplementedException();
        }

        public List<Car> TakeCars(int howMany)
        {
            var cars = _carRepository.GetAll();
            return cars.OrderBy(car => car.BrandName).Take(howMany).ToList();
        }

        public List<Car> TakeCars(Range howMany)
        {
            var cars = _carRepository.GetAll();
            return cars.OrderBy(car => car.BrandName).Take(howMany).ToList();
        }

        public List<Car> TakeCarsWhileNameStartsWith(string prefix)
        {
            var cars = _carRepository.GetAll();
            return cars.OrderBy(car => car.BrandName)
                       .TakeWhile(car => car.BrandName.StartsWith(prefix))
                       .ToList();
        }

        public List<Car> WhereStartsWith(string prefix)
        {
            var cars = _carRepository.GetAll();
            return cars.Where(car => car.BrandName.StartsWith(prefix)).ToList();
        }

        public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
        {
            var cars = _carRepository.GetAll();
            return cars.Where(car => car.BrandName.StartsWith(prefix) && car.Price > cost).ToList();
        }
    }
}
