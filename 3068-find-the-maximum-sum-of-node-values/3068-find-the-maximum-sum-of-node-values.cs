using System;
using System.Collections.Generic;

public class Solution
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long sum = 0;
        var diffs = new List<long>();

        // Accumulate the base sum and compute the delta (x^k – x) for each element
        foreach (int x in nums)
        {
            sum += x;
            long y = x ^ k;
            diffs.Add(y - x);
        }

        // Sort deltas in descending order
        diffs.Sort();
        diffs.Reverse();

        // Greedily pair the top two deltas at a time
        for (int i = 0; i + 1 < diffs.Count; i += 2)
        {
            long pairSum = diffs[i] + diffs[i + 1];
            if (pairSum <= 0)
                break;
            sum += pairSum;
        }

        return sum;
    }
}
