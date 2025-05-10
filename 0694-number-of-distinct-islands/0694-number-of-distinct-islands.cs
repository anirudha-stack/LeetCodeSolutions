public class Solution {

     public HashSet<string> islands  = new HashSet<string> ();

    public int NumDistinctIslands(int[][] grid) {
            int[][] visited = new int[grid.Length][];

            for(int i=0;i<grid.Length;i++){
                visited[i] = new int[grid[i].Length];
            }


            for(int i=0;i<grid.Length;i++){
                for(int j=0;j<grid[0].Length;j++){
                    if(visited[i][j] == 1 || grid[i][j] == 0) continue;

                    BFS(i,j,grid,visited);
                }
            }

            return islands.Count;
    }

    public void BFS(int startrow, int startcol, int[][] grid, int[][] visited){
        int[][] dirs = new int[][]{

            new int[] { 0, 1},
            
            new int[] { 1, 0},
            
            new int[] { -1, 0},
            
            new int[] { 0, -1},

        };
        
        if(visited[startrow][startcol] == 1) return;

        Queue<(int,int)> queue = new Queue<(int,int)>();

        queue.Enqueue((startrow,startcol));
        visited[startrow][startcol] =1;
        List<(int,int)> currentans = new List<(int,int)>();
        while(queue.Count > 0){

            var (i,j) = queue.Dequeue();
            //visited[i][j] = 1;
            currentans.Add((i-startrow,j-startcol));

            foreach(var dir in dirs){

                int ri = i + dir[0];
                int ci = j + dir[1];


                if(

                    ri>=0 && ri< grid.Length &&
                    ci>=0 && ci<grid[0].Length &&

                    grid[ri][ci] == 1
                    && visited[ri][ci] ==0


                )
                
                {
                   
                    visited[ri][ci] =1;
                   // currentans.Add((ri-startrow,ci-startcol));
                    queue.Enqueue((ri,ci));
                }

            }


        }

        // sort so that different visitation orders yield the same key
        currentans.Sort((a, b) =>
        {
            int d = a.Item1.CompareTo(b.Item1);
            return d != 0 ? d : a.Item2.CompareTo(b.Item2);
        });

        // serialize into e.g. "0,0;0,1;1,0;1,1"
        var key = string.Join(";", currentans.Select(p => $"{p.Item1},{p.Item2}"));

        if(!islands.Contains(key))
         islands.Add(key);

        return;
    }

}