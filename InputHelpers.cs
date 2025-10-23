using System;
using System.Globalization;

namespace Catalog
{
    public static class InputHelpers
    {
        public static double SafeInputDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s))
                {
                    Console.WriteLine("Ошибка: введите числовое значение.");
                    continue;
                }
                double value;
                if (!double.TryParse(s.Trim(), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out value))
                {
                    Console.WriteLine("Ошибка: введите числовое значение.");
                    continue;
                }
                if (value < 0.0)
                {
                    Console.WriteLine("Ошибка: значение не может быть отрицательным.");
                    continue;
                }
                return value;
            }
        }

        public static int SafeInputInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s))
                {
                    Console.WriteLine("Ошибка: введите целое число.");
                    continue;
                }
                int value;
                if (!int.TryParse(s.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out value))
                {
                    Console.WriteLine("Ошибка: введите целое число.");
                    continue;
                }
                if (value < 0)
                {
                    Console.WriteLine("Ошибка: значение не может быть отрицательным.");
                    continue;
                }
                return value;
            }
        }

        public static int SafeInputNonNegativeInt(string prompt)
        {
            return SafeInputInt(prompt);
        }

        public static bool PromptYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (y/n): ");
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) continue;
                char c = char.ToLowerInvariant(s.Trim()[0]);
                if (c == 'y') return true;
                if (c == 'n') return false;
                Console.WriteLine("Пожалуйста, введите 'y' или 'n'.");
            }
        }

        public static Computer CreateComputer()
        {
            Console.Write("Введите тип устройства (1 — PC, 2 — Laptop): ");
            string type = Console.ReadLine();
            if (type == null) throw new ArgumentException("Ошибка чтения типа устройства.");
            type = type.Trim().ToLowerInvariant();

            if (!(type == "1" || type == "pc" || type == "p" || type == "personal"
                || type == "2" || type == "laptop" || type == "lap"))
            {
                throw new ArgumentException("Ошибка: введён неверный тип устройства. Допустимые: 1, 2, pc, laptop.");
            }

            Console.Write("Введите производителя: ");
            string man = Console.ReadLine() ?? string.Empty;
            man = man.Trim();
            if (string.IsNullOrWhiteSpace(man)) throw new ArgumentException("Ошибка: производитель не может быть пустым.");

            Console.Write("Введите модель: ");
            string mod = Console.ReadLine() ?? string.Empty;
            mod = mod.Trim();
            if (string.IsNullOrWhiteSpace(mod)) throw new ArgumentException("Ошибка: модель не может быть пустой.");

            double price = SafeInputDouble("Введите цену: ");
            int ram = SafeInputInt("Введите объём оперативной памяти (ГБ): ");

            if (type == "1" || type == "pc" || type == "p" || type == "personal")
                return new PersonalComputer(man, mod, price, ram);
            return new Laptop(man, mod, price, ram);
        }
    }
}
