using System;
using System.Collections.Generic;
using System.Text;

namespace _5LZ77
{
    class Node
    {
        public int Offset { set; get; }
        public int Length { set; get; }
        public char Symbol { set; get; }

        public Node() { }
        public Node(int Offset, int Length, char Symbol)
        {
            this.Offset = Offset;
            this.Length = Length;
            this.Symbol = Symbol;
        }
        public override string ToString()
        {
            return $"({Offset},{Length},{Symbol})";
        }
        
    }
}
