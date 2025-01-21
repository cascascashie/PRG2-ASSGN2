﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10268085
// Student Name : Khin Hnin Thaw 
// Partner Name : Dinglasan Casandra Antonia Sarmiento 
//==========================================================

namespace Assignment2
{
    internal class Terminal
    {
        public string TerminalName { get; private set; }
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, string> flights { get; set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; set; }
        public Dictionary<string, double> GateFees { get; set; }
        public Terminal(string terminalName)
        {
            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            flights = new Dictionary<string, string>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            GateFees = new Dictionary<string, double>();
        }
        public bool AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines[airline.Code] = airline;
                return true;
            }
            return false;
        }
        public bool AddBoardingGate(BoardingGate boardingGate)
        {
            if (!BoardingGates.ContainsKey(boardingGate.GateName))
            {
                BoardingGates[boardingGate.GateName] = boardingGate;
                return true;
            }
            return false;
        }
        public bool AddFlight(string flightNumber, string airlineCode)
        {
            if (!flights.ContainsKey(flightNumber) && Airlines.ContainsKey(airlineCode))
            {
                flights[flightNumber] = airlineCode;
                Airlines[airlineCode].AddFlight(flightNumber);
                return true;
            }
            return false;
        }
        public Airline? GetAirlineFromFlight(string flightNumber)
        {
            if (flights.TryGetValue(flightNumber, out string? airlineCode))
            {
                return Airlines.GetValueOrDefault(airlineCode);
            }
            return null;
        }
        public void PrintAirlineFees()
        {
            foreach (var airline in Airlines.Values)
            {
                double fees = airline.CalculateFees();
                Console.WriteLine($"{airline.Name} Total Fees: ${fees:N2}");
            }
        }
        public override string ToString()
        {
            return $"Terminal {TerminalName}\n" +
                   $"Airlines: {Airlines.Count}\n" +
                   $"Flights: {flights.Count}\n" +
                   $"Boarding Gates: {BoardingGates.Count}";
        }
    }   
}
