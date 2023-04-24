using Newtonsoft.Json;
using System;


 namespace Homework_Skillbox_Module_7
{
    public struct Worker
    {
        [JsonProperty]
        public Guid uniqueId { get; private set; } // уникальный номер
        [JsonProperty]
        public DateTime DateAdded { get; private set; }   //Дата и время добавления записи
        public string FIO { get; set; } //Ф.И.О.
        public int Age { get; set; } //Возраст
        public int Height { get; set; }//Рост
        public DateTime DateBirthday { get; set; }   //Дата рождения
        public string PlaceBirth { get; set; } //Место рождения

        public Worker() 
        {
            uniqueId = Guid.NewGuid();
            DateAdded = DateTime.Now;
        }
    }
}