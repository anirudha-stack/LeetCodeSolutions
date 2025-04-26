public class Solution {
    public void SolveSudoku(char[][] board) {
        solve(board); 
        return;
    }


    public bool solve(char[][] board){

        for(int i=0;i<board.Length;i++){
            for(int j=0;j<board[0].Length;j++){


                if(board[i][j] == '.'){

                    for(char c = '1' ; c <= '9'; c++){

                        if(canPlace(i,j,c,board)){

                            board[i][j] = c;

                            if(solve(board) == true){
                              return true;
                            }
                            else{
                                 board[i][j] = '.';
                            }

                        }

                        
                    }
                    return false;
                    
                }



            }
        }

        return true;

    }


    private bool canPlace(int row, int col, char c, char[][] board){

        for(int i=0;i<9;i++){

            if(board[i][col] == c) return false;

            if(board[row][i] == c) return false;


            if( board[ 3 * (row/3) + (i/3) ][3 * (col/3) + (i%3)] == c) return false;


        }

        return true;


    }
}