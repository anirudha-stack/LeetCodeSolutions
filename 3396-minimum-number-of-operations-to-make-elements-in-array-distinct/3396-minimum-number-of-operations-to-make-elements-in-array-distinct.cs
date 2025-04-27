public class Solution {
    public int MinimumOperations(int[] nums) {
        

        if(nums.Length == 0) return 1;
        int answer = 0;
        int start = 0;
        while(!isDistinct(start,nums)){
            start = start+3;
            answer++;
        }

        return answer;


    }

    public bool isDistinct(int start,int[] nums){

        HashSet<int> map = new HashSet<int>();

        for(int i=start;i<nums.Length;i++){
            if(map.Contains(nums[i]))
            return false;

            else{
                map.Add(nums[i]);
            }
        }

        return true;

    }
}