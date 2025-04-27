public class Solution {
    public int CountSubarrays(int[] nums) {
        int ans= 0;
         int i=0;
         int j = i+2;

         while(i<nums.Length && j<nums.Length){

            if((float)(nums[i]+nums[j]) == (float)(nums[i+1])/2){
                ans++;
              
            }
              i++;
                j++;

         }

         return ans;
    }
}