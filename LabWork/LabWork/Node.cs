using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LabWork
{
    public class Node
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public Node(char Symbol, int Frequency)
        {
            this.Symbol = Symbol;
            this.Frequency = Frequency;
            this.Right = null;
            this.Left = null;
        }
        public Node(char Symbol, int Frequency, Node Left, Node Right)
        {
            this.Symbol = Symbol;
            this.Frequency = Frequency;
            this.Right = Right;
            this.Left = Left;
        }
        public List<bool> Traverse(char symbol, List<bool> data)
        {
            
            if (Right == null && Left == null)
            {
                if (symbol.Equals(this.Symbol))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (Left != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = Left.Traverse(symbol, leftPath);
                }

                if (Right != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = Right.Traverse(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
        public override string ToString()
        {
            return Symbol + ": " + Frequency.ToString();
        }
    }
}
