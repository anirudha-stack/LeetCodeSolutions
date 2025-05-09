public class Solution {
    public int NumIslands(char[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int answer = 0;

        int[][] visited = new int[m][];
        for (int i = 0; i < m; i++) {
            visited[i] = new int[n];
        }

        answer = bfs(grid, visited);
        return answer;
    }

    public int bfs(char[][] grid, int[][] visited) {
        int answer = 0;
        Queue<(int, int)> queue = new Queue<(int, int)>();

        int[][] dirs = new int[][] {
            new int[] { 0, 1 }, new int[] { 0, -1 },
            new int[] { 1, 0 }, new int[] { -1, 0 }
        };

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == '0' || visited[i][j] == 1) continue;

                // Start BFS from this new island
                queue.Enqueue((i, j));
                visited[i][j] = 1;

                while (queue.Count > 0) {
                    var (row, col) = queue.Dequeue();

                    foreach (var dir in dirs) {
                        int ri = row + dir[0];
                        int ci = col + dir[1];

                        if (ri >= 0 && ri < grid.Length &&
                            ci >= 0 && ci < grid[0].Length &&
                            grid[ri][ci] == '1' &&
                            visited[ri][ci] == 0)
                        {
                            visited[ri][ci] = 1;
                            queue.Enqueue((ri, ci));
                        }
                    }
                }

                answer++;
            }
        }

        return answer;
    }
}
