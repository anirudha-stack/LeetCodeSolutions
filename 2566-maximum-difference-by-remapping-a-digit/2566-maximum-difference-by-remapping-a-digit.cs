public class Solution {
    public int MinMaxDifference(int num) {
        string s = num.ToString();
        char? from9 = null;
        char? from0 = null;
        char[] numMax = new char[s.Length];
        char[] numMin = new char[s.Length];

        for (int i = 0; i < s.Length; i++) {
            char c = s[i];

            if (from9 == null && c != '9') {
                from9 = c;
            }
            if (from0 == null && c != '0') {
                from0 = c;
            }

            numMax[i] = (c == from9) ? '9' : c;
            numMin[i] = (c == from0) ? '0' : c;
        }

        int maxVal = int.Parse(new string(numMax));
        int minVal = int.Parse(new string(numMin));

        return maxVal - minVal;
    }
}
