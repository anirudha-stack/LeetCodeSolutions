public class Solution {
    public IList<int> GetRow(int rowIndex) {
         List<int> row = new List<int>();
            long value = 1;

            for (int k = 0; k <= rowIndex; k++) {
                row.Add((int)value);
                value = value * (rowIndex - k) / (k + 1);
            }

            return row;
    }


}