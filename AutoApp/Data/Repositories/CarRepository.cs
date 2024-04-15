using AutoApp.Data.Entities;

namespace AutoApp.Data.Repositories
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
