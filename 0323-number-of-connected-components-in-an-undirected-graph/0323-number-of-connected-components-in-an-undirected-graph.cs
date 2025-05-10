public class Solution {
    private class DSU {
     public Dictionary<int, int> ranks = new Dictionary<int, int>();
     public Dictionary<int, int> parents = new Dictionary<int, int>();

        public void CreateDSU(int n) {
            for (int i = 0; i < n; i++) {
                ranks[i] = 0;
                parents[i] = i;
            }
        }

        public int FindParent(int node) {
            if (parents[node] != node) {
                parents[node] = FindParent(parents[node]);
            }
            return parents[node];
        }

        public void UnionByRank(int u, int v) {
            int pu = FindParent(u);
            int pv = FindParent(v);

            if (pu == pv) return;

            if (ranks[pu] < ranks[pv]) {
                parents[pu] = pv;
            } else if (ranks[pu] > ranks[pv]) {
                parents[pv] = pu;
            } else {
                parents[pv] = pu;
                ranks[pu]++;
            }
        }
    }

    public int CountComponents(int n, int[][] edges) {
        DSU dsu = new DSU();
        dsu.CreateDSU(n);

        // Union all edges
        foreach (var edge in edges) {
            int u = edge[0];
            int v = edge[1];
            dsu.UnionByRank(u, v);
        }

        // Count unique parents
        HashSet<int> components = new HashSet<int>();
        for (int i = 0; i < n; i++) {
            components.Add(dsu.FindParent(i));
        }

        return components.Count;
    }

    
}