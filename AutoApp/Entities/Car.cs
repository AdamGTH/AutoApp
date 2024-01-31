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

        public override string ToString() => $"Id: {Id}, Name: {BrandName}, Fuel: {TypeOfEngine}";
    }
}
