public class Solution {
    public bool CheckXMatrix(int[][] grid) {
       
        for(int i=0;i<grid.Length;i++){
            for(int j=0;j<grid[i].Length;j++){
                      if (i == j || i + j == grid.Length - 1) {
                    if (grid[i][j] == 0) {  // Diagonal elements must be non-zero
                        //Console.WriteLine($"Issue at {i},{j}: Expected non-zero, found {grid[i][j]}");
                        return false;
                    }
                } 
                    else if(grid[i][j] !=0){
                        
                        //Console.WriteLine($"2nd issue at {i},{j} value {grid[i][j]}");
                         return false;
                    }
            }
        }

        return true;
    }
}