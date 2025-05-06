public class Solution {
    public char FindTheDifference(string s, string t) {
         int xor = 0;
        foreach (char c in s)
            xor ^= c;
        foreach (char c in t)
            xor ^= c;
        return (char)xor;
    }
}