public class Solution {
    public bool IsPalindrome(string s) {

    StringBuilder cleaned = new StringBuilder();

        foreach (char c in s) {
            if (char.IsLetterOrDigit(c)) {
                cleaned.Append(char.ToLower(c));
            }
        }

        string filtered = cleaned.ToString();
        int st = 0, e = filtered.Length - 1;

        while (st < e) {
            if (filtered[st] != filtered[e]) return false;
            st++;
            e--;
        }

        return true;
    }
}