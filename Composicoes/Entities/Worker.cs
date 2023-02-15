using Composicoes.Entities.Enums;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Composicoes.Entities
{
    class Worker
   
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // Assosciação a duas classes diferentes. Porque o departamento(Department) está associado ao trabalhador(Worker).
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>(); //Precisamos criar a propriedade Contracts. Já instanciamos a lista pra ela nãos ser nula(= new List<HourContract>();).  Como são vários contratos vinculados ao trabalhador, essa propriedade precisa ser do tipo lista. Porque uma lista? porque o trabalhador tem vários contratos

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) // Não vamos passar a list de contratos porque não é usual colocar uma lista no construtor. VIA DE REGRA, SEMPRE QUE TIVER UMA ASSOCIAÇÃO "PARA MUITOS"(LISTA DE CONTRATOS) NÃO VAMOS INCLUIR NO CONSTRUTOR
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month) // se o ano que for passado e o mês for igual ao ano e mês do contrato vai somar 
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}