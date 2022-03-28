using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CorporationEmployees
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            List<Worker> workers = EnteringNewWorkers.CreateWorker();

            foreach (var worker in workers)
            {
                WriteLine($"\nWorker {worker.FirstName} {worker.LastName} knows technologies:");
                foreach (var technology in worker.Technologies)
                {
                    WriteLine(technology);
                }
            }
            ReadLine();
        }
    }
}
