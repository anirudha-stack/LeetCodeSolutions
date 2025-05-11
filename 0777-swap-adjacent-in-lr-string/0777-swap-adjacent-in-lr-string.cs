public class Solution {
    public bool CanTransform(string start, string end) {
        if (start.Replace("X", "") != end.Replace("X", ""))
            return false;

        int i = 0, j = 0;
        int n = start.Length;

        while (i < n && j < n) {
            // Skip 'X' in both strings
            while (i < n && start[i] == 'X') i++;
            while (j < n && end[j] == 'X') j++;

            // if both reach end, break
            if (i == n && j == n) return true;
            if (i == n || j == n) return false;

            if (start[i] != end[j])
                return false;

            if (start[i] == 'L' && j > i) return false; // L can't move right
            if (start[i] == 'R' && i > j) return false; // R can't move left

            i++; j++;
        }

        return true;


    }
}