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
        private string type = "Petrol";
        public string? BrandName { get; set; }
        public string? TypeOfEngine { get { return this.type; }
            set
            {
                
                switch(value.ToLower())
                {
                    case "electric": 
                        this.type = "Electric";
                        break;

                    case "hydrogen":
                        this.type = "Hydrogen";
                        break;

                    default:
                        this.type = "Petrol";
                        break;

                }
            }
                }

        public override string ToString() => $"Id: {Id}, Name: {BrandName}, Fuel: {type}";
    }
}
