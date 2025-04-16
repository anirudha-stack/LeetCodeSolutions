public class Solution {
    public int MajorityElement(int[] nums) {
        int majorityOcc = nums.Length/2;
        int answer = 0;
        Dictionary<int,int> freq = new Dictionary<int,int>();
       foreach (int num in nums)
     {
        if (freq.ContainsKey(num))
            freq[num]++;
        else
            freq[num] = 1;

        if (freq[num] > majorityOcc)
        {
           answer = num;
            break;
        }
        
      }
    return answer;
    }
}