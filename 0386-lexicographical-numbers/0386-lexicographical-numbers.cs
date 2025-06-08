public class Solution {
    public IList<int> LexicalOrder(int n) {
       List<int> result = new List<int>(n);
    int curr = 1;

    for (int i = 0; i < n; i++) {
        result.Add(curr);

        if (curr * 10 <= n) {
            curr *= 10;  // go deeper
        } else {
            // go to next sibling or backtrack
            while (curr % 10 == 9 || curr + 1 > n) {
                curr /= 10;
            }
            curr++;
        }
    }

    return result;  
    }
}