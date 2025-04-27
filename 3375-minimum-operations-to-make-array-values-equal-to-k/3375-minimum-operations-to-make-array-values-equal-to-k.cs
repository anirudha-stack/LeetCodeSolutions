public class Solution {
    public int MinOperations(int[] nums, int k) {
      // 1) If any element is less than k, we can never raise it to k → impossible
        foreach (int num in nums) {
            if (num < k) 
                return -1;
        }
        
        // 2) Count each distinct value strictly greater than k
        HashSet<int> above = new HashSet<int>();
        foreach (int num in nums) {
            if (num > k) 
                above.Add(num);
        }
        
        // Each distinct value > k requires exactly one operation
        return above.Count;
    }
}