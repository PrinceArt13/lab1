using System;

namespace lab1
{
    class View
    {
        static void MainMenu()
        {
            Console.WriteLine("\nВыберите действие с файлом\n" +
                "1. Выбрать файл для чтения и записи\n" +
                "2. Вывод всех записей\n" +
                "3. Вывод записи по номеру\n" +
                "4. Удаление записи из файла\n" +
                "5. Добавление записи в файл\n" +
                "ESC. Выйти из программы\n");
        }
        //1
        static void SetPath(Controller controller)
        {
            Console.WriteLine("Введите путь к файлу:\n");
            string path = Console.ReadLine();
            if (!controller.SetAndCheckPath(path))
            {
                Console.WriteLine("Введите корректный путь к файлу!");
                SetPath(controller);
            }
        }
        static string ReturnPath(Controller controller)
        {
            if (controller.Path != null)
            {
                return controller.Path;
            }
            else return "Путь не выбран";
        }

        static void doActionMainMenu(Controller controller)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    SetPath(controller);
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Все записи из файла " + ReturnPath(controller) + ":\n");
                    controller.GetAllRecords().ForEach(Console.WriteLine);
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Введите номер искомой записи: ");
                    try
                    {
                        int a = int.Parse(Console.ReadLine());
                        controller.GetSepRecord(a).ForEach(Console.WriteLine);
                    }
                    catch
                    {
                        Console.WriteLine("Запись под этим номером не найдена или введена неверно!");
                    }
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("Введите номер записи, которую нужно удалить: ");
                    try
                    {
                        int a = int.Parse(Console.ReadLine());
                        controller.DeleteRecord(a);
                    }
                    catch
                    {
                        Console.WriteLine("Запись под этим номером не найдена или введена неверно!");
                    }
                    break;
                case ConsoleKey.D5:
                    try
                    {
                        Console.WriteLine("Введите данные о студенте на английском языке:\n" +
                            "Имя;Фамилия;Группа;Стипендия;Курс;True/False(Имеет российское гражданство)\n");
                        controller.AddRecord(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Вы неправильно ввели данные, попробуйте написать как на примере:\n" +
                            "Ivan;Ivanov;1A11;1234;3;True");
                    }
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        static void Main(string[] args)
        {
            Controller controller = new();
            controller.Path = "C:\\Users\\artem\\Desktop\\Архитектура ИС\\lab1\\CsvFile.csv";
            do
                {
                    MainMenu();
                    doActionMainMenu(controller);
                }
            while(true);
        }
    }
}
