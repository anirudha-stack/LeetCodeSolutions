public class Solution {
    public bool CanChange(string start, string target) {
          int n = start.Length;
        if (n != target.Length) return false;

        // Convert to char array for easier indexing
        char[] s = start.ToCharArray();
        char[] t = target.ToCharArray();

        int i = 0, j = 0;
        while (i < n && j < n) {
            // Skip underscores in start
            while (i < n && s[i] == '_') i++;
            // Skip underscores in target
            while (j < n && t[j] == '_') j++;

            // If one pointer reached the end, break out
            if (i == n || j == n) break;

            // Must have the same letter
            if (s[i] != t[j]) return false;

            // Check movement constraints
            if (s[i] == 'L' && i < j) return false; // L can only move left
            if (s[i] == 'R' && i > j) return false; // R can only move right

            i++; 
            j++;
        }

        // Make sure rest are all underscores
        while (i < n && s[i] == '_') i++;
        while (j < n && t[j] == '_') j++;

        return i == n && j == n;
    
    }
}