public class Solution {
    public int CountPairs(int[] nums, int k) {
      int n = nums.Length, ans = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (nums[i] == nums[j] && (i * j) % k == 0)
                    ans++;
            }
        }
        return ans;


    }
}