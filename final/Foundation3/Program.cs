using System;

public class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{street}, {city}, {state} {zipCode}";
    }
}

public abstract class Event
{
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address}";
    }

    public string GetShortDescription()
    {
        return $"Type: {GetEventType()}\nTitle: {title}\nDate: {date}";
    }

    protected abstract string GetEventType();

    public abstract string GetFullDetails();
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    protected override string GetEventType()
    {
        return "Lecture";
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    protected override string GetEventType()
    {
        return "Reception";
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    protected override string GetEventType()
    {
        return "Outdoor Gathering";
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {weather}";
    }
}

public class Program
{
    public static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Springfield", "IL", "62701");
        Address address2 = new Address("456 Elm St", "Shelbyville", "IL", "62702");
        Address address3 = new Address("789 Oak St", "Capital City", "IL", "62703");

        // Create events
        Lecture lecture = new Lecture("AI and the Future", "A talk about AI advancements.", "2024-07-20", "10:00 AM", address1, "Dr. John Doe", 100);
        Reception reception = new Reception("Company Gala", "An evening of networking and celebration.", "2024-08-15", "6:00 PM", address2, "rsvp@company.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Picnic", "A fun day in the sun with food and games.", "2024-09-10", "12:00 PM", address3, "Sunny");

        Event[] events = { lecture, reception, outdoorGathering };

        // Print event details
        foreach (Event evt in events)
        {
            Console.WriteLine("\nStandard Details:\n" + evt.GetStandardDetails());
            Console.WriteLine("\nFull Details:\n" + evt.GetFullDetails());
            Console.WriteLine("\nShort Description:\n" + evt.GetShortDescription());
        }
    }
}