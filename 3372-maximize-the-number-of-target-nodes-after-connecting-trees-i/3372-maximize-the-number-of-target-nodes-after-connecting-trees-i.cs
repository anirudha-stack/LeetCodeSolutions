using System;
using System.Collections.Generic;

public class Solution {
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k) {
        int n1 = edges1.Length + 1;
        int n2 = edges2.Length + 1;
        
        // 1. Build adjacency lists
        var tree1 = BuildGraph(n1, edges1);
        var tree2 = BuildGraph(n2, edges2);
        
        // 2. Precompute reachability in tree1
        var count1 = new int[n1];
        for (int i = 0; i < n1; i++) {
            count1[i] = BFSCount(tree1, i, k);
        }
        
        // 3. Precompute reachability in tree2 (depth = k-1)
        int maxCount2 = 0;
        if (k > 0) {
            for (int j = 0; j < n2; j++) {
                int c = BFSCount(tree2, j, k - 1);
                if (c > maxCount2) maxCount2 = c;
            }
        }
        
        // 4. Combine results
        var answer = new int[n1];
        for (int i = 0; i < n1; i++) {
            answer[i] = count1[i] + maxCount2;
        }
        return answer;
    }
    
    // Builds an adjacency list for a tree of size n
    private List<int>[] BuildGraph(int n, int[][] edges) {
        var g = new List<int>[n];
        for (int i = 0; i < n; i++) g[i] = new List<int>();
        foreach (var e in edges) {
            int u = e[0], v = e[1];
            g[u].Add(v);
            g[v].Add(u);
        }
        return g;
    }
    
    // Returns the number of nodes reachable from 'start' within 'maxDepth' edges
    private int BFSCount(List<int>[] graph, int start, int maxDepth) {
        if (maxDepth < 0) return 0;  // nothing reachable if depth < 0
        
        int n = graph.Length;
        var visited = new bool[n];
        var queue = new Queue<int>();
        
        visited[start] = true;
        queue.Enqueue(start);
        
        int depth = 0, count = 0;
        while (queue.Count > 0 && depth <= maxDepth) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                int u = queue.Dequeue();
                count++;
                foreach (int v in graph[u]) {
                    if (!visited[v]) {
                        visited[v] = true;
                        queue.Enqueue(v);
                    }
                }
            }
            depth++;
        }
        
        return count;
    }
}
