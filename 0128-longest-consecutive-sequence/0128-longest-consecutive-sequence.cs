public class Solution {
    public int LongestConsecutive(int[] nums) {
        
        Array.Sort(nums);



        int maxLen = 0;
        int currentMax = 0;

        for(int i=1;i<nums.Length;i++){
            //1,2,3,4,100,200

            if(nums[i] == nums[i-1]){
                    continue;
            }

            if(nums[i] - nums[i-1] == 1){
                currentMax++; // 3

                if(currentMax > maxLen){
                    maxLen = currentMax; // 3
                }
            }
            else{
                currentMax = 0;
            }

        }

        return maxLen+1;

    }
}