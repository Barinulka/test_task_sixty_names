using ClassLibrary;
using ClassLibrary.Figures;
using ConsoleApp;
using System.Data;

class Program
{
    private static readonly Dictionary<string, string> elems = new()
    {
        { "triangle", "Вычислить площадь треугольника" },
        { "circle", "Вычислить площадь круга" },
        { "exit", "Выход из приложения." }
    };

    static void Main(string[] args)
    {

        Console.WriteLine("Введите название фигуры, для расчета ее площади\r\n");

        ShowNavMenu();

        Library figure = new Library();
        string command = string.Empty;

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

                switch (command)
                {
                    case "треугольник":
                    case "triangle":
                        figure.setFigure(new Triangle());
                        Console.WriteLine($"\nПлощадь треугольника: {figure.Area()}");
                        Console.WriteLine("\n------------------------\n");
                        break;
                    case "круг":
                    case "circle": 
                        figure.setFigure(new Circle());
                        Console.WriteLine($"\nПлощадь круга: {figure.Area()}");
                        Console.WriteLine("\n------------------------\n");
                        break;
                    case "/help":
                        ShowNavMenu();
                        break;
                    default:
                        Console.WriteLine($"Не найдена такая фигура: {command}");
                        Console.WriteLine($"Введите \"/help\" для вывода списка доступних фигур: {command}");
                        Console.WriteLine();
                        break;
                }

            } 
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }

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