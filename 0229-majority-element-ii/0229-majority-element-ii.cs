public class Solution {
    public IList<int> MajorityElement(int[] nums) {

       int allowed = nums.Length/3; 
       Dictionary<int,int> freq = new Dictionary<int,int>();

       for (int i = 0; i < nums.Length; i++) {
    int x = nums[i];
    if (freq.ContainsKey(x))
        freq[x]++;
    else
        freq[x] = 1;
}
 List<int> answer = new List<int>();
       foreach(var num in freq){
       
        if(num.Value > allowed){
            answer.Add(num.Key);
        }
       }

       return answer.ToArray();

    }
}