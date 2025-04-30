public class Solution {
    public int FindNumbers(int[] nums) {
        int even = 0;
        for(int i=0;i<nums.Length;i++){
            int digits = 0;
            while(nums[i]>0){
                nums[i] = nums[i]/10;
                digits++;
            }

            if(digits%2==0) even++;
        }

        return even;
    }
}