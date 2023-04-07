using System;
using System.Collections.Generic;

class Program
{
    static bool CanPartitionKSubsets(int[] nums, int k)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }

        if (sum % k != 0)
        {
            return false;
        }

        int target = sum / k;
        int[] subsetSum = new int[k];
        return Backtrack(nums, 0, subsetSum, target);
    }

    static bool Backtrack(int[] nums, int index, int[] subsetSum, int target)
    {
        if (index == nums.Length)
        {
            foreach (var sum in subsetSum)
            {
                if (sum != target)
                {
                    return false;
                }
            }
            return true;
        }

        for (int i = 0; i < subsetSum.Length; i++)
        {
            if (subsetSum[i] + nums[index] <= target)
            {
                subsetSum[i] += nums[index];
                if (Backtrack(nums, index + 1, subsetSum, target))
                {
                    return true;
                }
                subsetSum[i] -= nums[index];
            }
        }

        return false;
    }

    static void Main(string[] args)
    {
        int[] nums = { 5,2,6,7,2,1,3 };
        int k = 2;
        bool result = CanPartitionKSubsets(nums, k);
        Console.WriteLine($"Dizi toplamın {k} alt kümesine bölünebilir mi? {result}");
    }
}
