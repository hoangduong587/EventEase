using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEase.Services
{
    public class EventService
    {
        private List<EventItem> _events;
        private int _nextId = 4; // Starting from 4 since we have 3 mock events

        public EventService()
        {
            // Initialize with mock data
            _events = new List<EventItem>
            {
                new EventItem 
                { 
                    Id = 1, 
                    Title = "Tech Conference 2025", 
                    Description = "Annual technology conference featuring the latest innovations.",
                    Date = DateTime.Now.AddDays(30),
                    Location = "Convention Center",
                    Capacity = 500,
                    RegisteredCount = 347,
                    IsPublic = true,
                    CreatedDate = DateTime.Now.AddDays(-30),
                    LastModified = DateTime.Now.AddDays(-2)
                },
                new EventItem 
                { 
                    Id = 2, 
                    Title = "Community Meetup", 
                    Description = "Monthly community gathering for networking and sharing.",
                    Date = DateTime.Now.AddDays(15),
                    Location = "Community Hall",
                    Capacity = 100,
                    RegisteredCount = 67,
                    IsPublic = true,
                    CreatedDate = DateTime.Now.AddDays(-20),
                    LastModified = DateTime.Now.AddDays(-1)
                },
                new EventItem 
                { 
                    Id = 3, 
                    Title = "Workshop: Web Development", 
                    Description = "Hands-on workshop covering modern web development practices.",
                    Date = DateTime.Now.AddDays(7),
                    Location = "Learning Center",
                    Capacity = 50,
                    RegisteredCount = 23,
                    IsPublic = false,
                    CreatedDate = DateTime.Now.AddDays(-10),
                    LastModified = DateTime.Now.AddDays(-3)
                }
            };
        }

        public async Task<List<EventItem>> GetAllEventsAsync()
        {
            await Task.Delay(50); // Simulate async operation
            return _events.ToList();
        }

        public async Task<EventItem?> GetEventByIdAsync(int id)
        {
            await Task.Delay(50); // Simulate async operation
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public async Task<EventItem> CreateEventAsync(CreateEventRequest request)
        {
            await Task.Delay(100); // Simulate async operation
            
            var newEvent = new EventItem
            {
                Id = _nextId++,
                Title = request.Title,
                Description = request.Description,
                Date = request.Date.Add(TimeSpan.Parse(request.Time)),
                Location = request.Location,
                Capacity = request.Capacity,
                RegisteredCount = 0,
                IsPublic = request.IsPublic,
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now
            };

            _events.Add(newEvent);
            return newEvent;
        }

        public async Task<EventItem?> UpdateEventAsync(int id, UpdateEventRequest request)
        {
            await Task.Delay(100); // Simulate async operation
            
            var existingEvent = _events.FirstOrDefault(e => e.Id == id);
            if (existingEvent == null)
                return null;

            existingEvent.Title = request.Title;
            existingEvent.Description = request.Description;
            existingEvent.Date = request.Date.Add(TimeSpan.Parse(request.Time));
            existingEvent.Location = request.Location;
            existingEvent.Capacity = request.Capacity;
            existingEvent.IsPublic = request.IsPublic;
            existingEvent.LastModified = DateTime.Now;

            return existingEvent;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            await Task.Delay(100); // Simulate async operation
            
            var eventToDelete = _events.FirstOrDefault(e => e.Id == id);
            if (eventToDelete == null)
                return false;

            _events.Remove(eventToDelete);
            return true;
        }

        public async Task<bool> RegisterForEventAsync(int eventId)
        {
            await Task.Delay(100); // Simulate async operation
            
            var eventItem = _events.FirstOrDefault(e => e.Id == eventId);
            if (eventItem == null || eventItem.RegisteredCount >= eventItem.Capacity)
                return false;

            eventItem.RegisteredCount++;
            eventItem.LastModified = DateTime.Now;
            return true;
        }
    }

    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int RegisteredCount { get; set; }
        public bool IsPublic { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class CreateEventRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = "10:00";
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsPublic { get; set; } = true;
    }

    public class UpdateEventRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = "10:00";
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsPublic { get; set; } = true;
    }
}