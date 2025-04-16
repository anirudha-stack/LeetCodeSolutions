public class Solution {
    public void NextPermutation(int[] nums) {
        
        long total = 0;

        for(int i= nums.Length-1; i>0; i--){
        
            total += (nums[i] *  (int)Math.Pow(10,nums.Length-1-i));
        }
        
        bool found = false;
         for(int i= nums.Length-1; i>0; i--){
            if(nums[nums.Length-1] > nums[i-1]){
                int temp = nums[i];
                nums[i] = nums[i-1];
                nums[i-1] = temp;
                found = true;
                break;
            }
         }

         if(!found){
            int start = 0;
            int end = nums.Length -1 ;
                while(start<end){
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
                }
         }


    }
}