public class Solution {
    public int MyAtoi(string s) {
        if (string.IsNullOrEmpty(s))
            return 0;

        int i = 0, n = s.Length;
        // 1) Skip leading spaces
        while (i < n && s[i] == ' ')
            i++;

        // 2) Read sign if present
        int sign = 1;
        if (i < n && (s[i] == '+' || s[i] == '-')) {
            if (s[i] == '-') sign = -1;
            i++;
        }

        // 3) Read digits and build the number
        long result = 0;  // use long to detect overflow
        while (i < n && char.IsDigit(s[i])) {
            int digit = s[i] - '0';
            result = result * 10 + digit;

            // 4) Clamp if out of 32‑bit range
            if (sign * result > int.MaxValue)
                return int.MaxValue;
            if (sign * result < int.MinValue)
                return int.MinValue;

            i++;
        }

        return (int)(sign * result);
            
            

      
    }
}