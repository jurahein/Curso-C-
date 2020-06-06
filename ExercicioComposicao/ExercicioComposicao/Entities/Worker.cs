using ExercicioComposicao.Entities.Enums;
using System.Collections.Generic;

namespace ExercicioComposicao.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public  WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }

        // Nessa atribuição estamos fazendo a composição, ou seja associando 2 classes diferentes, 
        public Department Department { get; set; }
                                                        // Estanciando ja na classe para garantir que o valor não seja nulo
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();


        // Contrutores
        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
            
        }

        // Métodos

            // esse método ele adiciona o contrato (contract) dentro da lista Contract
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        // esse método ele remove o contrato (contract) dentro da lista Contract
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            // começo com a soma recebendo o salario base, pois de qualquer forma ele vai ganahr esse salario base
            double soma = BaseSalary;

            // uso um foreach para pecorrer a lista de contrato, e adicionar

            // para cada hourcontract na minha lista de contrato
            foreach (HourContract contract  in Contracts)
            {

                // se esse contrato na minha lista, na data dele, se o anao do meu contrato for igual ao ano que recebi no argumento
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    soma += contract.TotalValue();
                }

            }
            return soma;
        }
    }
}
