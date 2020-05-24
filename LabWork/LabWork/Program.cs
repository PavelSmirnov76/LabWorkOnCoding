using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace LabWork
{
    class Program
    {

        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("1. Сжать текст с помощью кодов Хаффмана.");
                Console.WriteLine("2. Декодировать текст по частотному словарю.");
                Console.WriteLine("3. выход.");
                switch (Console.ReadLine())
                {
                    case "1":
                        HuffmanTree huffmanTree = new HuffmanTree();
                        Console.WriteLine("Введите текст.");
                        string input = Console.ReadLine();
                        
                        huffmanTree.Build(input);
                        BitArray encoded = huffmanTree.Encode(input);
                        Console.Write("Закодированная строка: ");
                        foreach (bool bit in encoded)
                        {
                            Console.Write((bit ? 1 : 0) + "");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Степень зжатия: {0}", Math.Round(Convert.ToDouble(input.Length*8) / Convert.ToDouble(encoded.Length),2));
                        break;
                        
                    case "2":
                        huffmanTree = new HuffmanTree();

                        Console.WriteLine("Введите частотный словарь в формате \"Символ\"-\"Частота\" \"Символ\"-\"Частота\" ...");
                        Dictionary<char, int> Frequencies = new Dictionary<char, int>();
                        input = Console.ReadLine();
                        string[] inputMas = input.Split();
                        for (int i = 0; i < inputMas.Length; i++)
                        {
                            Frequencies.Add(inputMas[i][0], int.Parse(inputMas[i].Substring(inputMas[i].IndexOf("-")+1)));
                        }
                        huffmanTree.Build(Frequencies);

                        Console.WriteLine("Введите закодированное сообщение.");
                        input = Console.ReadLine();
                        bool[] DecodedString = new bool[input.Length];
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (input[i] == '1')
                                DecodedString[i] = true;
                            else
                                DecodedString[i] = false;
                        }
                        BitArray DecodedBitArray = new BitArray(DecodedString);
                        string decoded = huffmanTree.Decode(DecodedBitArray);
                        Console.WriteLine("Декодированное сообщение: " + decoded);
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
