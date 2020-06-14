using System;
using System.Text;
using System.Collections.Generic;

namespace HammingCode
{

   
    class Program
    {
        static Dictionary<int, int> ControlBitFirst  = new Dictionary<int, int>();

        static StringBuilder Hamming(StringBuilder text ,int Bit)
        {          
            for (int i = 0; i < Bit; i++)
            {
                int clow = 0;
                for (int j = (int)Math.Pow(2, i); j < text.Length; j += (int)Math.Pow(2, i) * 2)
                {
                    for (int z = 0; z < (int)Math.Pow(2, i); z++)
                    {
                        if (j + z < text.Length)
                        {
                            clow += int.Parse(text[j + z].ToString());
                        }

                    }
                    
                }
                if (clow % 2 != 0)
                {
                    ControlBitFirst[(int)Math.Pow(2, i)] = 1;
                    text[(int)Math.Pow(2, i)] = '1';
                }
                else
                {
                    text[(int)Math.Pow(2, i)] = '0';
                    ControlBitFirst[(int)Math.Pow(2, i)] = 0;
                }
                
            }
            return text;
        }
        //0100010000111101
        //100110000110001011101
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку.");
            StringBuilder text = new StringBuilder(" " + Console.ReadLine());

            int Iterator = text.Length - 1;
            int Bit = 1;
            while ((Iterator /= 2) != 0)
            {
                Bit++;
            }
            //
            if (Bit == 0)
            {
                Console.WriteLine("Строка слишком короткая");
                return;
            }

            for (int i = 0; i < Bit; i++)
            {
                if ((int)Math.Pow(2, i) == text.Length)
                {
                    text = new StringBuilder(text + "0");
                    ControlBitFirst.Add((int)Math.Pow(2, i), 0);
                }
                {
                    text = text.Insert((int)Math.Pow(2, i), "0");
                    ControlBitFirst.Add((int)Math.Pow(2, i), 0);
                }

            }
            text = Hamming(text , Bit);

            Console.WriteLine("Закодированное слово(Контрольные биты выделены красным)");
            for (int i = 1; i < text.Length; i++)
            {
                if (ControlBitFirst.ContainsKey(i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(text[i]);
                    Console.ResetColor();
                }
                else
                {                  
                    Console.Write(text[i]);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Введите строку с ошибкой");
            StringBuilder TextFalse = new StringBuilder(" " + Console.ReadLine());
            string otvet = TextFalse.ToString();
            Dictionary<int, int> ControlBitSecond = new Dictionary<int, int>();

            foreach (var c in ControlBitFirst)
            {
                ControlBitSecond.Add(c.Key, int.Parse(TextFalse[c.Key].ToString()));
                TextFalse[c.Key] = '0';
            }
    
            ControlBitFirst = new Dictionary<int, int>();
            
            TextFalse = Hamming(TextFalse , Bit);
            
            int Mistake = 0;
            foreach(var c in ControlBitFirst)
            { 
                if (c.Value != ControlBitSecond[c.Key])
                {
                    Mistake += c.Key;
                }
            }
            Console.WriteLine("Позиция в которой совершена ошибка.");
            Console.WriteLine(Mistake);
            Console.WriteLine("Исправленная строка(Контрольные биты выделены красным, исправленный символ - синим)");
            for (int i = 1; i < otvet.Length; i++)
            {
                if (ControlBitFirst.ContainsKey(i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(otvet[i]);
                    Console.ResetColor();
                }
                else
                {
                    if (Mistake == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        if (otvet[i] == '1')
                            Console.Write(0);
                        else
                            Console.Write(1);
                        Console.ResetColor();
                    }
                    else
                        Console.Write(otvet[i]);
                }
            }
        }
    }
}
