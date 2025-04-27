public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        
       
        bool answer = false;
     for(int i=0;i<nums.Length;i++){
        for(int j=i+1;j<nums.Length;j++){
            if(nums[i] == nums[j] && Math.Abs(i-j) <= k){
                    answer = true;
                    break;
            }
        
        }
        if(answer == true) break;
     }
         

       return answer;


    }
}