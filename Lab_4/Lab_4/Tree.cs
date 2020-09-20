using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    class Tree
    {
        public string District { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }

        public Tree(string district, string type, int amount)
        {
            District = district;
            Type = type;
            Amount = amount;
        }

        public Tree()
        {
        }
    }
}
