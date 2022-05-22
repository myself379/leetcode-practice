using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class AverageSalaryExcludeMinMax_1491
    {
        public AverageSalaryExcludeMinMax_1491()
        {
            int[] salary = new int[]
            {
                4000,
                1000,
                2000,
                3000,
                7000,
                10000,
            };

            Console.WriteLine(this.Solution(salary));
        }

        public double Solution(int[] salary)
        {
            List<int> salaryList = salary.ToList();
            var size = salaryList.Count;
            double maxSalary = salaryList.First();
            double minSalary = salaryList.First();
            int maxIndex = 0;
            int minIndex = 0;

            for(var i=0; i<size; i++)
            {
                var current = Convert.ToDouble(salaryList[i]);
                if(maxSalary < current)
                {
                    maxSalary = current;
                    maxIndex = i;
                }

                if(current < minSalary)
                {
                    minSalary = current;
                    minIndex = i;
                }
            }

            var filtered = salaryList.Where((source, index) => 
					{
					if(index == maxIndex)
						return false;

					if (index == minIndex)
						return false;

					return true;
					}).ToList();

            return filtered.Average();
        }
    }
}
