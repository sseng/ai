using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Markov
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            markov test = new markov();
            //test.add("one", "two", "three");
            //test.add("one", "two", "four");
            //test.add("one", "two", "five");

            //string a = test.lookup("one", "two");

            //Console.Write(a);
            //Console.WriteLine();
            //Console.ReadKey();

            //string source = "a cat is a dog is a cow is a boy is cat";
            StreamReader sr = new StreamReader("prideandprejudice.txt");            
            String line = sr.ReadToEnd();
            //Console.WriteLine(line);
            string source = line;
            


            test.storeWords(source);

            string b = test.lookup("a", "cat");
            string c = test.lookup("cat", b);
            string d = test.lookup("is", "a");

            
            string first = test.sentence[0];
            string second = test.sentence[1];

            Console.Write(first + " " + second + " ");

            for (int i = 0; i < 100; i++)
            {
                string third = test.lookup(first, second);

                if (third == "")
                {
                    
                    int position = rand.Next(test.sentence.Count());
                    third = test.sentence[position];
                    
                    if (position < test.sentence.Length - 1)
                    {
                        string fourth = test.sentence[position + 1];
                        Console.Write(third + " ");
                        Console.Write(fourth + " ");
                        first = third;
                        second = fourth;
                        i++;
                    }
                }
                else
                {
                    Console.Write(third + " ");
                    first = second;
                    second = third;
                }
            }
            Console.ReadKey();
        }        
    }
}
