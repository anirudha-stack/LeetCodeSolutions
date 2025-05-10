public class Solution {
    public bool IsBipartite(int[][] graph) {
        int n = graph.Length;
        int[] color = new int[n];
        Array.Fill(color, -1); // -1 means unvisited

        for (int start = 0; start < n; start++) {
            if (color[start] != -1)
                continue;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            color[start] = 0;

            while (queue.Count > 0) {
                int node = queue.Dequeue();
                foreach (int neighbor in graph[node]) {
                    if (color[neighbor] == -1) {
                        color[neighbor] = 1 - color[node];
                        queue.Enqueue(neighbor);
                    } else if (color[neighbor] == color[node]) {
                        return false; // conflict
                    }
                }
            }
        }

        return true;
    }
}