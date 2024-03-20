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
        void ShowAllCars();
        void FindCarForBrand();
        void FindCarForPrice();
        void FindCarForTypeOfDrive();
        void FindCarForColor();
        void FindCarForStartLetters();
        void FindCarFromCsvFile();
        void JoinMethods();
        void ReadCarsFromCsvFileEndAddToDatabase();


        void GroupJoinMethod();
        void CreateXml();
        void ReadXml();
        void CreateXmlToHomeWork();

    }
}
