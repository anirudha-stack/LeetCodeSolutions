public class Solution {
    public int OrangesRotting(int[][] grid) {

        int[][] visited = new int[grid.Length][];
        for(int i=0;i<grid.Length;i++){
            visited[i] = new int[grid[0].Length];
        }
        int n = grid.Length;
        int m = grid[0].Length;
        int t = 0;
        Queue<(int,int,int)> queue = new Queue<(int,int,int)>();

        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                if(grid[i][j] == 2){
                    visited[i][j] = 2;
                    queue.Enqueue((i,j,0));
                }
            }
        }

       int[][] dirs = new int[][] {
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { -1, 0 }
        };

       while(queue.Count > 0){

            var (i,j,time) = queue.Dequeue();
            visited[i][j] = 2;


        foreach (var dir in dirs) {
            int ni = i + dir[0];
            int nj = j + dir[1];

            // Check bounds first
            if (ni >= 0 && nj >= 0 && ni < n && nj < m && visited[ni][nj] ==0 && grid[ni][nj] == 1) {
               // visited[ni, nj] = true;  // mark as visited
                t = Math.Max(t,time+1);
                visited[i][j] = 2;
                grid[ni][nj] = 2;
                queue.Enqueue((ni, nj,time+1)); // enqueue next cell
            }
        }

        }

        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                if(grid[i][j] == 1 && visited[i][j] == 0 ){
                  return -1;
                }
            }
        }

        return t;

    }
}