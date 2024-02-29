using AutoApp;
using AutoApp.Data;
using AutoApp.DataProviders;
using AutoApp.Entities;
using AutoApp.Repositories;
using AutoApp.UserCommunication;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Car>, RepositoryInFile<Car>>();
services.AddSingleton<ICarsProvider, CarsProvider>();
services.AddSingleton<IUserCommunication, UserCommunication>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();

