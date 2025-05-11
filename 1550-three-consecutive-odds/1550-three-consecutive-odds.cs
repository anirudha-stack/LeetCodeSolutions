public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int oddCount = 0;
        bool isStillOdd = false;

        for(int i=0;i<arr.Length;i++){
            if(arr[i] %2 != 0) {
                isStillOdd = true;
                oddCount++;
                if(oddCount == 3) break;
            }
            else{
                isStillOdd = false;
            }
        }

        return isStillOdd;
        
    }
}