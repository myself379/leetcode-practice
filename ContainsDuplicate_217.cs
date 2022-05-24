using System;
using System.Collections.Generic;

namespace leetcode
{
    public class ContainsDuplicate_217
    {
        public ContainsDuplicate_217()
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine("Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.");
            Console.WriteLine("\n");

            Console.WriteLine("[1,2,3,1]: "+this.ContainsDuplicate(new int[]{1,2,3,1}));
            Console.WriteLine("[1,2,3,4]: "+this.ContainsDuplicate(new int[]{1,2,3,4}));
            Console.WriteLine("[1,1,1,3,3,4,3,2,4,2]: " + this.ContainsDuplicate(new int[]{1,1,1,3,3,4,3,2,4,2}));
            Console.WriteLine("\n");
        }

        public bool ContainsDuplicate(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            for(var i=0; i<nums.Length; i++)
            {
                int num;
                if(dic.TryGetValue(nums[i], out num))
                {
                    return true;
                }
                else
                {
                    dic.Add(nums[i], nums[i]);
                }
            }

            return false;        
        }
    }
}
