public class Solution {
     public string GetPermutation(int n, int k) {
        // 1) Build factorial lookup: fact[i] = i!
        var fact = new int[n+1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++) 
            fact[i] = fact[i-1] * i;
        
        // 2) Build list of available digits
        var nums = new List<int>(n);
        for (int i = 1; i <= n; i++) 
            nums.Add(i);
        
        // 3) Convert k to 0-based index
        k--;
        
        // 4) Build the k-th permutation
        var sb = new StringBuilder();
        for (int i = n; i >= 1; i--) {
            // determine which digit to pick
            int idx = k / fact[i-1];
            sb.Append(nums[idx]);
            nums.RemoveAt(idx);
            
            // reduce k for the next position
            k %= fact[i-1];
        }
        
        return sb.ToString();
    }

   
}