EventEase — Simple Blazor WebAssembly Event Manager
EventEase is a lightweight Blazor WebAssembly application that demonstrates basic event management using only frontend logic.
All event data is stored in memory, and the UI is built entirely with Razor components — no backend, no database, and no API required.

This project is ideal for learning Blazor fundamentals, component communication, and simple state management.

✨ Features
Event Listing
Displays a list of mock events using EventCard components

Shows title, date, location, capacity, and visibility (public/private)

Event Details
Dedicated page for viewing full event information

Shows description, timestamps, and registration count

Event Registration
Users can register for an event

Capacity limits enforced

Registration count updates instantly

Event Creation & Editing
Simple forms for creating and editing events

Uses in‑memory service methods

No persistence — data resets on refresh

Pure Frontend
No backend API

No database

No authentication or roles

All logic handled inside Blazor WebAssembly

🧱 Tech Stack
Layer	Technology
Frontend	Blazor WebAssembly (.NET 8)
UI	Razor Components
Data	In‑memory C# service (EventService)
Language	C#

```
📁 Project Structure
Code
EventEase/
│
├── Pages/
│   ├── Home.razor
│   ├── EventCard.razor
│   ├── EventDetails.razor
│   ├── CreateEvent.razor
│   └── EditEvent.razor
│
├── Services/
│   └── EventService.cs
│
└── wwwroot/
```
🧠 How It Works
EventService
A simple in‑memory service that:

Stores a list of mock events

Returns all events or a single event

Allows creating and editing events

Allows registering for events

Simulates async calls with Task.Delay

There is no persistence — refreshing the page resets everything.

Razor Components
Home.razor — displays event list

EventCard.razor — reusable event preview component

EventDetails.razor — full event info

CreateEvent.razor — form for adding events

EditEvent.razor — form for editing events

🚀 Running the App
1. Clone the repository
bash
git clone https://github.com/yourusername/EventEase.git
cd EventEase
2. Run the project
bash
dotnet run
3. Open in your browser
Code
https://localhost:5001
📌 Future Improvements
Add persistent storage

Add a real backend (ASP.NET Web API)

Add authentication (admin vs user)

Add search & filtering

Add categories/tags

Deploy to GitHub Pages or Azure

👤 Author
Hoang  
Learning Blazor & .NET through simple, practical projects.
