public class Solution {
    public string RemoveKdigits(string num, int k) {
       int minNum = Int32.MaxValue;
       string answer = "0";
       for(int i=0;i<num.Length-k-1;i++){
            string number = num.Remove(i,k);
            int value = int.Parse(number);
            if(value<minNum){
                minNum = value;
                answer = value.ToString();
            }
       }

       return answer;

    }
}