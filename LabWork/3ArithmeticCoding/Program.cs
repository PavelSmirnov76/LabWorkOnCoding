using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AruthmeticCoding
{
    using Freq = Dictionary<char, long>;
    using Triple = Tuple<BigInteger, int, Dictionary<char, long>>;

    class Program
    {
        static Freq CumulativeFreq(Freq freq)
        {
            long total = 0;
            Freq cf = new Freq();
            for (int i = 0; i < 256; i++)
            {
                char c = (char)i;
                if (freq.ContainsKey(c))
                {
                    long v = freq[c];
                    cf[c] = total;
                    total += v;
                }
            }
            return cf;
        }

        static Triple ArithmeticCoding(string str, long radix)
        {
            
            Freq freq = new Freq();
            foreach (char c in str)
            {
                if (freq.ContainsKey(c))
                {
                    freq[c] += 1;
                }
                else
                {
                    freq[c] = 1;
                }
            }

            
            Freq cf = CumulativeFreq(freq);

            
            BigInteger @base = str.Length;

            
            BigInteger lower = 0;

            
            BigInteger pf = 1;

            
            foreach (char c in str)
            {
                BigInteger x = cf[c];
                lower = lower * @base + x * pf;
                pf = pf * freq[c];
            }

            
            BigInteger upper = lower + pf;

            int powr = 0;
            BigInteger bigRadix = radix;

            while (true)
            {
                pf = pf / bigRadix;
                if (pf == 0) break;
                powr++;
            }

            BigInteger diff = (upper - 1) / (BigInteger.Pow(bigRadix, powr));
            return new Triple(diff, powr, freq);
        }

        static string ArithmeticDecoding(BigInteger num, long radix, int pwr, Freq freq)
        {
            BigInteger powr = radix;
            BigInteger enc = num * BigInteger.Pow(powr, pwr);
            long @base = freq.Values.Sum();

            
            Freq cf = CumulativeFreq(freq);

            
            Dictionary<long, char> dict = new Dictionary<long, char>();
            foreach (char key in cf.Keys)
            {
                long value = cf[key];
                dict[value] = key;
            }

            
            long lchar = -1;
            for (long i = 0; i < @base; i++)
            {
                if (dict.ContainsKey(i))
                {
                    lchar = dict[i];
                }
                else if (lchar != -1)
                {
                    dict[i] = (char)lchar;
                }
            }

            
            StringBuilder decoded = new StringBuilder((int)@base);
            BigInteger bigBase = @base;
            for (long i = @base - 1; i >= 0; --i)
            {
                BigInteger pow = BigInteger.Pow(bigBase, (int)i);
                BigInteger div = enc / pow;
                char c = dict[(long)div];
                BigInteger fv = freq[c];
                BigInteger cv = cf[c];
                BigInteger diff = enc - pow * cv;
                enc = diff / fv;
                decoded.Append(c);
            }

            
            return decoded.ToString();
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1. Сжать текст с помощью Арифметического алгоритма");
                Console.WriteLine("2. Декодировать текст по частотному словарю.");
                Console.WriteLine("3. выход.");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите текст.");
                        string input = Console.ReadLine();
                        Triple encoded = ArithmeticCoding(input, 10);

                        Console.WriteLine("Результат кодирования. (число после запятой) {0}", encoded.Item1* BigInteger.Pow(10, encoded.Item2));

                        Console.WriteLine("Степень зжатия {0}", Math.Round(Convert.ToDouble(input.Length * 8) / Convert.ToDouble(encoded.Item1.ToString().Length * 8), 2));
                        break;

                    case "2":
                        Console.WriteLine("Введите частотный словарь в формате \"Символ\"-\"Частота\" \"Символ\"-\"Частота\" ...");
                        Dictionary<char, long> Frequencies = new Dictionary<char, long>();
                        input = Console.ReadLine();
                        string[] inputMas = input.Split();
                        for (int i = 0; i < inputMas.Length; i++)
                        {
                            Frequencies.Add(inputMas[i][0], long.Parse(inputMas[i].Substring(inputMas[i].IndexOf("-") + 1)));
                        }
                        Console.WriteLine("Введите число (после запятой)");
                        int Number = int.Parse(Console.ReadLine());
                        int pref = 0;
                        while (true)
                        {
                            if (Number % 10 != 0) break;
                            Number = Number / 10;
                            pref++;
                        }

                        string dec = ArithmeticDecoding(Number, 10, pref, Frequencies);
                        Console.WriteLine(dec);
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