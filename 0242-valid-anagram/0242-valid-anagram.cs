public class Solution {
    public bool IsAnagram(string s, string t) {
        char[] sArr = s.ToArray();
        char[] tArr = t.ToArray();
        Array.Sort(sArr);
        Array.Sort(tArr);

        return string.Compare(new string(sArr),new string(tArr)) == 0 ? true : false;


    }
}