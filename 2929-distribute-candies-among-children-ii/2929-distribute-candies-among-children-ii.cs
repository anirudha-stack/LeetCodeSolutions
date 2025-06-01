public class Solution {
    public long DistributeCandies(int n, int limit) {
          // If n > 3*limit, it’s impossible for all three to stay ≤ limit
        if (n > 3L * limit)
            return 0;

        // Precompute ways(m) = number of non-negative integer solutions to x₁+x₂+x₃ = m
        // which is C(m + 2, 2) = (m+2)*(m+1)/2
        static long Ways(int m) {
            if (m < 0) return 0;
            long t = (long)m + 1; // we’ll compute (m+2)*(m+1)/2 as ( (m+2) * (m+1) ) / 2
            return (t + 1) * t / 2;
        }

        int Lp1 = limit + 1;
        long total  = Ways(n);
        long oneEx  = Ways(n -    Lp1);      // cases where child₁ > limit (same count for any one child)
        long twoEx  = Ways(n - 2 * Lp1);      // cases where child₁ & child₂ both > limit
        long threeEx= Ways(n - 3 * Lp1);      // cases where all three > limit

        // Inclusion–exclusion:
        //   total      = Ways(n)
        // – 3*oneEx    (subtract any one child exceeding)
        // + 3*twoEx    (add back overlaps where two exceed)
        // –    threeEx (subtract overlap where all three exceed)
        return total
             - 3 * oneEx
             + 3 * twoEx
             -     threeEx;
    
    }
}