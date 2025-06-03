public class Solution {
    public int MaxCandies(int[] status, int[] candies, IList<IList<int>> keys,
                          IList<IList<int>> containedBoxes, int[] initialBoxes) {
        int n = status.Length;
        int ans = 0;

        // Represent state with:
        // 0 = closed
        // 1 = open
        // 2 = have box
        // 3 = have box + open
        int Dfs(int i) {
            int res = candies[i];
            status[i] = 0; // mark as visited (processed/closed)

            foreach (int k in keys[i]) {
                status[k] |= 1; // mark as openable (has key)
                if (status[k] == 3) {
                    res += Dfs(k);
                }
            }

            foreach (int j in containedBoxes[i]) {
                status[j] |= 2; // mark as in our possession (have box)
                if (status[j] == 3) {
                    res += Dfs(j);
                }
            }

            return res;
        }

        foreach (int i in initialBoxes) {
            status[i] |= 2; // mark as "we have this box"
        }

        for (int i = 0; i < n; i++) {
            if (status[i] == 3) {
                ans += Dfs(i);
            }
        }

        return ans;
    }
}
