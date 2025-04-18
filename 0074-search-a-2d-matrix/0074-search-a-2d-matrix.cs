public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int currentRow = -1;
        bool answer = false; 

        for(int i=0;i<m;i++){
            
            if(target <= matrix[i][n-1]){
               
                currentRow= i;
                break;
            }
        }

        if(currentRow == -1) return false;

        for(int i=0;i<n;i++){
            
               if( matrix[currentRow][i] == target){
                    answer= true;
                    break;
                }
                else{
                    answer= false;
                }
            

        }
        return answer;
    }
}