public class Solution {
    public int LongestSubsequence(string s, int k) {
       int countZeros = 0;
        int countOnes = 0;
        int value = 0;
        int power = 1;

        // Count zeros as they can always be included
        foreach (char c in s) {
            if (c == '0') countZeros++;
        }

        // Traverse from right (least significant bit) and try adding 1s
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '1') {
                if (value + power <= k) {
                    value += power;
                    countOnes++;
                } else {
                    break; // Stop if adding another '1' exceeds k
                }
            }
            if (power <= k / 2) { // Avoid integer overflow
                power *= 2;
            }else {
                break; // Prevent counting an extra '1' due to overflow
            }
        }

        return countZeros + countOnes;

    }
}