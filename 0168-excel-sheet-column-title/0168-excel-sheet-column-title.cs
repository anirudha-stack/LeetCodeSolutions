public class Solution {
    public string ConvertToTitle(int columnNumber) {
         string answer = "";

        while (columnNumber > 0) {
            columnNumber--; // Adjust for 1-based index
            int remainder = columnNumber % 26;
            char c = (char)(remainder + 'A');
            answer = c + answer; // prepend to the result
            columnNumber /= 26;
        }

        return answer;
    }
}