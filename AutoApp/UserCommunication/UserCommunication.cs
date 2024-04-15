
using AutoApp.Components.CsvReader;
using AutoApp.Data.Entities;
using AutoApp.Data.Repositories;
using AutoApp.Data.UserCommunication;
using AutoApp.Components;

namespace AutoApp.UserCommunication
{

    public class UserCommunication : IUserCommunication
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IMenu _menu;
        private readonly ICsvReader _csvReader;
        
        public UserCommunication(ICsvReader csvReader, IRepository<Car> carRepository, IMenu menu) 
        { 
            _csvReader = csvReader;
            _carRepository = carRepository;
            _menu = menu;
        }

        public void AddCar()
        {
            _menu.ShowMenuToAddCar();
            Console.WriteLine("Year: ");
            var year = int.Parse(Console.ReadLine());
            Console.WriteLine("Manufacturer: ");
            var manufacturer = Console.ReadLine();
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Displacement: ");
            var displacement = double.Parse(Console.ReadLine());
            Console.WriteLine("Cylinders: ");
            var cylinders = int.Parse(Console.ReadLine());
            Console.WriteLine("City: ");
            var city = int.Parse(Console.ReadLine());
            Console.WriteLine("Higway: ");
            var higway = int.Parse(Console.ReadLine());
            Console.WriteLine("Combined: ");
            var Combined = int.Parse(Console.ReadLine());
            
            
            _carRepository.Add(new Car
            {
                Year = year,
                Manufacturer = manufacturer,
                Name = name,
                Displacement = displacement,
                Cylinders = cylinders,
                City = city,
                Higway = higway,
                Combined = Combined
                        
            });
            _carRepository.Save();
            _menu.ShowMainMenu();

        }
              

        public void RemoveCar()
        {
            _menu.ShowMenuToRemoveCar();

            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            var car = _carRepository.GetByName(name);

            _carRepository.Remove(car);
            _carRepository.Save();

            _menu.ShowMainMenu();
        }
                  

        public void ReadAllCars()
        {
            var allCars = _carRepository.GetAll();

            foreach (var car in allCars)
            {
                Console.Write($"{car.Id}");
                Console.Write($"\t{car.Manufacturer}");
                Console.Write($"\t{car.Name}");
                Console.WriteLine($"\t{car.Combined}");
                Console.WriteLine();
            }
        }

        public void ReadById()
        {
            Console.WriteLine("Id: ");
            var id = int.Parse(Console.ReadLine());

            var car = _carRepository.GetById(id);
            Console.WriteLine($"Manufacturer: {car.Manufacturer.ToString()}");
            Console.WriteLine($"Name: {car.Name.ToString()}");
            Console.WriteLine($"Combined: {car.Combined.ToString()}");
        }

        public void UpdateCar()
        {
            _menu.ShowMenuUpdateCar();
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            var car = _carRepository.GetByName(name);
            Console.WriteLine($"Id: {car.Id.ToString()}");
            Console.WriteLine($"Manufacturer: {car.Manufacturer.ToString()}");
            Console.WriteLine($"Name: {car.Name.ToString()}");
            Console.WriteLine($"Combined: {car.Combined.ToString()}");
            Console.WriteLine();
            Console.WriteLine("New Name: ");
            name = Console.ReadLine();
            car.Name = name;
            _carRepository.Save();
            _menu.ShowMainMenu();
        }

        public void ReadCarsFromFileAndAddToDB()
        {
            var cars = _csvReader.ProcessCars(".\\Resources\\Files\\fuel.csv");

            foreach (var car in cars)
            {
                _carRepository.Add(new Car
                {
                    Year = car.Year,
                    Name = car.Name,
                    Manufacturer = car.Manufacturer,
                    Displacement = car.Displacement,
                    City = car.City,
                    Combined = car.Combined,
                    Cylinders = car.Cylinders,
                    Higway = car.Higway,

                });
                _carRepository.Save();
            }
            
        }
    }
}
