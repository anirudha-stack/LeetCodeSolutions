public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
            List<int> result = new List<int>();
        if (s == null || words == null || words.Length == 0) return result;
        
        int wordLen = words[0].Length;
        int totalLen = wordLen * words.Length;
        if (s.Length < totalLen) return result;
        
        // Step 1: Build the frequency dictionary for the words.
        Dictionary<string, int> freq = new Dictionary<string, int>();
        foreach (string word in words) {
            if (freq.ContainsKey(word)) {
                freq[word]++;
            } else {
                freq[word] = 1;
            }
        }
        
        // Step 2: Slide the window over string s.
        for (int i = 0; i <= s.Length - totalLen; i++) {
            Dictionary<string, int> seen = new Dictionary<string, int>();
            int j = 0;
            // Check the substring divided into words of length wordLen.
            while (j < words.Length) {
                int start = i + j * wordLen;
                string sub = s.Substring(start, wordLen);
                
                // If the word is not in our target frequency map, break early.
                if (!freq.ContainsKey(sub)) {
                    break;
                }
                
                // Record how many times we've seen this word in the current substring.
                if (seen.ContainsKey(sub)) {
                    seen[sub]++;
                } else {
                    seen[sub] = 1;
                }
                
                // If seen count exceeds the expected frequency, this substring is invalid.
                if (seen[sub] > freq[sub]) {
                    break;
                }
                j++;
            }
            // If all words matched exactly, add the starting index to the result.
            if (j == words.Length) {
                result.Add(i);
            }
        }
        
        return result;
    }
}