public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length == 0) 
            return 0;

        int writeIdx = 1;                // next position to write a unique number
        for (int readIdx = 1; readIdx < nums.Length; readIdx++) {
            if (nums[readIdx] != nums[readIdx - 1]) {
                nums[writeIdx] = nums[readIdx];
                writeIdx++;
            }
        }

        // writeIdx is now the length of the unique-prefix
        return writeIdx;

    }
}