using System;
using ExercicioComposicao.Entities.Enums;
using ExercicioComposicao.Entities;
using System.Globalization;


namespace ExercicioComposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptname = Console.ReadLine();

            Console.WriteLine("Enter worker data:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            
            // nesta linha o input será convertido para as opções que consta na classe Enumerada WorkLevel "Junior/MidLevel/Senior"
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            // Estanciando o objeto departamento recebendo como parametro a variavel input deptname
            Department dept = new Department(deptname);

            // Estanciando o ojeto Worker com os inputs acima + o dept
            Worker worker = new Worker(name, level, salary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                //Estanciando o contrato, isso é os dados digitados acima será um contrato (objeto)
                HourContract contract = new HourContract(date, valuePerHour, hours);

                //Adicionando o contrato que foi feito no for acima ao trabalhador (worker) que foi estanciado acima (antes do for)
                worker.AddContract(contract);

            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string meseano = Console.ReadLine();

            // Vamos pegar o input acima (MM/YYYY) e recortar a string e convertendo para int.
            //Primeiro o mês, criado uma variavel nova "month" E JOGANDO NELA O RESULTADO DO RECORTE DA STRING
            // usando o substring(0, 2) onde 0 é a posição inicial e 2 o fim do recorte
            int month = int.Parse(meseano.Substring(0, 2));
            // mesma coisa o ano recorte da posição 3 em diante
            int year = int.Parse(meseano.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Icome for: " + meseano + ": " + worker.Income(year, month).ToString("f2", CultureInfo.InvariantCulture));


        }
    }
}
