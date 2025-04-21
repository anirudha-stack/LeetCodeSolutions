public class Solution {
    public string LongestPalindrome(string s) {
       if (string.IsNullOrEmpty(s)) 
            return "";

        // 1) Preprocess
        var T = new StringBuilder("^");
        foreach (char c in s) {
            T.Append('#').Append(c);
        }
        T.Append("#$");
        var t = T.ToString();

        int n = t.Length;
        int[] P = new int[n];
        int C = 0, R = 0;  // center and right boundary

        // 2) Manacher's main loop
        for (int i = 1; i < n - 1; i++) {
            int mirror = 2 * C - i;

            // if within the current right boundary, use the mirror or distance to R
            if (i < R) {
                P[i] = Math.Min(R - i, P[mirror]);
            }

            // attempt to expand around i
            while (t[i + 1 + P[i]] == t[i - 1 - P[i]]) {
                P[i]++;
            }

            // update center and boundary if expanded past R
            if (i + P[i] > R) {
                C = i;
                R = i + P[i];
            }
        }

        // 3) Find the maximum palindrome length in P
        int maxLen = 0, centerIndex = 0;
        for (int i = 1; i < n - 1; i++) {
            if (P[i] > maxLen) {
                maxLen = P[i];
                centerIndex = i;
            }
        }

        // 4) Extract the substring from the original string
        int start = (centerIndex - maxLen) / 2;  // undo the preprocessing
        return s.Substring(start, maxLen);
    }
}