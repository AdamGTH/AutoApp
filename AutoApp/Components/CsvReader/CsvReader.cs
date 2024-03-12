using AutoApp.Components.CsvReader.Extensions;
using AutoApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<Car> ProcessCars(string filePath)
        {
            if(!File.Exists(filePath))
            {
                return new List<Car> ();
            }
            var cars = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(x => x.Length > 1)
                .ToCar();

            return cars.ToList();
        }

        public List<Manufacturer> ProcessManufacturer(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Manufacturer> ();
            }

            var manufacturer = File.ReadAllLines(filePath)
                .Where (x => x.Length > 1)
                .Select(x => 
                {
                    var columns = x.Split(',');
                    return new Manufacturer()
                    {
                        Name = columns[0],
                        Country = columns[1],
                        Year = columns[2]
                    };
                    
                });
            return manufacturer.ToList();
        }
    }
}
