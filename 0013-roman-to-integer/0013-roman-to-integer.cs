public class Solution {
    public int RomanToInt(string s) {

       Dictionary<char,int> romanMap = new Dictionary<char,int>()
       {
        {'I', 1},
        {'V',5},
        {'X',10},
        {'L',50},
        {'C',100},
        {'D',500},
        {'M',1000}
       };


        
        int total = 0;
        int prevValue = 0;

        // Iterate through the string in reverse order
        for (int i = s.Length - 1; i >= 0; i--) {
            int currValue = romanMap[s[i]];

            // If the current numeral is smaller than the previous one, subtract it
            if (currValue < prevValue) {
                total -= currValue;
            } else {
                total += currValue;
            }

            // Update the previous value for the next iteration
            prevValue = currValue;
        }
        return total;
    }
}