public class Solution {
    public int FindPeakElement(int[] nums) {
        int left = 0, right = nums.Length - 1;

        while (left < right) {
            int mid = left + (right - left) / 2;

            if (nums[mid] > nums[mid + 1]) {
                // Peak lies on the left side (including mid)
                right = mid;
            } else {
                // Peak lies on the right side
                left = mid + 1;
            }
        }

        return left; // or right — both are equal when loop ends  
    }
}