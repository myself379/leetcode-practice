using System;

namespace leetcode
{
    public class CountOddNumbersInAnInterval_1523
    {
        public CountOddNumbersInAnInterval_1523()
        {
            Console.WriteLine(GetType().Name + "\n");
            // Hint 1: If the range (high - low + 1) is even, the number of even and odd numbers in this range will be the same
            // Hint 2: If the range (high - low + 1) is odd, the solution will depends on the parity of high and low
            
            Console.WriteLine($"Should be 3: " + this.CountOdds(3, 7));
            Console.WriteLine($"Should be 1: " + this.CountOdds(8, 10));
        }

        public int CountOdds(int low, int high) 
        {
            if (low > high)
            {
                throw new Exception("high must be bigger than low");
            }

            var noOfSeq = (high - low) + 1;

            int noOfOddNumber = 0;

            if(noOfSeq%2 == 0)
            {
                noOfOddNumber = noOfSeq/2;
            }
            else
            {
                noOfOddNumber = ((noOfSeq+1)/2);

                if(low%2 == 0 && high%2 == 0)
                {
                    noOfOddNumber -= 1;
                }
            }

            return noOfOddNumber;
        }
    }
}
