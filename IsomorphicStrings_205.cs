using System;
using System.Collections.Generic;

namespace leetcode
{
    public class IsomorphicStrings_205
    {
        public IsomorphicStrings_205()
        {
            Console.WriteLine(this.GetType() + "\n");
            try
            {
                // Console.WriteLine("foo, bar: " + this.IsomorphicStrings("foo", "bar"));
                // Console.WriteLine("egg, muu: " + this.IsomorphicStrings("egg", "muu"));
                Console.WriteLine("bbbaaaba, aaabbbba: " + this.IsomorphicStrings("bbbaaaba", "aaabbbba"));
                // Console.WriteLine(this.IsomorphicStrings());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        public bool IsomorphicStrings(string s1 = "", string s2 = "") 
        {
            if (s1.Length < 1 || s2.Length < 1)
                throw new Exception("Input length is less than 1");

            var IsPatternMatch = true;
            var lookupTableS1 = new List<string>();
            var lookupTableS2 = new List<string>();

            for(var i=0; i<s1.Length; i++)
            {
                string s1Char = s1[i].ToString();
                if(lookupTableS1.IndexOf(s1Char) == -1)
                {
                    lookupTableS1.Add(s1Char);
                }

				string s2Char = s2[i].ToString();
                if(lookupTableS2.IndexOf(s2Char) == -1)
                {
                    lookupTableS2.Add(s2Char);
                }

                if(lookupTableS1.IndexOf(s1Char) != lookupTableS2.IndexOf(s2Char))
                {
                    IsPatternMatch = false;
                    break;
                }
            }

            return IsPatternMatch;
        }
    }
}
