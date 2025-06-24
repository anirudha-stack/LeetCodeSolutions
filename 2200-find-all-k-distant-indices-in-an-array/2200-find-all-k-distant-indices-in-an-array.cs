public class Solution {
    public IList<int> FindKDistantIndices(int[] nums, int key, int k) {
        int n = nums.Length;
        var valid = new HashSet<int>();
        
        for (int j = 0; j < n; j++) {
            if (nums[j] == key) {
                int start = Math.Max(0, j - k);
                int end   = Math.Min(n - 1, j + k);
                for (int i = start; i <= end; i++)
                    valid.Add(i);
            }
        }
        
        var result = valid.ToList();
        result.Sort();
        return result;
    }
}
