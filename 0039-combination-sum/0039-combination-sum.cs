public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> totalAnswer = new List<IList<int>>();
        List<int> currentAnswer = new List<int>();

        summer(0,target,totalAnswer,currentAnswer,candidates);

        return totalAnswer;
    }

    public void summer(int index,int target,IList<IList<int>> totalAnswer,List<int> currentAnswer,int[] nums){


        if( target == 0) {
            totalAnswer.Add(new List<int>(currentAnswer));
            
            return;
        }
        if (index == nums.Length || target < 0) {
            return;
        }


        summer(index+1,target,totalAnswer,currentAnswer,nums);

        currentAnswer.Add(nums[index]);
        summer(index,target-nums[index],totalAnswer,currentAnswer,nums);
         currentAnswer.RemoveAt(currentAnswer.Count -1);

        return;
    }
}