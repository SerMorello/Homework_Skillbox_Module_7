
using System.Security.Cryptography;
using Homework_Skillbox_Module_7;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        Repository repository = new Repository();
        int userChoice = 0;
        List<Worker> workers;
        //string[] personInfo = new string[7];


        while (userChoice != 6)
        {
            Console.WriteLine("Выберите действие\n\t1 - Вывести данные на экран\n\t2 - Заполнить данные и добавить новую запись\n\t3 - Просмотр сотрудника по ID\n\t4 - Загрузка записей в выбранном диапазоне дат" +
                "\n\t5 - Удалить сотрудника\n\t6 - Завершить работу");

            userChoice = Int32.Parse(Console.ReadLine());

            if (userChoice == 1)
            {
                repository.PrintInfo();/// вывод списка сотрудников
            }
            else if (userChoice == 2)
            {
                repository.AddWorker();/// добавление сотрудника
            }
            else if (userChoice == 3)
            {
                repository.ShowWorkerById();/// показ сотрудника по порядковому номеру
            }
            else if (userChoice == 4)
            {
                repository.ShowWorkersBetweenTwoDates();///показ сотрудников в выбранном диапозоне дат
            }
            else if (userChoice == 5)
            {
                Console.WriteLine("Введите номер сотрудника которого хотите удалить из базы");
                int id = Convert.ToInt32(Console.ReadLine());///удаление сотрудника
                repository.DeleteWorker(id);
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

    //private static void PrintHead()
    //{
    //    Console.WriteLine("|{0, -3}|{1,-30}|{2, -35}|{3,-7}|{4,5}|{5,-17}|{6,-35}|" +
    //        "\n--------------------------------------------------------------------------------------------------------------------------------------------"
    //        , "ID", "Дата и время добавления записи", "Ф. И. О.", "Возраст", "Рост", "Дата рождения", "Место рождения");
    //}
}