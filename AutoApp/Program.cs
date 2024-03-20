using AutoApp;
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
using static System.Runtime.InteropServices.JavaScript.JSType;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Car>, RepositoryInFile<Car>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventsMethods, EventsMethods>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<AutoAppDbContext>(options => options
.UseSqlServer("Data Source=DESKTOP-RPMRN2O\\SQLEXPRESS;Initial Catalog=AutoAppStorage;Integrated Security=True;TrustServerCertificate=True"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();

//Data Source=DESKTOP-RPMRN2O\SQLEXPRESS;Initial Catalog=TestStorage;Integrated Security=True