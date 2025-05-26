public class Solution {
    public int LargestPathValue(string colors, int[][] edges) {
          int n = colors.Length;
        // Build graph and compute indegrees
        var graph = new List<int>[n];
        int[] indegree = new int[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }
        foreach (var e in edges) {
            int u = e[0], v = e[1];
            graph[u].Add(v);
            indegree[v]++;
        }

        // dp[i][c] = max number of color 'c' seen on any valid path ending at i
        var dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[26];
        }

        // Initialize queue with all nodes of indegree 0
        var q = new Queue<int>();
        for (int i = 0; i < n; i++) {
            if (indegree[i] == 0) q.Enqueue(i);
        }

        int visited = 0;
        int result = 0;

        while (q.Count > 0) {
            int u = q.Dequeue();
            visited++;

            // Count this node's color
            int ci = colors[u] - 'a';
            dp[u][ci]++;
            // Possibly update global max
            result = Math.Max(result, dp[u][ci]);

            // Propagate dp values to neighbors
            foreach (int v in graph[u]) {
                for (int c = 0; c < 26; c++) {
                    if (dp[u][c] > dp[v][c]) {
                        dp[v][c] = dp[u][c];
                    }
                }
                if (--indegree[v] == 0) {
                    q.Enqueue(v);
                }
            }
        }

        // If we didn't visit all nodes, there's a cycle
        return visited < n ? -1 : result;
    }
}