using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.AplicationServices.Components
{
    public class Menu : IMenu
    {
        public void Goodbye()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Figgle.FiggleFonts.Small.Render("Goodbye !!!"));
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Figgle.FiggleFonts.Small.Render("*** Menu ***"));
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void ShowMenuToAddCar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Figgle.FiggleFonts.Small.Render("*** Add Car ***"));
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void ShowMenuToRemoveCar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Figgle.FiggleFonts.Small.Render("*** Remove Car ***"));
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public void ShowMenuUpdateCar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Figgle.FiggleFonts.Small.Render("*** Update Car ***"));
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
