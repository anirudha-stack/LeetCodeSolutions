public class Solution {
    public int[] MaxSubsequence(int[] nums, int k) {
        // Pair each number with its original index
        var paired = new List<(int val, int idx)>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
            paired.Add((nums[i], i));

        // Take the k largest by value
        paired.Sort((a, b) => b.val.CompareTo(a.val));
        var topK = paired.GetRange(0, k);

        // Restore original order
        topK.Sort((a, b) => a.idx.CompareTo(b.idx));

        // Extract values
        var result = new int[k];
        for (int i = 0; i < k; i++)
            result[i] = topK[i].val;

        return result;
    }
}
