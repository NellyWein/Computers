using System;
using System.Globalization;

namespace Catalog
{
    public class Computer
    {
        protected string manufacturer;
        protected string model;
        protected double price;
        protected int ram;

        public Computer(string man = "Unknown", string mod = "Unknown", double pr = 0.0, int r = 0)
        {
            if (string.IsNullOrWhiteSpace(man)) throw new ArgumentException("Ошибка: производитель не может быть пустым.");
            if (string.IsNullOrWhiteSpace(mod)) throw new ArgumentException("Ошибка: модель не может быть пустой.");
            if (pr < 0.0) throw new ArgumentException("Ошибка: цена не может быть отрицательной.");
            if (r < 0) throw new ArgumentException("Ошибка: объём оперативной памяти не может быть отрицательным.");

            manufacturer = man;
            model = mod;
            price = pr;
            ram = r;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Производитель: " + manufacturer);
            Console.WriteLine("Модель: " + model);
            Console.WriteLine("Цена: " + price.ToString("F2", CultureInfo.CurrentCulture) + " руб.");
            Console.WriteLine("Оперативная память: " + ram + " ГБ");
        }
        //Свойства
        public string GetManufacturer() { return manufacturer; }
        public string GetModel() { return model; }
        public double GetPrice() { return price; }
        public int GetRam() { return ram; }

        public virtual string GetTypeName() { return "Computer"; }
    }
}
