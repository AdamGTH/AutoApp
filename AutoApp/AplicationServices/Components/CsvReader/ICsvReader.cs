using AutoApp.AplicationServices.Components.CsvReader.Models;

namespace AutoApp.AplicationServices.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Car> ProcessCars(string filePath);
        List<Manufacturer>ProcessManufacturer(string filePath);
    }
}
