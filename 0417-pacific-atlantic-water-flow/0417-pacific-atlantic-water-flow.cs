public class Solution {

    public int[][] dirs = new int[][]{
            new int[] { 1 , 0},
            new int[] { 0 , 1},
            new int[] { -1 , 0},
            new int[] { 0 , -1}
        };

    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        
        bool[][] pVisited = new bool[heights.Length][];
        List<IList<int>> answer = new();

        for(int i=0;i<heights.Length;i++){
            pVisited[i] = new bool[heights[i].Length];
            Array.Fill(pVisited[i],false);
        }

        bool[][] aVisited = new bool[heights.Length][];


        for(int i=0;i<heights.Length;i++){
            aVisited[i] = new bool[heights[i].Length];
            Array.Fill(aVisited[i],false);
        }

        Queue<(int,int)> pQueue = new();
        Queue<(int,int)> aQueue = new();
        
        int m = heights.Length, n = heights[0].Length;


        for(int i=0;i<heights.Length;i++) pQueue.Enqueue((i,0));
        for(int i=0;i<heights[0].Length;i++) pQueue.Enqueue((0,i));

        for (int i = 0; i < m; i++) aQueue.Enqueue((i, n - 1));   // right edge
        for (int j = 0; j < n; j++) aQueue.Enqueue((m - 1, j));   // bottom edge

        BFS(heights,pVisited,pQueue);
        
        BFS(heights,aVisited,aQueue);

        for(int i=0;i<heights.Length;i++){
            for(int j=0;j<heights[i].Length;j++){
                if(pVisited[i][j]== true && aVisited[i][j] == true){
                        answer.Add(new List<int>{i,j});
                }
            }
        }

        return answer;

    }

    public void BFS(int[][] heights, bool[][] visited , Queue<(int,int)> queue ){
    
      
        while(queue.Count>0){

            var (i,j) = queue.Dequeue();

            if(visited[i][j] != false ) continue;
            visited[i][j] = true;

            foreach(var dir in dirs){
                int ri = i + dir[0];
                int cj = j + dir[1];

                if(
                        ri>=0 && ri< heights.Length &&
                        cj>=0 &&  cj< heights[i].Length &&
                        visited[ri][cj] == false &&
                        heights[ri][cj] >= heights[i][j]

                )
                {
                        queue.Enqueue((ri,cj));
                }

            }

        }
    }
}