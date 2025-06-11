using System;

public class Solution 
{
    public int MaxDifference(string s, int k) 
    {
        int n = s.Length;
        int ans = int.MinValue;

        // Step 1: Try all pairs of digits a != b
        for (int a = 0; a <= 4; ++a) 
        {
            for (int b = 0; b <= 4; ++b) 
            {
                if (a == b) continue;

                // Step 2: Prefix sums of counts of a and b
                int[] s1 = new int[n + 1];
                int[] s2 = new int[n + 1];
                for (int i = 1; i <= n; ++i) 
                {
                    s1[i] = s1[i - 1] + ((s[i - 1] - '0') == a ? 1 : 0);
                    s2[i] = s2[i - 1] + ((s[i - 1] - '0') == b ? 1 : 0);
                }

                // Step 3: g[pa,pb] stores max (s2[j] - s1[j]) for each parity
                int[,] g = new int[2, 2];
                for (int pa = 0; pa < 2; ++pa)
                    for (int pb = 0; pb < 2; ++pb)
                        g[pa, pb] = int.MinValue;

                int j = 0;

                // Step 4: Scan from position k
                for (int i = k; i <= n; ++i) 
                {
                    while (i - j >= k && s1[i] > s1[j] && s2[i] > s2[j]) 
                    {
                        int pa = s1[j] % 2;
                        int pb = s2[j] % 2;
                        g[pa, pb] = Math.Max(g[pa, pb], s2[j] - s1[j]);
                        j++;
                    }

                    int curPa = s1[i] % 2;
                    int curPb = s2[i] % 2;
                    int best = g[1 - curPa, curPb];
                    if (best != int.MinValue) 
                    {
                        ans = Math.Max(ans, (s1[i] - s2[i]) + best);
                    }
                }
            }
        }

        return ans == int.MinValue ? -1 : ans;
    }
}
