public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        IList<IList<int>> answer = new List<IList<int>>();
        Array.Sort(nums);
        int n = (int)Math.Pow(2, nums.Length);

        for(int X=0;X<n;X++){
        var picked = new List<int>();
            for (int i = 0; i < nums.Length; i++) {
                // check if bit i of X is 1
                if ( ((X >> i) & 1) == 1 ) {
                    picked.Add(nums[i]);
                }
            }

            if(!answer.Any(existing => existing.SequenceEqual(picked))){
                answer.Add(picked);
            }

        }

        return answer;
    
    }
}