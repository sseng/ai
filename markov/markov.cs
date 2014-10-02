using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Markov
{
    public class markov
    {
        public string[] sentence;
        Dictionary<string, Dictionary<string, HashSet<string>>> words;
        Random rand = new Random();

        public markov()
        {
             words = new Dictionary<string, Dictionary<string, HashSet<string>>>();
             //sentence = new ArrayList();
        }

        public void add(string word1, string word2, string word3)
            {   
                if (!words.ContainsKey(word1)){
                    words.Add(word1, new Dictionary<string,HashSet<string>>());
                }
                if (!words[word1].ContainsKey(word2)){
                    words[word1].Add(word2, new HashSet<string>());
                }
                words[word1][word2].Add(word3);
            }

        public string lookup(string w1, string w2)
        { 
            if (words.ContainsKey(w1)){
                if (words[w1].ContainsKey(w2)){
                    HashSet<string> w3 = words[w1][w2];
                    return w3.ElementAt(rand.Next(w3.Count));
                }
            }
            //return words.Keys.ElementAt(rand.Next(words.Count));
            return "";
            //throw new System.Exception();
        }
        
        public void storeWords(string source)
        {
            //string[] seperator = new string[] { " " };
            sentence = source.Split("\r\n ".ToCharArray() , StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sentence.Length - 2; i++)
            {
                this.add(sentence[i], sentence[i + 1], sentence[i + 2]);                
            }            
        }
    }
}
