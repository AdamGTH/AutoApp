using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.AplicationServices.Components
{
    public interface IMenu
    {
        void ShowMainMenu();
        void ShowMenuToAddCar();
        void ShowMenuToRemoveCar();
        void ShowMenuUpdateCar();

        void Goodbye();

    }
}
