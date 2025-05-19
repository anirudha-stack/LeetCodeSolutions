public class Solution {
    public string TriangleType(int[] nums) {
        if(nums.Length != 3) return "none";

        
        Array.Sort(nums);

        if( nums[0] + nums[1] <= nums[2]) return "none";

         if(nums[0] != nums[1] && nums[1] != nums[2] && nums[2] != nums[0]) return "scalene";
        else if(nums[0] == nums[1] && nums[1] == nums[2]) return "equilateral";

        else if(nums[0] == nums[1] || nums[1] == nums[2] || nums[2]== nums[0]) return "isosceles";
        else return "none";

    }
}