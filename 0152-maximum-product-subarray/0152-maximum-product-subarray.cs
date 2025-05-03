public class Solution {
    public int MaxProduct(int[] nums) {
       if(nums.Length == 0 || nums == null){
        return 0;
       }


       int ans = nums[0]; 

        int currMax = nums[0]; int currMin = nums[0];

        for(int i=1;i<nums.Length;i++){
            int n = nums[i];


            if(n < 0){
                int temp = currMax;
                currMax = currMin;
                currMin = temp;
            }

            currMax = Math.Max(n,currMax*n);
            
            currMin = Math.Min(n,currMin*n);

            ans = Math.Max(ans,currMax);
        }

        return ans;
    }
}