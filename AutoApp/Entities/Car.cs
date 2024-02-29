using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Entities
{
    public class Car : CarBase
    {
        public string? BrandName { get; set; }
        public string? TypeOfEngine { get; set; }
        public int? Price { get; set; }
        public string? TypeOfDrive { get; set; }
        public string Color { get; set; }

               
        public override string ToString()
        {
            StringBuilder s = new (1024);

            s.AppendLine($"Id:{Id},  Brand:{BrandName}");
            s.AppendLine($"Type of engine: {TypeOfEngine},  Type of drive:{TypeOfDrive}");
            s.AppendLine($"Color: {Color},  Price:{Price}");

            return s.ToString();
        }
    }
}
