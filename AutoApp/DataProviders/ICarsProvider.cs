using AutoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.DataProviders
{
    public interface ICarsProvider
    {
        //select
        List<Car> GetSpecificColumns();
        List<Car> GetSpecificCarsForPrice(int minPrice, int maxPrice);
        List<Car> GetSpecificCarsForBrand(string Brand);
        List<Car> GetSpecificCarsForColor(string color);

        //order by
        List<Car> OrderbyName();
        List<Car> OrderbyNameDescending();

        //where
        List<Car> WhereStartsWith(string prefix);
        List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

        //first, last, single
        Car FirstByName(string name);
        Car? FirstOrDefaultByName(string name);
        Car FirstOrDefaultByNameWithDefault(string name);
        Car LastByName(string name);
        Car SingleById(int id);
        Car? SingleOrDefaultById(int id);

        //Take
        List<Car> TakeCars(int howMany);
        List<Car> TakeCars(Range howMany);
        List<Car> TakeCarsWhileNameStartsWith(string prefix);

        //Skip
        List<Car> SkipCars(int howMany);
        List<Car> SkipCarsWhileNameStartsWith(string prefix);

        //chunk
        List<Car[]> ChunkCars(int size);


    }
}
