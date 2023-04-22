using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Homework_Skillbox_Module_7
{
    public struct Repository
    {

        public static string Path { get; set; }
        //Worker worker;
        public Repository()
        {
            Path = @"staff.json";
        }
        /// <summary>
        /// Получение Полного списка сотрулников
        /// </summary>
        /// <returns>Список сотрудников</returns>
        private List<Worker> GetAllWorkers()
        {
            if (!File.Exists(Path))
            {
                var workers = new List<Worker>();
                return workers;
            }
            else
            {
                List<Worker> workers;
                using (StreamReader sr = new StreamReader(Path))
                {
                    string jsonText = sr.ReadToEnd();
                    workers = JsonConvert.DeserializeObject<List<Worker>>(jsonText);
                }
                return workers;
            }
        }
        /// <summary>
        /// Вывод на экран списка сотрудников
        /// </summary>
        public void PrintInfo()
        {

            if (File.Exists(Repository.Path))
            {
                PrintHead();
                PrintInfoWorkers(GetAllWorkers());
            }
            else Console.WriteLine("Выводить нечего, сначала внесите данные");
        }
        /// <summary>
        /// Получение сотрудника по его номеру
        /// </summary>
        /// <param name="id">Порядковый номер сотрудника</param>
        /// <returns></returns>
        private Worker GetWorkerById(int id)
        {
            List<Worker> workers = GetAllWorkers();
            return workers[id - 1];
        }
        /// <summary>
        /// Вывод в консоль сотрудника по id
        /// </summary>
        /// <param name="id">Порядковый номер сотрудника</param>
        public void ShowWorkerById()
        {
            Console.WriteLine("Введите номер сотрудника");

            int id = Convert.ToInt32(Console.ReadLine());

            Worker worker = GetWorkerById(id);

            PrintHead();

            Console.WriteLine($"|{id,-3}|{worker.DateAdded,-15:g}|{worker.FIO,-35}|{worker.Age,-7}|{worker.Height,-4}|{worker.DateBirthday,-13:d}|{worker.PlaceBirth,-25}|{worker.uniqueId,-36}|");
        }
        /// <summary>
        /// Создание сотрудника
        /// </summary>
        private Worker CreatWorker()
        {
            Worker worker = new Worker();
            int age;
            DateTime dateBirth;

            for (int num = 1; num < 6; num++)
            {
                switch (num)
                {
                    case 1:
                        worker.DateAdded = DateTime.Now;

                        break;

                    case 2:
                        Console.WriteLine("Введите Фамилию Имя Отчество");

                        worker.FIO = Console.ReadLine();

                        break;

                    case 3:
                        Console.WriteLine("Введите рост");

                        worker.Height = int.Parse(Console.ReadLine());

                        break;

                    case 4:
                        Console.WriteLine("Введите дату рождения");

                        while (!DateTime.TryParse(Console.ReadLine(), out dateBirth))
                        {
                            Console.WriteLine("Некорректно введенны данные, попробуйте еще раз");
                        }
                        worker.DateBirthday = dateBirth;

                        age = DateTime.Now.Year - dateBirth.Year;

                        if (DateTime.Now.DayOfYear < dateBirth.DayOfYear)
                        {
                            age--;
                        }

                        worker.Age = age;

                        break;

                    case 5:
                        Console.WriteLine("Введите место рождения");

                        worker.PlaceBirth = Console.ReadLine();

                        break;
                }
            }
            return worker;
        }
        /// <summary>
        /// Добавление сотрудника в список
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker()
        {
            List<Worker> workers = GetAllWorkers();
            workers.Add(CreatWorker());

            var jsonText = JsonConvert.SerializeObject(workers, Newtonsoft.Json.Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(Path))
            {

                sw.Write(jsonText);

            }
        }
        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id">Номер удаляемого сотрудника</param>
        public void DeleteWorker(int id)
        {
            List<Worker> workers = GetAllWorkers();

            workers.RemoveAt(id - 1);

            var jsonText = JsonConvert.SerializeObject(workers, Newtonsoft.Json.Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.Write(jsonText);
            }
        }
        /// <summary>
        /// Получение списка сотрудников между двумя датами (включительно)
        /// </summary>
        /// <param name="dateFrom">Начальная дата</param>
        /// <param name="dateTo">Конечная дата</param>
        /// <returns></returns>
        private List<Worker> GetWorkersBetweenTwoDates()
        {
            bool flag = false;
            DateTime dateFrom = new DateTime();
            DateTime dateTo = new DateTime();

            while (!flag)
            {
                Console.WriteLine("Введите начальную дату");

                string dateFromUser = Console.ReadLine();
                flag = DateTime.TryParse(dateFromUser, out var result);
                if (!flag) Console.WriteLine("Вы ввели некорректные  данные попробуйте еще раз.");
                else dateFrom = result;
            }
            flag = false;

            while (!flag)
            {
                Console.WriteLine("Введите конечную дату");

                string dateToUser = Console.ReadLine();
                flag = DateTime.TryParse(dateToUser, out var result);
                if (!flag || result <= dateFrom) Console.WriteLine("Вы ввели некорректные  данные попробуйте еще раз.");
                else dateTo = result;
            }

            List<Worker> workers = GetAllWorkers();

            List<Worker> workerBetweenTwoDates = new List<Worker>();

            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].DateAdded >= dateFrom && workers[i].DateAdded <= dateTo)
                {
                    workerBetweenTwoDates.Add(workers[i]);
                }
            }
            return workerBetweenTwoDates;
        }
        /// <summary>
        /// Вывод списка сотрудников в указанном диапазоне дат
        /// </summary>
        public void ShowWorkersBetweenTwoDates()
        {
            PrintHead();
            PrintInfoWorkers(GetWorkersBetweenTwoDates());
        }
        static void BubbleSort(List<Worker> workers)
        {

        }
        private static void PrintHead()
        {
            Console.WriteLine("|{0, -3}|{1,-15}|{2, -35}|{3,-7}|{4,-4}|{5,-13}|{6,-25}|{7,-36}|" +
            "\n--------------------------------------------------------------------------------------------------------------------------------------------------"
            , "N", "Дата записи", "Ф. И. О.", "Возраст", "Рост", "Дата рождения", "Место рождения", "ID сотрудника");
        }
        private void PrintInfoWorkers(List<Worker> workers)
        {
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"|{i + 1,-3}|{workers[i].DateAdded.ToString("g"),-15}|{workers[i].FIO,-35}|{workers[i].Age,-7}|{workers[i].Height,-4}|{workers[i].DateBirthday.ToString("d"),-13}|{workers[i].PlaceBirth,-25}|{workers[i].uniqueId,-36}|");

            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------\nКонец файла");

        }
    }

}
