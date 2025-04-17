public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        
        var result = new List<IList<int>>();

        for (int i = 0; i < numRows; i++) {
            var row = new List<int>();
            for (int j = 0; j <= i; j++) {
                if (j == 0 || j == i) {
                    row.Add(1);
                } else {
                    row.Add(result[i - 1][j - 1] + result[i - 1][j]);
                }
            }
            result.Add(row);
        }

        return result;

    }
}