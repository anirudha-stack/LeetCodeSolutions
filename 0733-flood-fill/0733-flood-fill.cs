public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        
        int[][] dirs = new int[][]{
            new int[]{0,1},
            new int[]{1,0},
            new int[]{-1,0},
            new int[]{0,-1}
        };

        Queue<(int,int)> queue = new Queue<(int,int)>();

        int[][] visited = new int[image.Length][];

        for(int i = 0; i< image.Length ; i++){
            visited[i] = new int[image[0].Length];
        }


        int ogColor = image[sr][sc];
        queue.Enqueue((sr,sc));

        while(queue.Count > 0){

            var (i,j) = queue.Dequeue();

            visited[i][j] = 1;
            image[i][j] = color;

            foreach(var dir in dirs){

                int ri = i + dir[0];
                int ci = j + dir[1];

                if(

                    ri>=0 && ri<image.Length &&
                    ci>=0 && ci<image[0].Length &&
                    
                    image[ri][ci] == ogColor

                    && visited[ri][ci] != 1

                )
                {

                    visited[ri][ci] = 1;
                    image[ri][ci] = color;
                    queue.Enqueue((ri,ci));
                }

            }
 
        }

        return image;

    }
    
}