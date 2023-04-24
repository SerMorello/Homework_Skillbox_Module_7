
using System.Security.Cryptography;
using Homework_Skillbox_Module_7;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        Repository repository = new Repository();
        int userChoice = 0;

        while (userChoice != 7)
        {
            Console.WriteLine("Выберите действие\n\t1 - Вывести данные на экран\n\t2 - Заполнить данные и добавить новую запись\n\t3 - Просмотр сотрудника по ID\n\t4 - Загрузка записей в выбранном диапазоне дат" +
                "\n\t5 - Удалить сотрудника\n\t6 - Создать рандомный список\n\t7 - Завершить работу");

            userChoice = Int32.Parse(Console.ReadLine());

            if (userChoice == 1)
            {

                Console.WriteLine("Хотите отсортировать список?");
                Console.WriteLine("\n\t1 - нет\n\t2 - по ФИО\n\t3 - по возрасту\n\t4 - по росту\n\t5 - по дате рождения\n\t6 - по месту рождения");

                var userSortChoice = Int32.Parse(Console.ReadLine());

                if (userSortChoice == 1)
                {
                    repository.PrintInfo(repository.GetAllWorkers());// вывод списка сотрудников
                }
                else
                {
                    var workers = repository.GetAllWorkers();
                    SortedWorkers(workers, userSortChoice);// вывод списка сотрудников
                }
            }
            else if (userChoice == 2)
            {
                repository.AddWorker();// добавление сотрудника
            }
            else if (userChoice == 3)
            {
                repository.ShowWorkerById();// показ сотрудника по порядковому номеру
            }
            else if (userChoice == 4)
            {
                Console.WriteLine("Хотите отсортировать список?");
                Console.WriteLine("\n\t1 - нет\n\t2 - по ФИО\n\t3 - по возрасту\n\t4 - по росту\n\t5 - по дате рождения\n\t6 - по месту рождения");

                var userSortChoice = Int32.Parse(Console.ReadLine());

                if (userSortChoice == 1)
                {
                    repository.ShowWorkersBetweenTwoDates();    //показ сотрудников в выбранном диапозоне дат
                }
                else
                {
                    var workers = repository.GetWorkersBetweenTwoDates();
                    SortedWorkers(workers, userSortChoice); // вывод списка сотрудников
                }
            }
            else if (userChoice == 5)
            {
                Console.WriteLine("Введите номер сотрудника которого хотите удалить из базы");

                int id = Convert.ToInt32(Console.ReadLine());
                repository.DeleteWorker(id);    //удаление сотрудника
            }
            else if (userChoice ==6)
            {
                Console.WriteLine("Введите количество сотрудников");
                int quantity = Convert.ToInt32(Console.ReadLine());

                repository.CreatingListRandomWorkers(quantity);
            }
            else if (userChoice == 6)
            {
                break;
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз");
                continue;
            }
        }
    }
    static void SortedWorkers(List<Worker> workers, int userChoice)
    {
        int i=0;

        switch (userChoice)
        {
            case 2:
                var sortedWorkers = workers.OrderBy(p => p.FIO);
                Repository.PrintHead();

                foreach (var p in sortedWorkers)
                {
                    Console.WriteLine($"|{i + 1,-3}|{p.DateAdded,-15:g}|{p.FIO,-35}|{p.Age,-7}|{p.Height,-4}|{p.DateBirthday,-13:d}|{p.PlaceBirth,-25}|{p.uniqueId,-36}|");
                    i++;
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------\nКонец файла");

                break;

            case 3:
                sortedWorkers = workers.OrderBy(p => p.Age);
                Repository.PrintHead();

                foreach (var p in sortedWorkers)
                {
                    Console.WriteLine($"|{i + 1,-3}|{p.DateAdded,-15:g}|{p.FIO,-35}|{p.Age,-7}|{p.Height,-4}|{p.DateBirthday,-13:d}|{p.PlaceBirth,-25}|{p.uniqueId,-36}|");
                    i++;
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------\nКонец файла");

                break;

            case 4:
                sortedWorkers = workers.OrderBy(p => p.Height);
                Repository.PrintHead();

                foreach (var p in sortedWorkers)
                {
                    Console.WriteLine($"|{i + 1,-3}|{p.DateAdded,-15:g}|{p.FIO,-35}|{p.Age,-7}|{p.Height,-4}|{p.DateBirthday,-13:d}|{p.PlaceBirth,-25}|{p.uniqueId,-36}|");
                    i++;
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------\nКонец файла");

                break;

            case 5:
                sortedWorkers = workers.OrderBy(p => p.DateBirthday);
                Repository.PrintHead();

                foreach (var p in sortedWorkers)
                {
                    Console.WriteLine($"|{i + 1,-3}|{p.DateAdded,-15:g}|{p.FIO,-35}|{p.Age,-7}|{p.Height,-4}|{p.DateBirthday,-13:d}|{p.PlaceBirth,-25}|{p.uniqueId,-36}|");
                    i++;
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------\nКонец файла");

                break;

            case 6:
                sortedWorkers = workers.OrderBy(p => p.PlaceBirth);
                Repository.PrintHead();

                foreach (var p in sortedWorkers)
                {
                    Console.WriteLine($"|{i + 1,-3}|{p.DateAdded,-15:g}|{p.FIO,-35}|{p.Age,-7}|{p.Height,-4}|{p.DateBirthday,-13:d}|{p.PlaceBirth,-25}|{p.uniqueId,-36}|");
                    i++;
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------\nКонец файла");

                break;
        }
    }
}