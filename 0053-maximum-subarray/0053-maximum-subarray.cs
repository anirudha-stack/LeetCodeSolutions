public class Solution {
    public int MaxSubArray(int[] nums) {
        
     if (nums == null || nums.Length == 0) return 0;

    int maxSum = nums[0]; // Initialize to the first element
    int currentSum = nums[0];
    int startIndex = 0, endIndex = 0, tempStart = 0;

    for (int i = 1; i < nums.Length; i++) {
        if (currentSum + nums[i] < nums[i]) {
            currentSum = nums[i];
            tempStart = i; // Update temporary start index
        } else {
            currentSum += nums[i];
        }

        if (currentSum > maxSum) {
            maxSum = currentSum;
            startIndex = tempStart; // Update start index to tempStart
            endIndex = i;           // Update end index to current position
        }
    }

   // Console.WriteLine("Start index is: " + startIndex + " and End index is: " + endIndex);
    return maxSum;
    }
}