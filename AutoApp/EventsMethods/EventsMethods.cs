using AutoApp.Data.Entities;
using AutoApp.Events;
using AutoApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApp.EventsMethods
{
    public class EventsMethods : IEventsMethods
    {
       
        public void EventAdded(object? sender, Car e)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{e.BrandName} added from {sender.GetType().Name}");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-ItemAdded-[{e.BrandName}]");
            }
        }

        public void EventDeleted(object? sender, Car e)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{e.BrandName} deleted from {sender.GetType().Name}");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-ItemDeleted-[{e.BrandName}]");
            }
        }
    }
}
