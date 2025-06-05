public class Solution {
    int[] parent = new int[26]; // For characters 'a' to 'z'

    public string SmallestEquivalentString(string s1, string s2, string baseStr) {
        // Initialize each character's parent to itself
        for (int i = 0; i < 26; i++) {
            parent[i] = i;
        }

        // Union the equivalent characters from s1 and s2
        for (int i = 0; i < s1.Length; i++) {
            Union(s1[i] - 'a', s2[i] - 'a');
        }

        // Build result for baseStr using the smallest equivalent character
        var result = new StringBuilder();
        foreach (char c in baseStr) {
            result.Append((char)(Find(c - 'a') + 'a'));
        }

        return result.ToString();
    }

    // Find with path compression
    private int Find(int x) {
        if (parent[x] != x) {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    // Union by lexicographical order (smallest character becomes the root)
    private void Union(int x, int y) {
        int px = Find(x);
        int py = Find(y);

        if (px == py) return;

        if (px < py) {
            parent[py] = px;
        } else {
            parent[px] = py;
        }
    }
}
