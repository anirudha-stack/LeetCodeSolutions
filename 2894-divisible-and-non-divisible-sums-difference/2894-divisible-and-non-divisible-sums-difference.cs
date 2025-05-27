public class Solution {
    public int DifferenceOfSums(int n, int m) {
        
        long num1 = 0;
        long num2 = 0;

        for(int i=1;i<=n;i++){
            if(i%m ==0){
                num1+=i;
            }
            else{
                num2+=i;
            }
        }

        return (int)(num2-num1);

    }
}