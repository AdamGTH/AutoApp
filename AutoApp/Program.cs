using AutoApp.AplicationServices.Components;
using AutoApp.AplicationServices.Components.CsvReader;
using AutoApp.DataAccess.Data;
using AutoApp.DataAccess.Data.Entities;
using AutoApp.DataAccess.Data.Repositories;
using AutoApp.UI;
using AutoApp.UI.EventsMethods;
using AutoApp.UI.UserCommunication;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



var services = new ServiceCollection();
services.AddDbContext<AutoAppDbContext>(options => options
.UseSqlServer("Data Source=DESKTOP-RPMRN2O\\SQLEXPRESS;Initial Catalog=StorageAutoApp;Integrated Security=True;TrustServerCertificate=True"));
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Car>, DbRepository<Car>>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<IEventsMethods, EventsMethods>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IMenu, Menu>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.Run();

