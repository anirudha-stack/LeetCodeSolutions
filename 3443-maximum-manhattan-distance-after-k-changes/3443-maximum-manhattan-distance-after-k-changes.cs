public class Solution {
    public int MaxDistance(string s, int k) {
        int x = 0, y = 0;
        int[] distances = new int[s.Length];

        // Simulate movement and record Manhattan distances
        for (int i = 0; i < s.Length; i++) {
            char move = s[i];
            if (move == 'N') y++;
            else if (move == 'S') y--;
            else if (move == 'E') x++;
            else if (move == 'W') x--;

            distances[i] = Math.Abs(x) + Math.Abs(y);
        }

        if (k == 0) {
            int max = 0;
            foreach (var d in distances)
                max = Math.Max(max, d);
            return max;
        }

        int maxDist = distances[1];
        int prev = distances[0];
        int addedBoost = 0;

        for (int i = 1; i < distances.Length; i++) {
            if (distances[i] < prev && k > 0) {
                addedBoost += 2;
                k--;
            }
            prev = distances[i];
            distances[i] += addedBoost;
            maxDist = Math.Max(maxDist, distances[i]);
        }

        return maxDist;
    }
}
