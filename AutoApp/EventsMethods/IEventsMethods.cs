using AutoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.Events
{
    public interface IEventsMethods
    {
        void EventAdded(object? sender, Car e);
        void EventDeleted(object? sender, Car e);
        void EventSaved(object? sender, Car e);

    }
}
