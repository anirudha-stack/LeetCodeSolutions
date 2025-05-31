public class Solution {
    public int SnakesAndLadders(int[][] board) {
          int n = board.Length;
        int total = n * n;
        
        // minRolls[s] = minimum number of dice rolls required to reach square s (1-based).
        // Initialize all entries to -1 (unvisited).
        int[] minRolls = new int[total + 1];
        Array.Fill(minRolls, -1);
        
        var q = new Queue<int>();
        minRolls[1] = 0;     // Start at square 1 with 0 rolls.
        q.Enqueue(1);
        
        while (q.Count > 0)
        {
            int x = q.Dequeue();
            
            // Try all possible die outcomes 1 through 6 (but don't exceed total squares).
            for (int i = 1; i <= 6 && x + i <= total; i++)
            {
                int t = x + i; 
                
                // Convert square number t ↔ 2D indices (r, c) in the "boustrophedon" board.
                int row = (t - 1) / n;
                int col = (t - 1) % n;
                int r = n - 1 - row;
                int c = (row % 2 == 1) 
                        ? (n - 1 - col)   // if row is odd, traverse right-to-left
                        : col;            // if row is even, traverse left-to-right
                
                int dest = board[r][c];
                int y = (dest > 0) ? dest : t;  // if there's a snake/ladder, jump to dest
                
                // If we reached the final square, return the rolls used so far + 1
                if (y == total)
                    return minRolls[x] + 1;
                
                if (minRolls[y] == -1)
                {
                    minRolls[y] = minRolls[x] + 1;
                    q.Enqueue(y);
                }
            }
        }
        
        return -1; 
    }
}