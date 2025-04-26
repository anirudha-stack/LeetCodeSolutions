public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        
        int max = 100000; // nums[i] <= 1000, so we can safely use 10^3 shifting

        // Step 1: Encode both values into one element
        for (int i = n; i < 2 * n; i++) {
            nums[i - n] += (nums[i] * max); // store y in x's spot
        }

        // Step 2: Decode back in reverse to place them correctly
        for (int i = n - 1; i >= 0; i--) {
            int y = nums[i] / max;
            int x = nums[i] % max;

            nums[2 * i] = x;
            nums[2 * i + 1] = y;
        }

        return nums;
    }
}