public class Solution {
    public int MinDistance(string word1, string word2) {
        int n = word1.Length;
        int m = word2.Length;

        int[][] dp = new int[n][];

        for(int i=0;i<n;i++){
            dp[i] = new int[m];
            Array.Fill(dp[i],-1);
        }

        return solver(dp,word1.Length-1,word2.Length-1,word1,word2);
    }

    public int solver(int[][] dp,int ind1, int ind2,string word1, string word2){

        if(ind1< 0 ){
            return ind2+1;
        }
        if(ind2<0){
            return ind1+1;
        }

        if(dp[ind1][ind2] != -1) return dp[ind1][ind2];

        
        if(word1[ind1] == word2[ind2]) return solver(dp,ind1-1,ind2-1,word1,word2);

            dp[ind1][ind2] = 1 + Math.Min(solver(dp,ind1,ind2-1,word1,word2),Math.Min(solver(dp,ind1-1,ind2,word1,word2),solver(dp,ind1-1,ind2-1,word1,word2)));
            return  dp[ind1][ind2]; 


    }
}