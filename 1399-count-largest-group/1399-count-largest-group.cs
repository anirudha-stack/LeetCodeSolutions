public class Solution {
    public int CountLargestGroup(int n) {
       // 1) Build frequency map: sum-of-digits → count
        var freq = new Dictionary<int,int>();
        for (int i = 1; i <= n; i++) {
            int sum = 0, x = i;
            while (x > 0) {
                sum += x % 10;
                x /= 10;
            }
            if (freq.ContainsKey(sum)) freq[sum]++;
            else                     freq[sum] = 1;
        }

        // 2) Find the largest group size
        int maxSize = 0;
        foreach (var kv in freq) {
            if (kv.Value > maxSize) maxSize = kv.Value;
        }

        // 3) Count how many groups have that size
        int answer = 0;
        foreach (var kv in freq) {
            if (kv.Value == maxSize) answer++;
        }

        return answer;

    }
}