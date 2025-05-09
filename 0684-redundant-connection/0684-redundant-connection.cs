public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] parent = new int[n + 1];

        // Initialize each node's parent to itself
        for (int i = 1; i <= n; i++) {
            parent[i] = i;
        }

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];

            int pu = Find(u, parent);
            int pv = Find(v, parent);

            if (pu == pv) {
                // u and v already connected → cycle detected
                return edge;
            }

            // Union the sets
            parent[pu] = pv;
        }

        return new int[0];  // Should never happen per problem description
    }

    private int Find(int x, int[] parent) {
        if (parent[x] != x)
            parent[x] = Find(parent[x], parent);  // Path compression
        return parent[x];
    }
}