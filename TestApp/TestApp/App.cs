using System;
using TestApp.Controllers;

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
            { "upload_data", "Создать отчет по физ. лицам, у которых есть действующие договора по компаниям, расположенных в городе Москва." },
            { "exit", "Выход из приложения." }
        };

        static void Main()
        {
            Console.WriteLine("Выберите одно из следующих действий\r\n");

            ShowNavMenu();

            string command = string.Empty;

            var controller = new DefaultController();

            int result = 0;

            while (true)
            {
                try
                {
                    Console.Write("> ");

                    command = Console.ReadLine();

                    if (command.ToLower().Equals("exit"))
                    {
                        break;
                    }

                    switch (command.ToLower())
                    {
                        case "year":

                            result = controller.GetSumContracts();

                            Console.WriteLine($"Сумма всех заключенных договоров за текущий год: {result} \n");

                            result = 0;

                            break;

                        case "rus":

                            result = controller.GetLegalSumContractsFromRus();

                            Console.WriteLine($"Cумма заключенных договоров по каждому контрагенту из России: {result} \n");

                            result = 0;

                            break;

                        case "email":

                            var elems = controller.GetLegalEmailsList();

                            foreach (var elem in elems)
                            {
                                Console.WriteLine($"{elem}\n");
                            }

                            break;

                        case "change_status":

                            result = controller.ChanheContractStatus();

                            Console.WriteLine($"Изменено {result} строк(и)\n");

                            break;

                        case "upload_data":

                            var uploadData = controller.UploadData();

                            Console.WriteLine($"{uploadData}");

                            break;

                        default:

                            Console.WriteLine("\nВведена неправильная команда!");

                            Console.WriteLine();

                            break;
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                
                

            }

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
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
