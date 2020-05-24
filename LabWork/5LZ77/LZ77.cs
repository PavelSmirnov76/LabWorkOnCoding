using System;
using System.Collections.Generic;
using System.Text;

namespace _5LZ77
{
    class LZ77
    {
        private string SearchBuffer { set; get; }
        private string ProactiveBuffer { set; get; }
        private List<Node> Label { set; get; }

        public List<Node> decode(string Text) 
        {
            ProactiveBuffer = Text;
            SearchBuffer = "";
            Label.Add(new Node(0, 0, ProactiveBuffer[0]));
            return Label;
        }
    }
}
