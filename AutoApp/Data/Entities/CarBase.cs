using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Data.Entities
{
    public abstract class CarBase : IEntity
    {
        public int Id { get; set; }
    }
}
