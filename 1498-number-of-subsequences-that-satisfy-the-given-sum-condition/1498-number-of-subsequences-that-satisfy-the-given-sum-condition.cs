public class Solution {
        private const int MOD = 1_000_000_007;

    public int NumSubseq(int[] nums, int target) {
           int n = nums.Length;
        Array.Sort(nums);
        // precompute powers of two up to n
        int[] pow2 = new int[n];
        pow2[0] = 1;
        for (int i = 1; i < n; i++) {
            pow2[i] = (pow2[i - 1] * 2) % MOD;
        }

        long ans = 0;
        int l = 0, r = n - 1;
        while (l <= r) {
            if (nums[l] + nums[r] <= target) {
                ans = (ans + pow2[r - l]) % MOD;
                l++;
            } else {
                r--;
            }
        }
        return (int)ans;
    }
}