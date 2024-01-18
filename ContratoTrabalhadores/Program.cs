using ContratoTrabalhadores.Entities;
using ContratoTrabalhadores.Entities.Enums;
using System;
using System.Globalization;
namespace ContratoTrabalhadores
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Dapartament`s name: ");
            string departament = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine());

            Departament dept = new Departament(departament);
            Worker worker = new Worker(name, workerLevel, baseSalary, dept);


            Console.WriteLine("How many contracts to this worker ?");
            int quantContracts = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantContracts; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value Per Hour");
                double valuePerHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.WriteLine("Duration: ");
                int duration = int.Parse(Console.ReadLine());

                HourContract cont = new HourContract(date, valuePerHour, duration);
                worker.AddContract(cont);
            }

            Console.WriteLine("Enter Month and Year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            double valueIncome = worker.Income(year, month);

            Console.WriteLine("\n\n\n");
            Console.WriteLine("Name: "+worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name) ;
            Console.WriteLine("Income: for "+monthAndYear+", "+valueIncome);
        }
    }
}