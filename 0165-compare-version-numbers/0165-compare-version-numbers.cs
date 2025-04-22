public class Solution {
    public int CompareVersion(string version1, string version2) {
        // 1) Split both versions on '.'
        string[] v1 = version1.Split('.');
        string[] v2 = version2.Split('.');
        
        // 2) Compare revision by revision
        int n = Math.Max(v1.Length, v2.Length);
        for (int i = 0; i < n; i++) {
            // Parse each revision (or treat missing ones as 0)
            int num1 = i < v1.Length ? int.Parse(v1[i]) : 0;
            int num2 = i < v2.Length ? int.Parse(v2[i]) : 0;
            
            if (num1 < num2) return -1;
            if (num1 > num2) return  1;
            // else they’re equal → continue
        }
        
        // All revisions matched
        return 0;

    }
}