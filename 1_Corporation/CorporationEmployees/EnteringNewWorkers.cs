using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CorporationEmployees
{
    public static class EnteringNewWorkers
    {
        public static List<Workers> CreateWorker()
        {
            WriteLine("\n---- SETTING UP WORKER PROFILE ----");

            string escapeKey;
            List<Workers> workers = new List<Workers>();

            do
            {
                workers.Add(EnterNewWorker());
                WriteLine("\nPress 0 when you're done with adding workers. To continue adding, press any button.");
                escapeKey = ReadLine();
            }
            while (escapeKey != "0");

            return workers;
        }

        public static Workers EnterNewWorker()
        {
            Workers worker = new Workers();
            worker.Address = new Address();

            WriteLine("\nEnter workers first name:");
            worker.FirstName = ReadLine();
            WriteLine("\nEnter workers last name:");
            worker.LastName = ReadLine();
            WriteLine("\nEnter workers age:");
            worker.Age = IntCheckInput(ReadLine());
            WriteLine("\nEnter workers years of experience:");
            worker.YearsOfExperience = IntCheckInput(ReadLine());
            WriteLine("\nEnter state:");
            worker.Address.State = ReadLine();
            WriteLine("\nEnter city:");
            worker.Address.City = ReadLine();
            WriteLine("\nEnter zip code:");
            worker.Address.ZipCode = IntCheckInput(ReadLine());
            WriteLine("\nEnter street name:");
            worker.Address.StreetName = ReadLine();
            WriteLine("\nEnter street number:");
            worker.Address.StreetNumber = ReadLine();

            WriteLine("\nEnter technologies. \nPress 0 when you're done with adding technologies. To continue adding, press any button.");
            worker.Technologies = new List<string>();

            string escapeKey;
            do
            {
                escapeKey = ReadLine();
                worker.Technologies.Add(escapeKey);
            }
            while (escapeKey != "0");
            worker.Technologies.RemoveAt(worker.Technologies.Count - 1);
            
            return worker;
        }

        public static int IntCheckInput(string Input)
        {
            int returnNumber;
            while (!int.TryParse(Input, out returnNumber)) 
            {
                WriteLine("Please, enter a number.");
                Input = ReadLine();
            }
            return returnNumber;
        }
    }
}
