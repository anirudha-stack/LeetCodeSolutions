public class Solution {
    const int MOD = 1_000_000_007;
    public int LengthAfterTransformations(string s, int t, IList<int> nums) {
        int n = 26;
        long[][] T = new long[n][];
        for (int i = 0; i < n; i++) {
            T[i] = new long[n];
        }

        // Build transformation matrix
        for (int i = 0; i < n; i++) {
            for (int k = 1; k <= nums[i]; k++) {
                int to = (i + k) % 26;
                T[i][to] = (T[i][to] + 1) % MOD;
            }
        }

        // Convert input string to frequency vector
        long[] F = new long[n];
        foreach (char ch in s) {
            F[ch - 'a']++;
        }

        // Exponentiate the transformation matrix
        var Tt = MatrixPower(T, t);

        // Multiply F × T^t
        long[] result = MultiplyVectorMatrix(F, Tt);

        // Sum of all characters
        long total = 0;
        foreach (long val in result) {
            total = (total + val) % MOD;
        }

        return (int)total;
    }

    private long[][] MatrixPower(long[][] A, int exp) {
        int n = A.Length;
        long[][] result = IdentityMatrix(n);

        while (exp > 0) {
            if ((exp & 1) == 1)
                result = MultiplyMatrix(result, A);
            A = MultiplyMatrix(A, A);
            exp >>= 1;
        }

        return result;
    }

    private long[][] MultiplyMatrix(long[][] A, long[][] B) {
        int n = A.Length;
        long[][] C = new long[n][];
        for (int i = 0; i < n; i++) {
            C[i] = new long[n];
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < n; k++) {
                    C[i][j] = (C[i][j] + A[i][k] * B[k][j]) % MOD;
                }
            }
        }
        return C;
    }

    private long[] MultiplyVectorMatrix(long[] vec, long[][] mat) {
        int n = vec.Length;
        long[] result = new long[n];

        for (int j = 0; j < n; j++) {
            for (int i = 0; i < n; i++) {
                result[j] = (result[j] + vec[i] * mat[i][j]) % MOD;
            }
        }
        return result;
    }

    private long[][] IdentityMatrix(int n) {
        long[][] I = new long[n][];
        for (int i = 0; i < n; i++) {
            I[i] = new long[n];
            I[i][i] = 1;
        }
        return I;
    }
    
}