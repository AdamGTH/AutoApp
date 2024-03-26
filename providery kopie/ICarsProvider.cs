﻿using AutoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Components.DataProviders
{
    public interface ICarsProvider
    {
        List<Car> GetSpecificCarsForPrice(int minPrice, int maxPrice);
        List<Car> GetSpecificCarsForBrand(string Brand);
        List<Car> GetSpecificCarsForColor(string color);
        List<Car> GetSpecificCarsForTypeOfDrive(string type);
        List<Car> WhereStartsWith(string prefix);
        List<Car[]> ChunkCars(int size);


    }
}