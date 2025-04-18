public class Solution {
    public double MyPow(double x, int n) {
        long N = n;
        if (N < 0) {
            x = 1.0 / x;
            N = -N;
        }
        
        double result = 1.0;
        while (N > 0) {
            // If the lowest bit is 1, multiply result by current x
            if ((N & 1) == 1) {
                result *= x;
            }
            // Square x and shift N right
            x *= x;
            N >>= 1;
        }
        
        return result;
    }
}