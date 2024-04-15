using AutoApp;
using AutoApp.Components;
using AutoApp.Components.CsvReader;
using AutoApp.Data;
using AutoApp.Data.Entities;
using AutoApp.Data.Repositories;
using AutoApp.Data.UserCommunication;
using AutoApp.Events;
using AutoApp.EventsMethods;
using AutoApp.UserCommunication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



var services = new ServiceCollection();
services.AddDbContext<AutoAppDbContext<Car>>(options => options
.UseSqlServer("Data Source=DESKTOP-RPMRN2O\\SQLEXPRESS;Initial Catalog=AutoAppStorage;Integrated Security=True;TrustServerCertificate=True"));
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Car>, DbRepository<Car>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventsMethods, EventsMethods>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IMenu, Menu>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();

