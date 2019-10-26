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
                    var path = Console.ReadLine();
                    var tree = new FileTree(path);
                    tree.Accept(calc);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Файлы с параметрами были созданы.");
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }
    }
}
