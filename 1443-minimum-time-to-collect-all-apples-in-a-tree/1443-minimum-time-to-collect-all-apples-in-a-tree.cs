public class Solution {
    public int MinTime(int n, int[][] edges, IList<bool> hasApple) {
    // Build adjacency list representation of the tree
        Dictionary<int, List<int>> tree = new Dictionary<int, List<int>>();
        foreach (var edge in edges) {
            if (!tree.ContainsKey(edge[0])) tree[edge[0]] = new List<int>();
            if (!tree.ContainsKey(edge[1])) tree[edge[1]] = new List<int>();
            tree[edge[0]].Add(edge[1]);
            tree[edge[1]].Add(edge[0]);
        }

        // DFS to calculate the minimum time needed to collect apples
        return DFS(0, -1, tree, hasApple);
    }

    private int DFS(int node, int parent, Dictionary<int, List<int>> tree, IList<bool> hasApple) {
        int time = 0;
        if (!tree.ContainsKey(node)) return 0;  // Leaf node case

        foreach (var neighbor in tree[node]) {
            if (neighbor == parent) continue; // Avoid visiting the parent node again
            
            int childTime = DFS(neighbor, node, tree, hasApple);
            if (childTime > 0 || hasApple[neighbor]) {
                time += childTime + 2; // Add time for both forward and backward traversal
            }
        }
        
        return time;
    }

}