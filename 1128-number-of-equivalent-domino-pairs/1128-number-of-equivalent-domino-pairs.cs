public class Solution {
    public int NumEquivDominoPairs(int[][] dominoes) {
        
      var counts = new Dictionary<int,int>();
        int answer = 0;
        foreach (var d in dominoes) {
            int a = d[0], b = d[1];
            // canonical key: smaller first
            int key = a < b ? a * 10 + b : b * 10 + a;

            if (counts.TryGetValue(key, out int c)) {
                // this domino matches each of the c previous ones
                answer += c;
                counts[key] = c + 1;
            } else {
                counts[key] = 1;
            }
        }
        return answer;
    }
}