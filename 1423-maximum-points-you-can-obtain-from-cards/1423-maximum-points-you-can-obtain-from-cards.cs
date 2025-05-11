public class Solution {
    public int MaxScore(int[] cardPoints, int k) {

        int left = 0;
        int right = cardPoints.Length-1;
        int maxScore = 0;

        while(k>0 ){

           if(cardPoints[left] <= cardPoints[right]){
             maxScore +=  cardPoints[right];
              right--;
            
           }
           else{
            maxScore +=  cardPoints[left];
                 left++;
           }
            
        
             k--;
        }

        return maxScore;

    }
}