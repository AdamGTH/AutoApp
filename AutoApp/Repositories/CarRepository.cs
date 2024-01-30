using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoApp.Entities;

namespace AutoApp.Repositories
{
    public class CarRepository
    {
        private readonly List<Car> _Cars = new();

        public void Add(Car car)
        {
            car.Id = _Cars.Count + 1;
            _Cars.Add(car);
        }

        public void Save()
        {
            foreach (var car in _Cars)
            {
                Console.WriteLine(car);
            }
        }

        public Car GetById(int id)
        {
            return _Cars.Single(item => item.Id == id);
        }
    }
}
