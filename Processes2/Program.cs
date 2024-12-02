using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Processes2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process[] allProcesses = Process.GetProcesses();
            //for (int i = 0; i < allProcesses.Length; i++)
            //{
            //    Console.WriteLine($"{allProcesses[i].Id}\t{allProcesses[i].ProcessName}");
            //}

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Диспетчер задач");
                Console.WriteLine("1. Показать список процессов");
                Console.WriteLine("2. Завершить процесс");
                Console.WriteLine("3. Показать информацию о процессе");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowProcesses();
                        break;
                    case "2":
                        //KillProcess();
                        break;
                    case "3":
                        //ShowProcessInfo();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }

        static void ShowProcesses()
        {
            Console.Clear();
            Process[] allProcesses = Process.GetProcesses();
            Console.WriteLine("ID\tИмя процесса");
            Console.WriteLine(new string('-', 40));
            foreach (var process in allProcesses)
            {
                Console.WriteLine($"{process.Id}\t{process.ProcessName}");
            }
        }
    }
}