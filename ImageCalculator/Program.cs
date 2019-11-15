using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new MatrixCalculator();
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите путь к папке, с которой необходимо начинать поиск изображений:");
                    var path = Console.ReadLine(); //Start path better make in C?
                    var tree = new FileTree(Console.ReadLine());

                    tree.Accept(calc);

                    WriteColorToConsole("Файлы с параметрами были созданы.", ConsoleColor.Green);
                }
                catch (Exception e)
                {
                    WriteColorToConsole(e.Message, ConsoleColor.Red);
                }
            }
        }

        private static void WriteColorToConsole(string data, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
