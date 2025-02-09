public class Solution {
    public int MinimumNumbers(int num, int k) {
       if (num == 0)  return 0;
       if (k == 0) return (num % 10 == 0) ? 1 : -1;

        for (int x = 1; x <= num / k; x++) {
            if (x * k <= num && (num - x * k) % 10 == 0) {
                return x;
            }
        }
        
        return -1;

    }
}