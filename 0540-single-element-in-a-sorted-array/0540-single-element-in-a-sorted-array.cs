public class Solution {
    public int SingleNonDuplicate(int[] nums) {
         int left =0;int right= nums.Length-2;


        while(left<=right){
            int mid = (right+left)/2;
            if(nums[mid] == nums[mid^1]){
                left = mid+1;
            }
            else{
                right = mid-1;
            }

        }

        return nums[left];
    }
}