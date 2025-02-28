public class Solution {
    public int CountPairs(int[] deliciousness) {
        const int MOD = 1000000007;
        Dictionary<int, int> freq = new Dictionary<int, int>();
        int count = 0;

        foreach (int num in deliciousness) {
            // Check for all possible power of 2 sums (from 2^0 to 2^21)
            for (int power = 1; power <= (1 << 21); power <<= 1) {
                int complement = power - num;
                if (freq.ContainsKey(complement)) {
                    count = (count + freq[complement]) % MOD;
                }
            }

            // Store this number in the dictionary
            if (!freq.ContainsKey(num)) {
                freq[num] = 0;
            }
            freq[num]++;
        }

        return count;

    }
}