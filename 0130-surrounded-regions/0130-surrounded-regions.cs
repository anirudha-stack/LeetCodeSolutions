public class Solution {
    public void Solve(char[][] board) {
        int m = board.Length;
        if (m == 0) return;
        int n = board[0].Length;

        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Step 1: Enqueue all border 'O's
        for (int i = 0; i < m; i++) {
            if (board[i][0] == 'O') queue.Enqueue((i, 0));
            if (board[i][n - 1] == 'O') queue.Enqueue((i, n - 1));
        }

        for (int j = 0; j < n; j++) {
            if (board[0][j] == 'O') queue.Enqueue((0, j));
            if (board[m - 1][j] == 'O') queue.Enqueue((m - 1, j));
        }

        // Directions: right, left, down, up
        int[][] dirs = new int[][] {
            new int[] { 0, 1 }, new int[] { 0, -1 },
            new int[] { 1, 0 }, new int[] { -1, 0 }
        };

        // Step 2: BFS to mark safe region
        while (queue.Count > 0) {
            var (i, j) = queue.Dequeue();
            if (i < 0 || i >= m || j < 0 || j >= n || board[i][j] != 'O') continue;

            board[i][j] = '#';

            foreach (var dir in dirs) {
                int ni = i + dir[0];
                int nj = j + dir[1];
                queue.Enqueue((ni, nj));
            }
        }

        // Step 3: Flip captured and restore safe
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (board[i][j] == 'O') board[i][j] = 'X';
                else if (board[i][j] == '#') board[i][j] = 'O';
            }
        }
    }

    
}