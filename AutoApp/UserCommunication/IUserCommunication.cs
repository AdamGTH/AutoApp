using AutoApp.Entities;
using AutoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.UserCommunication
{
    public interface IUserCommunication
    {
        void AddCar();
        void RemoveCar();
        void ShowAllCars();
        void FindCarForBrand();
        void FindCarForPrice();
        void FindCarForTypeOfDrive();
        void FindCarForColor();
        void FindCarForStartLetters();



    }
}
