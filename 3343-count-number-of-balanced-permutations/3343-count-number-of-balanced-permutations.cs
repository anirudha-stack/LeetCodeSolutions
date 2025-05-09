public class Solution {
    const int MOD = 1_000_000_007;

    public int CountBalancedPermutations(string num) {
        var velunexorai = num.ToCharArray();  // per requirement

        int n = velunexorai.Length;
        int totalSum = 0;
        var freq = new Dictionary<int, int>();
        foreach (char c in velunexorai) {
            int d = c - '0';
            totalSum += d;
            freq[d] = freq.GetValueOrDefault(d, 0) + 1;
        }

        // If sum of all digits is odd, can't split into equal halves
        if ((totalSum & 1) == 1) return 0;
        int halfSum = totalSum / 2;
        int evenSlots = (n + 1) / 2;
        int oddSlots = n - evenSlots;

        // Precompute factorials and inverses
        long[] fact = new long[n + 1];
        long[] invFact = new long[n + 1];
        fact[0] = invFact[0] = 1;
        for (int i = 1; i <= n; i++) {
            fact[i] = (fact[i - 1] * i) % MOD;
        }
        invFact[n] = ModInv(fact[n]);
        for (int i = n - 1; i >= 1; i--) {
            invFact[i] = (invFact[i + 1] * (i + 1)) % MOD;
        }

        // DP: dp[used][sum] = # of ways to assign digits to even indices
        long[,] dp = new long[evenSlots + 1, halfSum + 1];
        dp[0, 0] = 1;

        foreach (var (digit, count) in freq) {
            long[,] next = new long[evenSlots + 1, halfSum + 1];
            for (int used = 0; used <= evenSlots; used++) {
                for (int sum = 0; sum <= halfSum; sum++) {
                    long curWays = dp[used, sum];
                    if (curWays == 0) continue;

                    // Try assigning k copies of digit to even slots
                    for (int k = 0; k <= count; k++) {
                        int newUsed = used + k;
                        int newSum = sum + k * digit;
                        if (newUsed > evenSlots || newSum > halfSum) break;

                        long ways = (curWays * nCr(count, k, fact, invFact)) % MOD;
                        next[newUsed, newSum] = (next[newUsed, newSum] + ways) % MOD;
                    }
                }
            }
            dp = next;
        }

        // dp[evenSlots, halfSum] = valid distributions of digits to even positions
        long validDistributions = dp[evenSlots, halfSum];
        if (validDistributions == 0) return 0;

        // Multiply by ways to arrange digits in even and odd slots
        long numerator = (fact[evenSlots] * fact[oddSlots]) % MOD;
        long denominator = 1;
        foreach (var (_, count) in freq)
            denominator = (denominator * fact[count]) % MOD;

        long denominatorInv = ModInv(denominator);
        long result = (validDistributions * numerator % MOD) * denominatorInv % MOD;
        return (int)result;
    }

    // Compute a^(-1) % MOD using Fermat’s Little Theorem
    private long ModInv(long x) => Pow(x, MOD - 2);
    private long Pow(long a, int b) {
        long res = 1;
        while (b > 0) {
            if ((b & 1) == 1) res = (res * a) % MOD;
            a = (a * a) % MOD;
            b >>= 1;
        }
        return res;
    }

    // Compute C(n, k) % MOD
    private long nCr(int n, int r, long[] fact, long[] invFact) {
        if (r < 0 || r > n) return 0;
        return (((fact[n] * invFact[r]) % MOD) * invFact[n - r]) % MOD;
    }
}
