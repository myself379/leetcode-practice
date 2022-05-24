using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace leetcode
{
    public class StringInterpolation
    {
        public StringInterpolation()
        {
            string template = "Hello, my name is {firstName} and I like {hobby}.";
            var values = new Dictionary<string, string>()
            {
                {"firstName", "Jim"},
                    {"hobby", "basketball"},
            };
            string prefix = "{";
            string suffix = "}";

            Console.WriteLine("Happy path test:");
            Console.WriteLine(this.Interpolate(template, values, prefix, suffix));
            Console.WriteLine("\n");

            template = "Hello, my name is {firstName] and I like {hobby].";
            values = new Dictionary<string, string>()
            {
                {"firstName", "Kim"}
            };
            prefix = "{";
            suffix = "]";

            Console.WriteLine("Test with different pair of suffix:");
            Console.WriteLine(this.Interpolate(template, values, prefix, suffix));
            Console.WriteLine("\n");

            template = "This is {word1}, the sentence is {sentance2}. Today is {day3}";
            values = new Dictionary<string, string>()
            {
                {"word1", "Lorem Ipsum"},
                    {"sentance2", "This is a very long very long text"},
                    {"day3", "Thursday"}
            };
            prefix = "{";
            suffix = "}";

            Console.WriteLine("Test with 3 placeholder:");
            Console.WriteLine(this.Interpolate(template, values, prefix, suffix));
            Console.WriteLine("\n");
        }
        
        public string Interpolate(
                string template, 
                Dictionary<string, string> lookupTable,
                string prefix,
                string suffix)
        {
            string output = template;

            var matches = Regex.Matches(template, prefix+".*?"+suffix);

            for(int i=0; i<matches.Count; i++)
            {
                string s = matches[i].Value;
                string findWord = s.Substring(1,s.Length-2);
                string word;
                if(lookupTable.TryGetValue(s.Substring(1, s.Length-2), out word))
                {
                    output = output.Replace(s, word);
                }
                else
                {
                    output = output.Replace(s, $"#{findWord}NotFound#");
                }
            }


            return output;
        }
    }
}
