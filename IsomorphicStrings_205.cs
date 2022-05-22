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
            var relation = new Dictionary<char, char>();

            for(var i=0; i<s1.Length; i++)
            {
                char s1Char = s1[i];
                char s2Char = s2[i];
                char c;

                if(relation.TryGetValue(s1Char, out c))
                {
                    if(c != s2Char)
                    {
                        IsPatternMatch = false;
                        break;
                    }
                }
                else if(relation.ContainsValue(s2Char))
                {
                    IsPatternMatch = false;
                    break;
                }
                else
                {
                    relation.Add(s1Char, s2Char);
                }
            }
            // To mark for Garbage Collect
            relation = null;

            return IsPatternMatch;
        }
    }
}
