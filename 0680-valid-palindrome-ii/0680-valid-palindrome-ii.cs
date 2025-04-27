public class Solution {
    public bool ValidPalindrome(string s) {
        
      int left = 0, right = s.Length - 1;

        while (left < right) {
            if (s[left] != s[right]) {
                return IsPalindromeRange(s, left + 1, right) || IsPalindromeRange(s, left, right - 1);
            }
            left++;
            right--;
        }

        return true; // No mismatch found — it's already a palindrome
    }

    private bool IsPalindromeRange(string s, int start, int end) {
        while (start < end) {
            if (s[start] != s[end]) return false;
            start++;
            end--;
        }
        return true;
    }
}