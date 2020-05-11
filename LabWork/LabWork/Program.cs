using System;
using System.IO;
using System.Collections;


namespace LabWork
{
    class Program
    {

        static string Coder(string Text)
        {

            return null;
        }
        static void Main(string[] args)
        {
            //string path = "Text.txt";

            //StreamReader sr = new StreamReader(path);
            //string input = sr.ReadToEnd();
            string input = Console.ReadLine();
            HuffmanTree huffmanTree = new HuffmanTree();

            huffmanTree.Build(input);

            // Encode
            BitArray encoded = huffmanTree.Encode(input);

            Console.Write("Encoded: ");
            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");
            }
            Console.WriteLine();

            // Decode
            string decoded = huffmanTree.Decode(encoded);

            Console.WriteLine("Decoded: " + decoded);

            //huffmanTree.Print();



            Console.ReadLine();
        }
    }
}
