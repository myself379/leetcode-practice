using System;
using System.Linq;

namespace leetcode
{
    // This problem is known as Kadanes algorithm
    public class MaximumSubarray_53
    {
        public MaximumSubarray_53()
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine("\n");

            Console.WriteLine(MaxSubArray_Correct(new int[] {-2,1,-3,4,-1,2,1,-5,4}));
            Console.WriteLine(MaxSubArray_Correct(new int[] {1}));
            Console.WriteLine(MaxSubArray_Correct(new int[] {5,4,-1,7,8}));
            Console.WriteLine(MaxSubArray_Correct(new int[] {0,0,0,0,0}));
            Console.WriteLine(MaxSubArray_Correct(new int[] {-2,1}));

            Console.WriteLine("\n");
        }

        // My first attempt to solve the problem
        public int MaxSubArray(int[] nums)
        {
            int maxSubarray = new();

            if(nums.Length == 1)
            {
                return nums.First();
            }

            int[] localMaximum = new int[nums.Length];

            foreach(var (i, value) in nums.Select((value, i) => (i, value) ))
            {
                for(var j=0; j<=i; j++)
                {
                    localMaximum[i] += nums[j];
                }
            }

            (int Index, int Value) Max = new ();
            (int Index, int Value) Min = new ();
            foreach(var (i, value) in localMaximum.Select((value, i) => (i, value)))
            {
                Console.WriteLine($"Index [{i}]: local_maximum {value}");
                
                if(value > Max.Value)
                {
                    Max.Value = value;
                    Max.Index = i;
                }

                if(value < Min.Value)
                {
                    Min.Value = value;
                    Min.Index = i;
                }
            }

            Console.WriteLine($"Min: {Min.Index} {Min.Value}");
            Console.WriteLine($"Max: {Max.Index} {Max.Value}");

            int startIndex;
            if(Min.Value < 0)
            {
                startIndex = Min.Index + 1;
            }
            else
            {
                startIndex = Min.Index;
            }

            for(var i=startIndex; i <= Max.Index; i++)
            {
                maxSubarray += nums[i];
            }

            return maxSubarray;
        }

        // It may look simple, but its actually a simplied version
        // For best vizualization, try the brute-force approach
        public int MaxSubArray_Correct(int[] nums)
        {
            if(nums.Length == 1)
            {
                return nums.First();
            }

            int localMax = 0;
            int globalMax = Int32.MinValue;

            Func<int, int, int> max = delegate(int Number1, int Number2)
            {
                if (Number1 >= Number2)
                {
                    return Number1;
                }
                else
                {
                    return Number2;
                }
            };

            for(int i = 0; i < nums.Length; i++)
            {
                localMax = max(nums[i], nums[i] + localMax);
                if (localMax > globalMax)
                {
                    globalMax = localMax;
                }
            }

            return globalMax;
        }
    }
}
