public class Solution {
    public string LongestCommonPrefix(string[] strs) {
         if (strs == null || strs.Length == 0)
            return "";

        // We'll scan column by column
        for (int i = 0; i < strs[0].Length; i++) {
            char c = strs[0][i];
            // Compare this character c to all other strings
            for (int j = 1; j < strs.Length; j++) {
                // If we've run off the end of strs[j], or chars differ, bail out
                if (i >= strs[j].Length || strs[j][i] != c) {
                    // All matching so far is strs[0][0..i-1]
                    return strs[0].Substring(0, i);
                }
            }
        }

        // If we finished the loop, the entire first string is a common prefix
        return strs[0];
    }
}