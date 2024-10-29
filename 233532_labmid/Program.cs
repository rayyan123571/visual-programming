using System;
using System.Collections.Generic;

public class ClubRole
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string ContactInfo { get; set; }

    public ClubRole(string name, string role, string contactInfo)
    {
        Name = name;
        Role = role;
        ContactInfo = contactInfo;
    }
}

public class Activity
{
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public Activity(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }
}

public class Society
{
    public string Name { get; set; }
    public ClubRole ContactPerson { get; set; }
    protected List<Activity> Activities = new List<Activity>();

    public Society(string name, ClubRole contactPerson)
    {
        Name = name;
        ContactPerson = contactPerson;
    }

    public void AddActivity(Activity activity)
    {
        Activities.Add(activity);
    }

    public List<Activity> ListEvents()
    {
        return Activities;
    }
}

public class FundedSociety : Society
{
    public double FundingAmount { get; set; }

    public FundedSociety(string name, ClubRole contactPerson, double fundingAmount)
        : base(name, contactPerson)
    {
        FundingAmount = fundingAmount;
    }
}

public class NonFundedSociety : Society
{
    public NonFundedSociety(string name, ClubRole contactPerson)
        : base(name, contactPerson)
    {
    }
}

public class StudentClub
{
    private List<Society> societies = new List<Society>();
    public double Budget { get; set; }

    public void RegisterSociety(Society society)
    {
        societies.Add(society);
    }

    public List<Society> Societies => societies; // Property to access societies

    public void DisplayFundingInformation()
    {
        foreach (var society in societies)
        {
            if (society is FundedSociety fundedSociety)
            {
                Console.WriteLine($"Society Name: {fundedSociety.Name}, Contact: {fundedSociety.ContactPerson.Name}, Funding: {fundedSociety.FundingAmount}");
            }
        }
    }

    public void DisplayEventsForSociety(string societyName)
    {
        var society = societies.Find(s => s.Name.Equals(societyName, StringComparison.OrdinalIgnoreCase));
        if (society != null)
        {
            var events = society.ListEvents();
            Console.WriteLine($"Events for {society.Name}:");
            foreach (var activity in events)
            {
                Console.WriteLine($"- {activity.Name} on {activity.Date.ToShortDateString()}");
            }
        }
        else
        {
            Console.WriteLine("Society not found.");
        }
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        StudentClub studentClub = new StudentClub();

        // Sample data
        var president = new ClubRole("Alice", "President", "alice@example.com");
        var techSociety = new FundedSociety("Tech Society", president, 600);
        techSociety.AddActivity(new Activity("Tech Talk", DateTime.Now));

        var literarySociety = new FundedSociety("Literary Society", new ClubRole("Bob", "Contact Person", "bob@example.com"), 500);
        literarySociety.AddActivity(new Activity("Poetry Reading", DateTime.Now.AddDays(7)));

        var mediaSociety = new NonFundedSociety("Media Society", new ClubRole("Charlie", "Contact Person", "charlie@example.com"));

        studentClub.RegisterSociety(techSociety);
        studentClub.RegisterSociety(literarySociety);
        studentClub.RegisterSociety(mediaSociety);
        

        // Console Menu
        while (true)
        {
            Console.WriteLine("\nStudent Club Management System");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Register a new society");
            Console.WriteLine("2. Allocate funding to societies");
            Console.WriteLine("3. Register an event for a society");
            Console.WriteLine("4. Display society funding information");
            Console.WriteLine("5. Display events for a society");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Register a new society
                    Console.Write("Enter society name: ");
                    string societyName = Console.ReadLine();
                    Console.Write("Enter contact person's name: ");
                    string contactName = Console.ReadLine();
                    Console.Write("Enter contact person's role: ");
                    string role = Console.ReadLine();
                    Console.Write("Enter contact person's info (email/phone): ");
                    string contactInfo = Console.ReadLine();
                    Console.Write("Is this a funded society? (yes/no): ");
                    string isFunded = Console.ReadLine();

                    ClubRole contactPerson = new ClubRole(contactName, role, contactInfo);
                    Society newSociety;

                    if (isFunded.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Enter funding amount: ");
                        double fundingAmount = Convert.ToDouble(Console.ReadLine());
                        newSociety = new FundedSociety(societyName, contactPerson, fundingAmount);
                    }
                    else
                    {
                        newSociety = new NonFundedSociety(societyName, contactPerson);
                    }

                    studentClub.RegisterSociety(newSociety);
                    Console.WriteLine($"{societyName} has been registered successfully.");
                    break;
                    

                case "2":
                    // Allocate funding to societies
                    
                    Console.WriteLine("Funding allocation is managed during society registration.");
                    break;

                case "3":
                    // Register an event for a society
                    Console.Write("Enter society name to register an event: ");
                    string eventSocietyName = Console.ReadLine();
                    var societyToRegisterEvent = studentClub.Societies.Find(s => s.Name.Equals(eventSocietyName, StringComparison.OrdinalIgnoreCase));

                    if (societyToRegisterEvent != null)
                    {
                        Console.Write("Enter event name: ");
                        string eventName = Console.ReadLine();
                        Console.Write("Enter event date (yyyy-mm-dd): ");
                        DateTime eventDate = DateTime.Parse(Console.ReadLine());

                        societyToRegisterEvent.AddActivity(new Activity(eventName, eventDate));
                        Console.WriteLine($"Event '{eventName}' has been registered for {societyToRegisterEvent.Name}.");
                    }
                    else
                    {
                        Console.WriteLine("Society not found.");
                    }
                    break;

                case "4":
                    // Display society funding information
                    studentClub.DisplayFundingInformation();
                    break;

                case "5":
                    // Display events for a society
                    Console.Write("Enter society name to display events: ");
                    string displaySocietyName = Console.ReadLine();
                    studentClub.DisplayEventsForSociety(displaySocietyName);
                    break;

                case "6":
                    // Exit
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}