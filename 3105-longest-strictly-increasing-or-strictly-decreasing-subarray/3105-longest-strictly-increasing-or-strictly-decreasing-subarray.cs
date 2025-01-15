public class Solution {
    public int LongestMonotonicSubarray(int[] nums) {
     if (nums.Length == 0) return 0;

    int isINC = 1; // Length of current increasing subsequence
    int isDEC = 1; // Length of current decreasing subsequence
    int maxLength = 1; // Overall maximum length

    for (int i = 1; i < nums.Length; i++) {
        if (nums[i] > nums[i - 1]) {
            isINC++;
            isDEC = 1; // Reset decreasing sequence
        }
        else if(nums[i] == nums[i - 1]){
            isINC=isINC;
            isDEC =isDEC; // Reset decreasing sequence
        } else {
            isDEC++;
            isINC = 1; // Reset increasing sequence
        }

        // Update maximum length
        maxLength = Math.Max(maxLength, Math.Max(isINC, isDEC));
    }

    return maxLength;
    }
}