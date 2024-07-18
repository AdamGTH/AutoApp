
namespace AutoApp.DataAccess.Data.Entities
{
    public class Car : CarBase
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Higway { get; set; }
        public int Combined { get; set; }
    }
}
