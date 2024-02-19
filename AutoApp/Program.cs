using AutoApp.Data;
using AutoApp.Entities;
using AutoApp.Repositories;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

var CarRepository = new RepositoryInFile<Car>();
CarRepository.GetAll();
CarRepository.ItemAdded += EventAdded;
CarRepository.ItemDeleted += EventDeleted;

var num = "";
Console.WriteLine("|*----------------------MAIN MENU---------------------*|");
while (num != "q")
{
    switch (num)
    {
        case "1": AddCar(CarRepository); break;
        case "2": RemoveCar(CarRepository); break;
        case "3": WriteAllToConsole(CarRepository); break;
        case "q": break;
        default: break;
    }
    Console.WriteLine();
    Console.WriteLine("-1- ADD CAR ");
    Console.WriteLine("-2- DELETE CAR ");
    Console.WriteLine("-3- READ ALL CARS ");
    Console.WriteLine("-q- END ");

    num = Console.ReadLine();
}

Console.WriteLine("|*-------------------THANK YOU FOR COMING--------------------*|");

static void AddCar(IRepository<Car> carRepository)
{
    Console.WriteLine("|*-------------------ADD CAR TO DATABASE--------------------*|");
    Console.WriteLine("BRAND: ");
    var name = Console.ReadLine();
    Console.WriteLine("TYPE OF FUEL: ");
    var fuel = Console.ReadLine();
    carRepository.Add(new Car {BrandName = name, TypeOfEngine = fuel }) ;
    carRepository.Save();
    Console.WriteLine();
    Console.WriteLine("|*----------------------MAIN MENU---------------------*|");
}

static void RemoveCar(IRepository<Car> carRepository)
{
    Console.WriteLine("|*-------------------REMOVE MENU--------------------*|");
    var items = carRepository.GetAll();

    foreach (var item in items)
    {
        Console.WriteLine(item);
    }

    Console.WriteLine("SET NUMBER TO REMOVE OR 'q' ");
    var num = Console.ReadLine();

    if (int.TryParse(num, out var result))
    {
        carRepository.Remove(carRepository.GetById(result));
        carRepository.Save();
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

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    Console.WriteLine("|*-------------------ALL ITEMS--------------------*|");
    var items = repository.GetAll();

    foreach (var item in items)
    {
        Console.WriteLine(item);
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

void EventAdded(object? sender, Car e)
{
    DateTime dateTime = DateTime.Now;
    Console.WriteLine($"{e.BrandName} added from {sender.GetType().Name}");
    using (var writer = File.AppendText("logs.txt"))
    {
        writer.WriteLine($"[{dateTime}]-ItemAdded-[{e.BrandName}]");
    }
}

void EventDeleted(object? sender, Car e)
{
    DateTime dateTime = DateTime.Now;
    Console.WriteLine($"{e.BrandName} deleted from {sender.GetType().Name}");
    using (var writer = File.AppendText("logs.txt"))
    {
        writer.WriteLine($"[{dateTime}]-ItemDeleted-[{e.BrandName}]");
    }
}