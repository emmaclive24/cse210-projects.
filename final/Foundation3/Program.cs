using System;

class Program
{
    static void Main(string[] args)
    {
        Address[] addresses =  new Address[3];
        addresses[0] = new Address("8269 Stephen Forks", "Ernestborough", "Oregon", "96999-5727", "United States");
        addresses[1] = new Address("66454 Mortimer Throughway Apt. 451", "Jasenberg", "New Hampshire", "03360", "United States");
        addresses[2] = new Address("Strada Pagano 3", "Quarto Ariel", "Bologna", "61236", "Italy");

        Event[] events =  new Event[3];
        events[0] = new LectureEvent("Introduction to OOP course","Let's learn the basics of OOP","07/12/2023","10:00am",addresses[0],"Liliana","75 People");
        events[1] = new ReceptionEvent("Victorias Wedding","Join us celebrating Victoria's Wedding","01/05/2023","08:00pm",addresses[1],"victoria@gmail.com");
        events[2] = new OutdoorGatheringEvent("Soccer With Friends","Let's play 90 minutes of the best soccer with friends!","10/11/2023","09:00pm",addresses[2],"Sunny");

        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Event N°: {i + 1}");
            Console.WriteLine("\n-STANDARD DETAILS-");
            Console.WriteLine(events[i].StandardDetails());
            Console.WriteLine("-SHORT DETAILS- ");
            Console.WriteLine(events[i].ShortDetails());
            Console.WriteLine("-FULL DETAILS-");
            Console.WriteLine(events[i].FullDetails());
            
        }
    }
}