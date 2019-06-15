using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSchoolLibrary.Controller;
using AutoSchoolLibrary.Model;

namespace AutoSchoolCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует консольная программа учета учеников автошколы");

            Console.WriteLine("Введите ваше имя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var classesController = new ClassesController(userController.CurrentUser);
            if (userController.NewUser)
            {
                Console.Write("Введите фамилию");
                var userName = Console.ReadLine();
                DateTime birthDate = ParseDateTime("Дата рождения");
                var age = ParseInt("Возраст");

                userController.SetNewUserData(userName, birthDate, age);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что хотите сделать?");
                Console.WriteLine("A - занятие");
                Console.WriteLine("E - exit");

                Console.WriteLine();
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        var exe = EnterTimeTable();
                        classesController.Add(exe.TimeClasses, exe.Begin, exe.End);

                        foreach (var item in classesController.TimeTables)
                        {
                            Console.WriteLine($"\t{item.TimeClasses} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.E:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, TimeClasses TimeClasses) EnterTimeTable()
        {
            Console.Write("Введите упражнения ");
            var name = Console.ReadLine();

            var begin = ParseDateTime("Начало занятия ");
            var end = ParseDateTime("Конец занятия ");

            var timeClassses = new TimeClasses(name);
            return (begin, end, timeClassses);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Не верный формат {value}");
                }
            }

            return birthDate;
        }

        private static int ParseInt(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Не верный формат поля {name}");
                }
            }
        }
    }
}
