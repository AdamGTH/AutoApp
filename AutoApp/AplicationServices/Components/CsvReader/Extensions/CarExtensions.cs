﻿using AutoApp.AplicationServices.Components.CsvReader.Models;

namespace AutoApp.AplicationServices.Components.CsvReader.Extensions
{
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<String> source)
        {
            IEnumerable<Car> result = new List<Car>();
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Higway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7]),
                };
            }
            
        }
    }
}
