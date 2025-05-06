public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
     int n = nums.Length;
        var diff = new int[n + 1];

        // 1) Build difference array for the query ranges
        foreach (var q in queries) {
            int l = q[0], r = q[1];
            diff[l]++;
            if (r + 1 < n) diff[r + 1]--;
        }

        // 2) Prefix-sum to get coverage count
        int[] cover = new int[n];
        int running = 0;
        for (int i = 0; i < n; i++) {
            running += diff[i];
            cover[i] = running;
        }

        // 3) Check if every element got decremented to zero
        for (int i = 0; i < n; i++) {
            if (cover[i] < nums[i])
                return false;
        }

        return true;

    }
}