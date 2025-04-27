public class Solution {
    public int MinimumPairRemoval(int[] nums) {
        
        // Work in a mutable list of longs in case sums overflow int
        var list = new List<long>(nums.Select(x => (long)x));
        int ops = 0;

        // Helper to check non-decreasing
        bool IsNonDecreasing(List<long> a) {
            for (int i = 1; i < a.Count; i++)
                if (a[i] < a[i - 1]) return false;
            return true;
        }

        // Keep merging until the list is non-decreasing
        while (!IsNonDecreasing(list)) {
            // 1) Find the leftmost adjacent pair with minimum sum
            long minSum = long.MaxValue;
            int minIdx = 0;
            for (int i = 0; i + 1 < list.Count; i++) {
                long s = list[i] + list[i + 1];
                if (s < minSum) {
                    minSum = s;
                    minIdx = i;
                }
            }

            // 2) Replace list[minIdx], list[minIdx+1] by their sum
            list[minIdx] = minSum;
            list.RemoveAt(minIdx + 1);
            ops++;
        }

        return ops;

    }
}