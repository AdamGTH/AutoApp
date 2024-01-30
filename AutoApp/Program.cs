using AutoApp.Data;
using AutoApp.Entities;
using AutoApp.Repositories;

var sqlRepository = new SqlRepository<Car>(new AutoAppDbContext());

AddCar(sqlRepository);
AddEvCar(sqlRepository);
WriteAllToConsole(sqlRepository);

static void AddCar(IRepository<Car> carRepository)
{
    carRepository.Add(new Car { Name = "Skoda" });
    carRepository.Add(new Car { Name = "Volvo" });
    carRepository.Add(new Car { Name = "Mercedes" });
    carRepository.Save();
}

static void AddEvCar(IWriteRepository<ElectricCar> evRepository)
{
    evRepository.Add(new ElectricCar { Name = "Tesla" });
    evRepository.Add(new ElectricCar { Name = "Toyota" });
    evRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();

    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}