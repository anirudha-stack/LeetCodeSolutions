public class Solution {
    public long CountSubarrays(int[] nums, int minK, int maxK) {
  long result = 0;
        int lastInvalid = -1;
        int lastMinPos   = -1;
        int lastMaxPos   = -1;

        for (int i = 0; i < nums.Length; i++) {
            // If out of [minK..maxK], mark as invalid and reset positions
            if (nums[i] < minK || nums[i] > maxK) {
                lastInvalid = i;
                lastMinPos  = -1;
                lastMaxPos  = -1;
            }

            // Update last positions of minK and maxK
            if (nums[i] == minK) lastMinPos = i;
            if (nums[i] == maxK) lastMaxPos = i;

            // Count all subarrays ending at i that include both minK and maxK
            int validStartCount = Math.Min(lastMinPos, lastMaxPos) - lastInvalid;
            if (validStartCount > 0) {
                result += validStartCount;
            }
        }

        return result;
    }
}