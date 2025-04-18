public class Solution {
    public int FindDuplicate(int[] nums) {
        HashSet <int> freq = new HashSet<int>();
        for(int i=0;i<nums.Length;i++){
            if(freq.Contains(nums[i])){
                return nums[i];
            }
            else{
                freq.Add(nums[i]);
            }
        }
        return 0;
    }
}