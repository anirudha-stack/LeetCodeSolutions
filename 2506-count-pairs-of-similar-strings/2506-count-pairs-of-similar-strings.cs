public class Solution {
    public int SimilarPairs(string[] words) {
    Dictionary<int, int> maskCount = new Dictionary<int, int>();
        
        foreach (var word in words) {
            int mask = 0;
            foreach (char c in word) {
                // Set the bit corresponding to the character
                mask |= (1 << (c - 'a'));
            }
            if (maskCount.ContainsKey(mask))
                maskCount[mask]++;
            else
                maskCount[mask] = 1;
        }
        
        int result = 0;
        // For each bitmask frequency, count the number of pairs
        foreach (var count in maskCount.Values) {
            result += count * (count - 1) / 2;
        }
        
        return result;



    }
}