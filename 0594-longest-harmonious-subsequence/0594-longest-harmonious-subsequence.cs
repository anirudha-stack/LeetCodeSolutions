public class Solution {
    public int FindLHS(int[] nums) {
         // 1. Build frequency map
        var freq = new Dictionary<int, int>();
        foreach (var x in nums) {
            if (freq.ContainsKey(x)) freq[x]++;
            else freq[x] = 1;
        }
        
        int maxLen = 0;
        // 2. For each key, check if key+1 exists
        foreach (var kv in freq) {
            int k = kv.Key;
            if (freq.TryGetValue(k + 1, out int cntNext)) {
                maxLen = Math.Max(maxLen, kv.Value + cntNext);
            }
        }
        return maxLen;
    }
}