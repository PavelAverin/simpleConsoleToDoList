using System.Security.Cryptography.X509Certificates;

namespace ToDoList
{
    class Program
    {
        enum UserChoice
        {
            AddTask = 1,
            DeleteTask,
            Exit
        }

        static void Main()
        {
            List<string> toDoList = new List<string>();
            bool isActive = true;

            Console.WriteLine("Здравствуйте. Добро пожаловать в ваш личный список дел.\n");

            while (isActive)
            {
                
                if (toDoList.Count > 0)
                {
                    Console.WriteLine("Список доступных задач:");

                    for (int i = 0; i < toDoList.Count; i++)
                    {
                        Console.WriteLine("- " + toDoList[i]);
                    }

                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("В список задач пока не было добавлено ни одной задачи.");
                    Console.WriteLine("");
                }

                Console.WriteLine(
                    "Выберите действие из списка:\n" +
                    "1 — Добавить новую задачу\n" +
                    "2 — Удалить задачу\n" +
                    "3 — Выйти\n"
                    );

                Console.Write("Ваш выбор: ");

                string? strChoice = Console.ReadLine();

                Int32.TryParse(strChoice, out int intChoice);

                switch (intChoice)
                {
                    case (int)UserChoice.AddTask:
                        Console.Write("\nВведите задачу: ");
                        string? task = Console.ReadLine();

                        if (!String.IsNullOrEmpty(task))
                        {
                            toDoList.Add(task);
                            Console.Clear();
                            Console.WriteLine($"Добавлена новая задача: {task}\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Извините, но вы ничего не ввели. Попробуйте снова.\n");
                        }
                        break;

                    case (int)UserChoice.DeleteTask:
                        {
                            Console.Clear();

                            if (toDoList.Count > 0)
                            {
                                for (int i = 0; i < toDoList.Count; i++)
                                {
                                    Console.WriteLine("(" + (i + 1) + ")" + toDoList[i]);
                                }

                                Console.Write("Введите номер задачи, которую хотите удалить: ");

                                string? taskNum = Console.ReadLine();
                                Int32.TryParse(taskNum, out int intNum);

                                if (intNum > 0 && intNum <= toDoList.Count)
                                {
                                    toDoList.RemoveAt(intNum - 1);
                                    Console.Clear();
                                    Console.WriteLine("Задача успешно удалена.");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Вы введи неверное значение.");
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Список задач пуст. Нажмите Enter, чтобы продолжить.");
                                Console.ReadLine();
                            }
                        }
                        break;

                    case (int)UserChoice.Exit:
                        isActive = false;
                        Console.Clear();
                        Console.WriteLine("До свидания!");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Извините, но вы ввели некоректное значение.\n");
                        break;
                }
            }
        }
    }
}