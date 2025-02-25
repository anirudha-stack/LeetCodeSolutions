public class Solution {
    public int[] TwoSum(int[] nums, int target) {
      
        List<int> currentNums = new List<int>(nums);
        
       
        for(int i=0;i<nums.Length;i++){
            
            int complement = target-nums[i];
            if(currentNums.Contains(complement) && currentNums.IndexOf(complement) != i){
                return new int[] { i,currentNums.IndexOf(complement) };
            }
        }
        
        return new int[] { -1, -1 };
               
        
    }
}