public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int count = 0;
        int totalOnes = 0;
        for(int i=0;i<nums.Length;i++){
            if(nums[i] == 1){
                count++;
                if(count>totalOnes){
                    totalOnes = count;
                }
            }
            else{
                count = 0;
            }
        }
        return totalOnes;
    }
}