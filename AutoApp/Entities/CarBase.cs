using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Entities
{
    public abstract class CarBase : IEntity
    {
        public int Id { get; set; }
    }
}
