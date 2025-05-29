using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    private int evenA, oddA, evenB, oddB;

    private List<List<int>> BuildList(int[][] edges) {
        int n = edges.Length + 1;
        var adj = new List<List<int>>(n);
        for (int i = 0; i < n; i++) 
            adj.Add(new List<int>());
        foreach (var e in edges) {
            adj[e[0]].Add(e[1]);
            adj[e[1]].Add(e[0]);
        }
        return adj;
    }

    private void DfsColor(List<List<int>> adj, int u, int parent, int[] color, bool isA) {
        if (color[u] == 0) {
            if (isA) evenA++; else evenB++;
        } else {
            if (isA) oddA++; else oddB++;
        }
        foreach (var v in adj[u]) {
            if (v == parent) continue;
            color[v] = color[u] ^ 1;
            DfsColor(adj, v, u, color, isA);
        }
    }

    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2) {
        var adjA = BuildList(edges1);
        var adjB = BuildList(edges2);
        int n = adjA.Count, m = adjB.Count;

        // initialize colors to -1
        var colorA = Enumerable.Repeat(-1, n).ToArray();
        var colorB = Enumerable.Repeat(-1, m).ToArray();

        // reset counters
        evenA = oddA = evenB = oddB = 0;

        // color each tree
        colorA[0] = 0;
        DfsColor(adjA, 0, -1, colorA, true);
        colorB[0] = 0;
        DfsColor(adjB, 0, -1, colorB, false);

        // best we can do in tree B
        int maxiB = Math.Max(evenB, oddB);

        var result = new int[n];
        for (int i = 0; i < n; i++) {
            // if node i in A is even-colored, it already reaches evenA nodes in A at even distance,
            // otherwise oddA. Then add best of B.
            result[i] = (colorA[i] == 0 ? evenA : oddA) + maxiB;
        }
        return result;
    }
}
