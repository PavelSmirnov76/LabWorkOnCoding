using System;
using System.Collections.Generic;
using System.Linq;

namespace _3ArithmeticCoding
{
    public class ArithmeticCode
    {
        private List<Node> nodes = new List<Node>();
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public void Build(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in Frequencies)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            }

            nodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();

            double low = 0;
            foreach (Node node in nodes)
            {
                node.Range = Math.Round(((double)(node.Frequency) / (source.Length)), 8);
                node.Low = Math.Round(low, 8);
                node.High = low + node.Range;
                low += node.Range;
            }
        }

        public decimal[] Encode(string source)
        {
            nodes.Reverse();
            decimal[] q = new decimal[2] { 0, 1 };
            decimal OldLow = 0;
            decimal OldHigh = 1;

            for (int i = 0; i < source.Length; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (source[i] == nodes[j].Symbol)
                    {
                        OldLow = q[0];
                        OldHigh = q[1];
                        q[1] = OldLow + (OldHigh - OldLow) * (decimal)nodes[j].High;
                        q[0] = OldLow + (OldHigh - OldLow) * (decimal)nodes[j].Low;
                        Console.WriteLine("{0} {1}", Math.Round(q[0],28), Math.Round(q[1], 28));

                        break;
                    }
                }
            }

            string LowKef = (q[0] - OldLow).ToString();
            int z;
            for (z = 0; (LowKef[z] == '0' || LowKef[z] == ',') && z + 1 < LowKef.Length; z++) ;
            if (z <= 28)
                q[0] = Math.Round(q[0],z);

            string HighKef = (q[1] - OldHigh).ToString();
            for (z = 0; (LowKef[z] == '0' || LowKef[z] == ',') && z + 1 < LowKef.Length; z++) ;
            if (z <= 28)
                q[1] = Math.Round(q[1], z);
            return q;
        }

        public string Decode(List<Node> allNodes, int count)
        {
            string decode = "";
            double code = allNodes[allNodes.Count - 1].Low;
            int symbolsCount = 0;

            while (true)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (code >= nodes[i].Low && code < nodes[i].High)
                    {
                        decode += nodes[i].Symbol;
                        code = Math.Round((code - nodes[i].Low) / (nodes[i].High - nodes[i].Low), 8);

                        symbolsCount++;
                        if (symbolsCount == count)
                            return decode;
                    }
                }
            }
        }
    }
}
