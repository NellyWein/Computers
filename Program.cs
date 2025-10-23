using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Catalog
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
            }
            catch
            {
            }

            var computers = new List<Computer>();

            while (true)
            {
                UI.ClearScreen();
                UI.PrintMenu();
                Console.Write("Введите опцию (1-5): ");
                string choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Ошибка ввода. Попробуйте снова.");
                    Thread.Sleep(500);
                    continue;
                }
                char c = choice.Trim()[0];

                if (c == '1')
                {
                    try
                    {
                        Computer comp = InputHelpers.CreateComputer();
                        if (comp != null)
                        {
                            computers.Add(comp);
                            Console.WriteLine("Устройство успешно добавлено!");
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла ошибка: " + e.Message);
                    }
                    Console.WriteLine("Нажмите Enter для продолжения...");
                    Console.ReadLine();
                }
                else if (c == '2')
                {
                    UI.ClearScreen();
                    Console.WriteLine("Список устройств (таблица):\n");
                    UI.PrintComputersTable(computers);
                    Console.WriteLine("\nНажмите Enter для возврата в меню...");
                    Console.ReadLine();
                }
                else if (c == '3')
                {
                    if (computers.Count == 0)
                    {
                        Console.WriteLine("В списке нет компьютеров — нечего удалять.");
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        continue;
                    }

                    UI.ClearScreen();
                    UI.PrintComputersTable(computers);
                    int n = InputHelpers.SafeInputNonNegativeInt("Введите номер устройства для удаления (0 — отмена): ");

                    if (n == 0)
                    {
                        Console.WriteLine("Удаление отменено.");
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        continue;
                    }

                    if (n < 1 || n > computers.Count)
                    {
                        Console.WriteLine("Ошибка: неверный номер. Введите число от 1 до " + computers.Count + ".");
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        continue;
                    }

                    Computer comp = computers[n - 1];
                    Console.WriteLine("\nВы выбрали для удаления:");
                    comp.PrintInfo();


                    if (InputHelpers.PromptYesNo("Подтвердить удаление"))
                    {
                        computers.RemoveAt(n - 1);
                        Console.WriteLine("Устройство удалено.");
                    }
                    else
                    {
                        Console.WriteLine("Удаление отменено.");
                    }
                    Console.WriteLine("Нажмите Enter для продолжения...");
                    Console.ReadLine();
                }
                else if (c == '4')
                {
                    UI.ClearScreen();
                    Console.WriteLine("Экран очищен. Нажмите Enter для продолжения...");
                    Console.ReadLine();
                }
                else if (c == '5')
                {
                    Console.WriteLine("Выход...");
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите значение от 1 до 5.");
                    Console.WriteLine("Нажмите Enter для продолжения...");
                    Console.ReadLine();
                }
            }

            return 0;
        }
    }
}
