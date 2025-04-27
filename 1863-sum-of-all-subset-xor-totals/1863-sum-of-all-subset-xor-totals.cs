public class Solution {
    public int SubsetXORSum(int[] nums) {

  return DFS(0, 0, nums);
    }

    private int DFS(int index, int currentXor, int[] nums) {
        if (index == nums.Length) {
            return currentXor; // base case: end of subset, return its XOR
        }

        // Include current element
        int include = DFS(index + 1, currentXor ^ nums[index], nums);
        // Exclude current element
        int exclude = DFS(index + 1, currentXor, nums);

        return include + exclude;
    }
}