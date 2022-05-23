using System;

namespace leetcode
{
    public class BinarySearch_704
    {
        public BinarySearch_704()
        {
            Console.WriteLine(GetType().Name + "\n");

            Console.WriteLine(this.Solution(new int[]{-1,0,3,5,9,12}, 9));
            Console.WriteLine(this.Solution2(new int[]{-1,0,3,5,9,12}, 9));
        }

        public int Solution(int[] nums, int target)
        {
            int resultIndex = -1;

            for(var i=0; i < nums.Length; i++)
            {
                if(nums[i] > target)
                    break;

                if(nums[i] == target)
                    resultIndex = i;
            }

            return resultIndex;
        }

        public int Solution2(int[] nums, int target)
        {
            int leftPointer = 0;
            int rightPointer = nums.Length - 1;

            while(leftPointer <= rightPointer)
            {
                int pivot = leftPointer + (rightPointer - leftPointer) /2;
                
                if(nums[pivot] == target)
                    return pivot;

                if(target < nums[pivot])
                    rightPointer = pivot -1;
                else
                    leftPointer = pivot + 1;
            }

            return -1;
        }
    }
}
