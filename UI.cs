using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Catalog
{
    public static class UI
    {
        public static void PrintTableHeader(int wNo, int wType, int wMan, int wModel, int wRam, int wPrice)
        {
            Console.Write(AlignLeft("№", wNo) + " | " + AlignLeft("Тип", wType) + " | " + AlignLeft("Производитель", wMan) + " | " + AlignLeft("Модель", wModel) + " | " + AlignLeft("ОЗУ(ГБ)", wRam) + " | " + AlignLeft("Цена", wPrice) + "\n");
            Console.Write(new string('-', wNo) + "-+-" + new string('-', wType) + "-+-" + new string('-', wMan) + "-+-" + new string('-', wModel) + "-+-" + new string('-', wRam) + "-+-" + new string('-', wPrice) + "\n");
        }

        public static void PrintComputersTable(List<Computer> computers)
        {
            if (computers == null || computers.Count == 0)
            {
                Console.WriteLine("В списке нет компьютеров.");
                return;
            }

            const int wNo = 4, wType = 18, wMan = 20, wModel = 28, wRam = 8, wPrice = 14;
            PrintTableHeader(wNo, wType, wMan, wModel, wRam, wPrice);

            int idx = 1;
            foreach (var comp in computers)
            {
                string priceStr = comp.GetPrice().ToString("F2", CultureInfo.CurrentCulture);
                StringBuilder line = new StringBuilder();
                line.Append(AlignLeft(idx.ToString(), wNo));
                line.Append(" | ");
                line.Append(AlignLeft(TruncateStr(comp.GetTypeName(), wType), wType));
                line.Append(" | ");
                line.Append(AlignLeft(TruncateStr(comp.GetManufacturer(), wMan), wMan));
                line.Append(" | ");
                line.Append(AlignLeft(TruncateStr(comp.GetModel(), wModel), wModel));
                line.Append(" | ");
                line.Append(AlignRight(comp.GetRam().ToString(), wRam));
                line.Append(" | ");
                line.Append(AlignRight(priceStr, wPrice));
                Console.WriteLine(line.ToString());
                idx++;
            }
        }

        public static void PrintMenu()
        {
            string title = "Каталог устройств";
            const int width = 60;
            int pad = (width - title.Length) / 2;
            Console.WriteLine(new string('=', width));
            Console.WriteLine(new string(' ', pad) + title);
            Console.WriteLine(new string('=', width));
            Console.WriteLine(" 1 — Добавить устройство");
            Console.WriteLine(" 2 — Показать список (таблица)");
            Console.WriteLine(" 3 — Удалить устройство (по номеру)");
            Console.WriteLine(" 4 — Очистить экран");
            Console.WriteLine(" 5 — Выход");
            Console.WriteLine();
        }

        public static void ClearScreen()
        {
            try
            {
                Console.Clear();
            }
            catch
            {
                for (int i = 0; i < 30; i++) Console.WriteLine();
            }
        }

        public static string TruncateStr(string s, int w)
        {
            if (s == null) return string.Empty;
            if (s.Length <= w) return s;
            if (w <= 3) return new string('.', w);
            return s.Substring(0, w - 3) + "...";
        }

        private static string AlignLeft(string s, int width)
        {
            if (s == null) s = string.Empty;
            return s.PadRight(width);
        }

        private static string AlignRight(string s, int width)
        {
            if (s == null) s = string.Empty;
            return s.PadLeft(width);
        }
    }
}
