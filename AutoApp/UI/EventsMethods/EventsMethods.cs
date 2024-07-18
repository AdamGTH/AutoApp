using AutoApp.DataAccess.Data.Entities;

namespace AutoApp.UI.EventsMethods
{
    public class EventsMethods : IEventsMethods
    {
       
        public void EventAdded(object? sender, Car e)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{e.Manufacturer} added from {sender.GetType().Name}");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-ItemAdded-[{e.Manufacturer}]");
            }
        }

        public void EventDeleted(object? sender, Car e)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{e.Manufacturer} deleted from {sender.GetType().Name}");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-ItemDeleted-[{e.Manufacturer}]");
            }
        }
        public void EventSaved(object? sender, Car e)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime} Saved Success !!!");
          
        }

        
    }
}
