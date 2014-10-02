using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringGame 
{
    class Node : IComparable<Node>, IEquatable<Node>
    {
        private Node parent;
        private int f;
        private int g;
        private int h;
        private string gameString;

        public Node(string s) { gameString = s; }

        public string GameString
        {
            set { gameString = value; }
            get { return gameString; }
        }
        
        public Node Parent
        {
            set { parent = value; }
            get { return parent; }
        }
        public int F
        {
            set { f = value; }
            get { return f; }
        }
        public int G
        {
            set { g = value; }
            get { return g; }
        }
        public int H
        {
            set { h = value; }
            get { return h; }            
        }       

        public void SetH(Node goal)
        {
            char[] goalChar = goal.GameString.ToString().ToCharArray();
            char[] currentChar = GameString.ToString().ToCharArray();
            int currentH = 0;

            for (int i = 0; i < goalChar.Length; i++)
            {
                if (goalChar[i] != currentChar[i])
                    currentH++;
            }
            this.h = (currentH);
        }
       
        public int CompareTo(Node other)
        {
            if (this.f < other.f) 
                return -1;
            else if (this.f > other.f) 
                return 1;
            else 
                return 0;
        }

        public override string ToString()
        {
            return gameString;
        }

        public bool Equals(Node obj)
        {
            if (this.gameString == obj.gameString)
                return true;

            return false;
        }

    }
}

