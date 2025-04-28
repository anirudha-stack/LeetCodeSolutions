public class Solution {
    public long CountSubarrays(int[] nums, long k) {
        int n = nums.Length;
        long answer = 0;
        long windowSum = 0;
        int left = 0;

        // Expand right end of the window
        for (int right = 0; right < n; right++) {
            windowSum += nums[right];

            // Shrink from the left while score >= k
            // Score = (sum of window) * (length of window)
            while (left <= right && windowSum * (right - left + 1) >= k) {
                windowSum -= nums[left];
                left++;
            }

            // Now all subarrays ending at 'right' and starting anywhere
            // in [left..right] have score < k. There are (right-left+1) of them.
            answer += (right - left + 1);
        }

        return answer;
    }

  
}