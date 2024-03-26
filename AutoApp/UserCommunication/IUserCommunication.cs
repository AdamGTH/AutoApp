using AutoApp.Data.Entities;
using AutoApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Data.UserCommunication
{
    public interface IUserCommunication
    {
        void AddCar();
        void RemoveCar();
        void ReadAllCars();
        void UpdateCar();
        void ReadById();
        void ReadCarsFromFileAndAddToDB();


    }
}
