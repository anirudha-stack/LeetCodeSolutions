public class Solution {
    public long CountSubarrays(int[] nums, int k) {
         int n = nums.Length;
        int maxVal = nums.Max();
        long result = 0;
        long currentMax = 0;
        int maxCount = 0;
        int left = 0;


         for (int right = 0; right < n; right++) {
            if (nums[right] == maxVal) {
                maxCount++;
            }

            while (maxCount >= k) {
                result += (n - right);  // all subarrays ending at right and beyond
                if (nums[left] == maxVal) {
                    maxCount--;
                }
                left++;
            }
        }


        return result;
    }
}