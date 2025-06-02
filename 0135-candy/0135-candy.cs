public class Solution {
    public int Candy(int[] ratings) {
         int n = ratings.Length;
        if (n == 0) return 0;

        // Step 0: Initialize every child with 1 candy
        int[] candies = new int[n];
        for (int i = 0; i < n; i++) {
            candies[i] = 1;
        }

        // Step 1: Left-to-Right pass
        // If current rating is higher than the left neighbor, give one more candy than left.
        for (int i = 1; i < n; i++) {
            if (ratings[i] > ratings[i - 1]) {
                candies[i] = candies[i - 1] + 1;
            }
        }

        // Step 2: Right-to-Left pass
        // If current rating is higher than the right neighbor, ensure candies[i] > candies[i+1].
        for (int i = n - 2; i >= 0; i--) {
            if (ratings[i] > ratings[i + 1]) {
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
        }

        // Step 3: Sum up
        long total = 0;
        for (int i = 0; i < n; i++) {
            total += candies[i];
        }

        return (int)total;
    }
}