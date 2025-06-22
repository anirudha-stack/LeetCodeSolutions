public class Solution {
    public string[] DivideString(string s, int k, char fill) {
          int n = s.Length;
        int groupCount = (n + k - 1) / k;      // ceiling of n/k
        var result = new string[groupCount];

        for (int i = 0; i < groupCount; i++) {
            int start = i * k;
            int len   = Math.Min(k, n - start);
            // take the substring (len ≤ k)
            string part = s.Substring(start, len);
            // pad with fill if it’s shorter than k
            if (len < k)
                part = part.PadRight(k, fill);
            result[i] = part;
        }

        return result;
    }
}