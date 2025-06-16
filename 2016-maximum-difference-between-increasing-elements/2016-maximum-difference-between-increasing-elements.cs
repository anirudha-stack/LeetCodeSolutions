public class Solution {
    public int MaximumDifference(int[] nums) {
        
        int answer = Int32.MinValue;

        for(int i=0;i<nums.Length;i++){
            for(int j=i+1;j<nums.Length;j++){
                answer = Math.Max((nums[j]-nums[i]),answer);
            }
        }

        return answer;

    }
}