using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string result;
            List<Node> closed = new List<Node>();
            PriorityQueue<Node> open = new PriorityQueue<Node>();            

            Console.WriteLine("enter initial string set: ");
            input = Console.ReadLine();
            Console.WriteLine("Enter desired string set: ");
            result = Console.ReadLine();

            Node start = new Node(input);
            Node goal = new Node(result);
            
            start.G = 0; //set G to amount of nodes traversed aka priority
            start.SetH(goal); //set the h value based on the goal node's value

            Node current = start;
            open.Enqueue(current); //add current node into open list

            while (open.Peek() != goal) 
            {
                //generate children based on items in open list (current)
                List<Node> Children = getChildren(current, closed, open);

                current = open.Dequeue(); //pop current node
                closed.Add(current); //add current node into closed list

                //Console.WriteLine(current.GameString);

                foreach (Node child in Children)
                {
                    //child.SetH(goal);
                    open.Enqueue(child);
                } 

                if (current.Equals(goal))
                {
                    Console.WriteLine("found path:");
                    Node last = current;
                    List<Node> list = new List<Node>();
                    while (last.Parent != null)
                    {
                        list.Add(last);
                        last = last.Parent;
                    }
                    list.Add(last);
                    list.Reverse();
                    foreach (Node n in list)
                        Console.WriteLine(n.ToString());
                    break;
                }

                if (open.isEmpty())
                {
                    Console.WriteLine("failed to find path");
                    break;
                }

                if (Children == null)
                {
                    current = open.Dequeue(); //set first element of open list to current and pop
                    continue;
                }             
            }
            Console.ReadKey(true);
        }

        static List<Node> getChildren(Node current, List<Node> closedList, PriorityQueue<Node> openList)
        {           
            string gameString = current.GameString;
            List<Node> children = new List<Node>();

            for (int i = 0; i < gameString.Length - 1; i++)
            {
                char[] charString = gameString.ToCharArray();                
                
                char temp = charString[i];
                charString[i] = charString[i+1];
                charString[i+1] = temp;

                string s = new string(charString);
                Node childNode = new Node(s);
                childNode.G = current.G + 1;
                childNode.Parent = current;

                //if openlist and closed list does not contain new node, add to children
                if (!openList.Contains(childNode) && !closedList.Contains(childNode) && !childNode.Equals(current) )
                    children.Add(childNode);
            }
            return children;
        }
    }
}
