using AutoApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Car> ProcessCars(string filePath);
        List<Manufacturer>ProcessManufacturer(string filePath);
    }
}
