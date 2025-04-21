public class Solution {
    public int StrStr(string haystack, string needle) {
        
 int n = haystack.Length, m = needle.Length;
    if (m == 0) return 0;               // empty needle

    // only go up to n-m, else you'd run past the end
    for (int i = 0; i <= n - m; i++) {
        int j = 0;
        // compare haystack[i + j] to needle[j]
        while (j < m && haystack[i + j] == needle[j]) {
            j++;
        }
        if (j == m) return i;           // matched entire needle
    }

    return -1;                          // no match found

    }
}