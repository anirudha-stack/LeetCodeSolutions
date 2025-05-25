
public class Solution {
    public int LongestPalindrome(string[] words) {
        // 1. Count frequencies of each two-letter word
        var freq = new Dictionary<string,int>();
        foreach (var w in words) {
            if (freq.ContainsKey(w)) freq[w]++;
            else freq[w] = 1;
        }

        int length = 0;
        bool hasCenter = false;

        // 2. For each distinct word decide how many to use
        foreach (var kv in freq.ToList()) {
            string w = kv.Key;
            int count = kv.Value;
            // reversed string
            string rev = new string(new char[]{ w[1], w[0] });

            if (w == rev) {
                // a "palindromic" word like "gg" or "aa"
                // we can use pairs of them on both ends
                int pairs = count / 2;
                length += pairs * 4;      // each pair contributes 4 chars
                if (count % 2 == 1)       // one leftover can sit in the center
                    hasCenter = true;
            }
            else if (String.Compare(w, rev, StringComparison.Ordinal) < 0
                     && freq.TryGetValue(rev, out int revCount)) {
                // non-palindromic; match w with rev only once
                int pairs = Math.Min(count, revCount);
                length += pairs * 4;      // each matched pair of words adds 4 chars
            }
        }

        // 3. If any self-palindrome had an odd leftover, place exactly one in the center
        if (hasCenter)
            length += 2;

        return length;
    }
}
