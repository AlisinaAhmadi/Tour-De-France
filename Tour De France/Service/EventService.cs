using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class EventService
    {
        private List<Event> events;
        public DbGenericService<Event> DbService { get; set; }

        public EventService(DbGenericService<Event> dbService)
        {
            DbService = dbService;
            events = dbService.GetObjectsAsync().Result.ToList();
        }
        public IEnumerable<Event> GetEvents()
        {
            return events;
        }

        public Event GetEvent(int id)
        {
            foreach (var eEvent in events)
            {
                if (eEvent.EventId == id)
                {
                    return eEvent;
                }
            }

            return null;
        }

        public async Task AddEvent(Event eEvent)
        {
            events.Add(eEvent);
            await DbService.AddObjectAsync(eEvent);
        }


        public async Task DeleteEvent(int EventId)
        {
            Event eventToBeDeleted = events.Find(eEvent => eEvent.EventId == EventId);
            if (eventToBeDeleted != null)
            {
                events.Remove(eventToBeDeleted);
                await DbService.DeleteObjectAsync(eventToBeDeleted);
            }
        }

        public async Task EditEvent(Event eEvent)
        {
            if (eEvent != null)
            {
                foreach (var e in events)
                {
                    if (e.EventId == eEvent.EventId)
                    {
                        e.Titel = eEvent.Titel;
                        e.Description = eEvent.Description;
                        e.Time = eEvent.Time;
                        e.Address = eEvent.Address;
                    }
                }
            }
        }
    }
}
