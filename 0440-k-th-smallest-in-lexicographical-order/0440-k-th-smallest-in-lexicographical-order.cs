public class Solution {
    public int FindKthNumber(int n, int k) {
         int curr = 1;
        k--;  // we already count '1' as the first number

        while (k > 0) {
            long steps = CountSteps(n, curr, curr + 1);
            if (steps <= k) {
                curr++;     // move to next sibling
                k -= (int)steps;
            } else {
                curr *= 10; // go to first child
                k--;
            }
        }

        return curr;
    }

    private long CountSteps(int n, long curr, long next) {
        long steps = 0;
        while (curr <= n) {
            steps += Math.Min((long)n + 1, next) - curr;
            curr *= 10;
            next *= 10;
        }
        return steps;
    
    }
}