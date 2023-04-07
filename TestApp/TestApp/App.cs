using System;

namespace TestApp
{
    internal class App
    {

        private static readonly Dictionary<string, string> elems = new()
        {
            { "year", "Вывести сумму всех заключенных договоров за текущий год." },
            { "rus", "Вывести сумму заключенных договоров по каждому контрагенту из России" },
            { "email", "Вывести список e-mail уполномоченных лиц, заключивших договора за последние 30 дней, на сумму больше 40000." },
            { "change_status", "Изменить статус договора на \"Расторгнут\" для физических лиц старше 60 лет, у которых есть действующий договор." },
            { "to_json", "Создать отчет по физ. лицам, у которых есть действующие договора по компаниям, расположенных в городе Москва." }
        };

        static void Main()
        {
            bool endApp = false;
            
            Console.WriteLine("Выберите одно из следующих действий\r\n");

            ShowNavMenu();

            while (!endApp)
            {

                string userInput;
                

                Console.Write("Введите команду для выполнения: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "year":
                        Console.WriteLine("\nКоманда {0} найдена\n", userInput);
                        break;
                    case "rus":
                        Console.WriteLine("\nКоманда {0} найдена\n", userInput);
                        break;
                    case "email":
                        Console.WriteLine("\nКоманда {0} найдена\n", userInput);
                        break;
                    case "change_status":
                        Console.WriteLine("\nКоманда {0} найдена\n", userInput);
                        break;
                    case "to_json":
                        Console.WriteLine("\nКоманда {0} найдена\n", userInput);
                        break;
                    default:
                        Console.WriteLine("\nВведена неправильная команда!");
                        Console.WriteLine();
                        break;
                }

                

                Console.WriteLine("\n------------------------\n");

                Console.Write("Введите 'exit' для завершения программы, или нажмите Enter для продолжения: ");
                if (Console.ReadLine() == "exit") endApp = true;

                Console.WriteLine("\n");
            } 
            return;
        }

        public static void ShowNavMenu()
        {
            Console.WriteLine("\n------------------------\n");
            foreach (var elem in elems)
            {
                Console.WriteLine($"{elem.Key} - {elem.Value}");
            }
            Console.WriteLine("\n------------------------\n");
        }

       
    }
}
