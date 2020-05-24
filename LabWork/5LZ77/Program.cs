using System;
using System.Collections.Generic;
namespace _5LZ77
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1. Сжать текст с помощью LZ77");
                Console.WriteLine("2. Декодировать текст");
                Console.WriteLine("3. выход.");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите текст.");
                        string Text = Console.ReadLine();
                        LZ77 LZ77 = new LZ77();
                        List<Node> Decode = LZ77.decode(Text);
                        Console.Write("Закодированный текст. ");
                        foreach (var c in Decode)
                        {
                            Console.Write(c);
                        }
                        Console.WriteLine();


                        break;

                    case "2":

                        break;
                    case "3":
                        Console.WriteLine("Выход");

                        return;
                    default:
                        Console.WriteLine("Выберите один из пунктов меню.");
                        break;
                }
            }
            while (true);
        }
    }
}
