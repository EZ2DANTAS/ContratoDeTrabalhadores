using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContratoTrabalhadores.Entities.Enums;

namespace ContratoTrabalhadores.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }

        public Departament Departament { get; set; }
        List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker(string name, WorkerLevel level, double baseSalary,Departament departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract( HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract( HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            foreach(var item in Contracts)
            {
                if(item.Date.Month == month && item.Date.Year == year)
                {
                     sum += item.TotalValue();
                }
            }
            return sum;
        }
    }
}
