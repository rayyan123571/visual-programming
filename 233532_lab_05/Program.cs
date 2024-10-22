using System;
using System.Collections.Generic;

public class Customer
{
    // Properties of a general customer
    public string CustomerId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Default constructor
    public Customer() { }

    // Constructor that initializes a few properties
    public Customer(string customerId, string lastName, string firstName)
    {
        CustomerId = customerId;
        LastName = lastName;
        FirstName = firstName;
    }

    // Method for making a reservation
    public void MakeReservation(Reservation reservation)
    {
        Console.WriteLine($"Customer {FirstName} {LastName} made a reservation with ID {reservation.ReservationNo}.");
    }
}

// Derived class for retail customers, with additional properties
public class RetailCustomer : Customer
{
    public string CreditCardType { get; set; } // Type of credit card (Visa, MasterCard, etc.)
    public string CreditCardNo { get; set; }   // Credit card number
}

// Derived class for corporate customers, with additional properties
public class CorporateCustomer : Customer
{
    public string CompanyName { get; set; }         // Company name for corporate customers
    public int FrequentFlyerPts { get; set; }       // Frequent flyer points accumulated by the corporate customer
    public string BillingAccountNo { get; set; }    // Billing account number
}

// Class representing a reservation made by a customer
public class Reservation
{
    public string ReservationNo { get; set; }      // Unique reservation number
    public DateTime Date { get; set; }             // Date of reservation
    public List<Seat> ReservedSeats { get; set; }  // List of seats reserved in this reservation

    // Constructor initializing the reservation number and setting the reservation date
    public Reservation(string reservationNo)
    {
        ReservationNo = reservationNo;
        Date = DateTime.Now;  // Set the reservation date to current time
        ReservedSeats = new List<Seat>();  // Initialize the list of reserved seats
    }

    // Method to reserve a seat
    public void ReserveSeat(Seat seat)
    {
        ReservedSeats.Add(seat);  // Add seat to the reservation
        Console.WriteLine($"Seat {seat.SeatNo} reserved.");
    }
}

// Class representing a seat on the flight
public class Seat
{
    public int RowNo { get; set; }    // Row number of the seat
    public int SeatNo { get; set; }   // Seat number
    public decimal Price { get; set; } // Price of the seat
    public string Status { get; set; } // Status (Reserved, Available, etc.)
}

// Class representing a flight
public class Flight
{
    public string FlightId { get; set; }  // Flight ID
    public DateTime Date { get; set; }    // Date of the flight
    public string Origin { get; set; }    // Origin of the flight
    public string Destination { get; set; } // Destination of the flight
    public DateTime DepartureTime { get; set; } // Flight departure time
    public DateTime ArrivalTime { get; set; }   // Flight arrival time
    public int SeatingCapacity { get; set; }    // Number of seats available on the flight
    public List<Seat> Seats { get; set; }       // List of seats on the flight

    // Constructor initializing flight ID and seating capacity, then calling seat initialization
    public Flight(string flightId, int seatingCapacity)
    {
        FlightId = flightId;
        SeatingCapacity = seatingCapacity;
        Seats = new List<Seat>();
        InitializeSeats();  // Initialize the list of seats
    }

    // Method to initialize the seats with default values
    private void InitializeSeats()
    {
        for (int i = 1; i <= SeatingCapacity; i++)
        {
            // Add seats with row, seat number, price, and status as available
            Seats.Add(new Seat { RowNo = (i - 1) / 6 + 1, SeatNo = i, Price = 100 + i, Status = "Available" });
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a flight object with a flight ID and seating capacity of 12
        Flight flight = new Flight("FL123", 12);

        // Create a reservation object with a reservation number
        Reservation reservation = new Reservation("RS456");

        // Create a retail customer object and set its details
        RetailCustomer customer = new RetailCustomer
        {
            CustomerId = "C001",
            FirstName = "John",
            LastName = "Doe",
            CreditCardType = "Visa",
            CreditCardNo = "1234-5678-9012"
        };

        // Customer makes a reservation
        customer.MakeReservation(reservation);

        // Reserve the first seat from the flight
        Seat seat = flight.Seats[0];  // Retrieve the first seat in the flight's seat list
        reservation.ReserveSeat(seat); // Reserve this seat in the reservation

        // Output the reserved seat details
        Console.WriteLine($"Seat {seat.SeatNo} (Row {seat.RowNo}) reserved at price {seat.Price:C}.");
    }
}
