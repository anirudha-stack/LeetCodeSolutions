public class Solution {
    public int SearchInsert(int[] nums, int target) {
        
        int left  = 0;
        int right = nums.Length;         // note: right = n, not n-1

        while (left < right) {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target) {
                left = mid + 1;           // go right of mid
            } else {
                right = mid;              // could be the answer (or to the left)
            }
        }

        // left == right is the insertion position
        return left;
    }
}