public class Solution {
    public int AddDigits(int num) {
         // Keep reducing until we're down to one digit
        while (num >= 10) {
            int digitSum = 0;
            while (num > 0) {
                digitSum += num % 10;
                num /= 10;
            }
            num = digitSum;
        }
        return num;
    }
}