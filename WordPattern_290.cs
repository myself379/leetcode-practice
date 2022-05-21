using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class WordPattern_290
    {
        public WordPattern_290()
        {
            Console.WriteLine(this.WordPattern("abba", "dog cat cat dog"));
        }

        public bool WordPattern(string pattern, string s) 
        {
            if (pattern.Length < 1)
                throw new Exception("Pattern length is less than 1");

            if (pattern.Length > 300)
                throw new Exception("Pattern length is more than 300");

            var IsPatternMatch = true;

            var patternString = generateTargetCounter(pattern.Select(c => c.ToString()).ToList());
            var targetString = generateTargetCounter(s.Split(' ').ToList());

            if (targetString.Count != patternString.Count)
            {
                return false;
            }

            foreach(var (value, i) in targetString.Select((value, i) => (value, i)))
            {
                if (value != patternString[i])
                {
                    IsPatternMatch = false;
                }
            }

            return IsPatternMatch;
        }

        public List<int> generateTargetCounter(List<string> s)
        {
            var pattern = new List<string>();
            var counter = new List<int>();

            foreach(var word in s)
            {
                if (pattern.Count > 0)
                {
                    if(pattern.Contains(word))
                    {
                        counter.Add(pattern.IndexOf(word));
                    }
                    else
                    {
                        pattern.Add(word);
                        counter.Add(pattern.IndexOf(word));
                    }
                } 
                else
                {
                    pattern.Add(word);
                    counter.Add(pattern.IndexOf(word));
                }
            }

            return counter;
        }
    }
}
