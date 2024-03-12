using AutoApp;
using AutoApp.Components.CsvReader;
using AutoApp.Components.DataProviders;
using AutoApp.Data;
using AutoApp.Data.Entities;
using AutoApp.Data.Repositories;
using AutoApp.Data.UserCommunication;
using AutoApp.Events;
using AutoApp.EventsMethods;
using AutoApp.UserCommunication;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Car>, RepositoryInFile<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventsMethods, EventsMethods>();
services.AddSingleton<ICsvReader, CsvReader>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();

