public class Solution {
    public IList<int> GetRow(int rowIndex) {
         List<int> answer = new List<int>();
         long value = 1;

         for(int i=0;i<=rowIndex;i++){
            answer.Add(value);

            value = value * (rowIndex-i)/(k+1);
         }

         return answer.ToArray();
    }


}