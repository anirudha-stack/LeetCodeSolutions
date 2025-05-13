public class Solution {
    public int LengthAfterTransformations(string s, int t) {
               const int MOD = 1_000_000_007;
        long[] freq = new long[26];

        // Initialize frequency array
        foreach (char c in s) {
            freq[c - 'a']++;
        }

        while (t-- > 0) {
            long[] nextFreq = new long[26];

            for (int i = 0; i < 26; i++) {
                if (i == 25) { // 'z'
                    nextFreq[0] = (nextFreq[0] + freq[i]) % MOD; // 'a'
                    nextFreq[1] = (nextFreq[1] + freq[i]) % MOD; // 'b'
                } else {
                    nextFreq[i + 1] = (nextFreq[i + 1] + freq[i]) % MOD;
                }
            }

            freq = nextFreq;
        }

        long total = 0;
        foreach (var f in freq) {
            total = (total + f) % MOD;
        }

        return (int)total;
    }
}