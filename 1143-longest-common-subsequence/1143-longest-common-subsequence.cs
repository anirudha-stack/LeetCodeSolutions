public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        
      int m = text1.Length, n = text2.Length;
        var dp = new int[m][];
        for (int i = 0; i < m; i++) {
            dp[i] = new int[n];
            Array.Fill(dp[i], -1);
        }
        return solver(0, 0, dp, text1, text2);
    }

    // Returns LCS-length of text1[ind1..] vs text2[ind2..]
    private int solver(int ind1, int ind2, int[][] dp, string text1, string text2) {
        if (ind1 == text1.Length || ind2 == text2.Length)
            return 0;

        if (dp[ind1][ind2] != -1)
            return dp[ind1][ind2];

        int skip1 = solver(ind1 + 1, ind2,     dp, text1, text2);
        int skip2 = solver(ind1,     ind2 + 1, dp, text1, text2);
        int take  = 0;
        if (text1[ind1] == text2[ind2]) {
            take = 1 + solver(ind1 + 1, ind2 + 1, dp, text1, text2);
        }

        return dp[ind1][ind2] = Math.Max(Math.Max(skip1, skip2), take);
    }
}


