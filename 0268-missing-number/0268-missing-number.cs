public class Solution {
    public int MissingNumber(int[] nums) {

     Array.Sort(nums);
        int ans = 0;
        for(int i=0;i<nums.Length;i++){
            if(nums[i] != ans) {
                i = ans;
                break;
            }
            ans++;
        }

        return ans;
    }
}