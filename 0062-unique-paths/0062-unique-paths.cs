public class Solution {
    public int UniquePaths(int m, int n) {
        if(m==0 || n==0) return 1;
        
        var memo = new Dictionary<(int, int), int>();
        return isEndPoint(m-1,n-1,0,0,memo);
    }


    public int isEndPoint(int m ,int n,int i,int j, Dictionary<(int, int),int> memo){
        if(i==m && j==n) return 1;

        if(i>m || j>n) return 0;
            var key = (i, j);
        if(memo.ContainsKey(key)){
            return memo[key];
        }

        int leftSubTree = isEndPoint( m,n,i+1,j,memo);
        int rightSubTree = isEndPoint( m,n,i,j+1,memo);
        int answer = leftSubTree+rightSubTree;

        memo[key] = answer;


        return leftSubTree+rightSubTree;
    }
}