public class Solution {
    public int MaxDiff(int num) {
        string s = num.ToString();

        // Maximize: change first digit not 9 to 9
        char maxReplaceFrom = s.FirstOrDefault(c => c != '9');
        string maxStr = maxReplaceFrom == '\0' ? s : s.Replace(maxReplaceFrom, '9');
        int maxVal = int.Parse(maxStr);

        // Minimize: change first digit not 1 (if at front) or 0 (if not front) to 1 or 0
        char minReplaceFrom = '\0';
        char target = '\0';
        if (s[0] != '1') {
            minReplaceFrom = s[0];
            target = '1';
        } else {
            minReplaceFrom = s.FirstOrDefault(c => c != '0' && c != '1');
            if (minReplaceFrom != '\0') target = '0';
        }

        string minStr = minReplaceFrom == '\0' ? s : s.Replace(minReplaceFrom, target);
        int minVal = int.Parse(minStr);

        return maxVal - minVal;
    }
}
