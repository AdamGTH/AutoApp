using AutoApp.DataAccess.Data.Entities;

namespace AutoApp.UI.EventsMethods
{
    public interface IEventsMethods
    {
        void EventAdded(object? sender, Car e);
        void EventDeleted(object? sender, Car e);
        void EventSaved(object? sender, Car e);

    }
}
