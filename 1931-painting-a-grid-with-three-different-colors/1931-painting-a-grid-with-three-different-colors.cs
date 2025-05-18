public class Solution {
       const int MOD = 1_000_000_007;

    public int ColorTheGrid(int m, int n) {
        var validCols = new List<int[]>();
        GenerateColumnPatterns(m, new List<int>(), validCols);

        // Create a map of compatible columns (no horizontal conflicts)
        var compatible = new Dictionary<string, List<string>>();
        foreach (var a in validCols) {
            var keyA = string.Join(",", a);
            compatible[keyA] = new List<string>();
            foreach (var b in validCols) {
                if (IsCompatible(a, b)) {
                    compatible[keyA].Add(string.Join(",", b));
                }
            }
        }

        // Memoization cache
        var memo = new Dictionary<(int, string), int>();

        int DFS(int col, string prev) {
            if (col == n) return 1;
            if (memo.ContainsKey((col, prev))) return memo[(col, prev)];

            long ways = 0;
            foreach (var next in compatible[prev]) {
                ways = (ways + DFS(col + 1, next)) % MOD;
            }

            return memo[(col, prev)] = (int)ways;
        }

        long result = 0;
        foreach (var col in validCols) {
            result = (result + DFS(1, string.Join(",", col))) % MOD;
        }

        return (int)result;
    }

    // Generate all valid column colorings (no two adjacent cells same color)
    void GenerateColumnPatterns(int m, List<int> current, List<int[]> result) {
        if (current.Count == m) {
            result.Add(current.ToArray());
            return;
        }

        for (int color = 0; color < 3; color++) {
            if (current.Count > 0 && current[^1] == color) continue;
            current.Add(color);
            GenerateColumnPatterns(m, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }

    // Ensure no row has the same color in two adjacent columns
    bool IsCompatible(int[] a, int[] b) {
        for (int i = 0; i < a.Length; i++) {
            if (a[i] == b[i]) return false;
        }
        return true;
    }   
    
}