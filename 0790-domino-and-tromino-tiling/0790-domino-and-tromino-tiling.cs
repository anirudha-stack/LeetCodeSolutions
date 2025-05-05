public class Solution {
          private const int MOD = 1_000_000_007;
    private long[] dp;

    public int NumTilings(int n) {
        // 1. Prepare memo array of length n+1, filled with -1
        dp = new long[n + 1];
        Array.Fill(dp, -1L);

        // 2. Kick off recursion
        long ans = solver(n);
        return (int)ans;
    }

    private long solver(int k) {
        // Base cases
        if (k == 0) return 1;
        if (k == 1) return 1;
        if (k == 2) return 2;

        // Return cached value if present
        if (dp[k] != -1) 
            return dp[k];

        // Recurrence: f(k) = 2·f(k-1) + f(k-3)
        long ways = (2 * solver(k - 1) % MOD + solver(k - 3)) % MOD;
        return dp[k] = ways;
    }
}