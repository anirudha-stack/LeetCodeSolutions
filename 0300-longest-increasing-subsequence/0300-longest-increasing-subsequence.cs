public class Solution {

    public int LengthOfLIS(int[] nums) {
        
        return solver(-1,0,nums);
    

    }

    public int solver (int index,int len, int[] nums){
        // If we've walked past the end, no more picks → length 0
        if (len == nums.Length) 
            return 0;

        // 1) Option: skip nums[len]
        int skip = solver(index, len + 1, nums);

        // 2) Option: take nums[len], if valid
        int take = 0;
        if (index < 0 || nums[len] > nums[index]) {
            // we add 1 for this pick, and recurse with new prev = len
            take = 1 + solver(len, len + 1, nums);
        }

        // Return the better of taking vs skipping
        return Math.Max(skip, take);
    }

}