using AutoApp.Data;
using AutoApp.Entities;
using AutoApp.Repositories;

var sqlRepository = new SqlRepository<Car>(new AutoAppDbContext());

AddCar(sqlRepository);
WriteAllToConsole(sqlRepository);

static void AddCar(IRepository<Car> carRepository)
{
    carRepository.Add(new Car { BrandName = "Skoda" });
    carRepository.Add(new Car { BrandName = "Volvo" });
    carRepository.Add(new Car { BrandName = "Mercedes" });
    carRepository.Add(new Car { BrandName = "Mitsubishi", TypeOfEngine = "ELECTRIC" }) ;
    carRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();

    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}