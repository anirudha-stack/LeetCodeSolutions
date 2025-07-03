public class Solution {
    public char KthCharacter(int k) {
         int ans = 0;
        int t;
        while (k != 1) {
            t = (int)Math.Log(k, 2);
            if ((1 << t) == k) {
                t--;
            }
            k = k - (1 << t);
            ans++;
        }
        return (char)('a' + ans);
    }
}