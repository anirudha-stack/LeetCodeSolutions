public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        var finalAnswer =  new List<IList<int>>();
        var currentAnswer = new List<int>();

        subsetSolver(0,finalAnswer,currentAnswer,nums);
        return finalAnswer;

    
    }

    public void subsetSolver(int index,IList<IList<int>> totalAnswer,List<int> currentAnswer,int[] nums){
       
        totalAnswer.Add(new List<int>(currentAnswer));

        for(int i=index;i<nums.Length;i++){
            //if(!currentAnswer.Contains(nums[i]))
            if(i != index && nums[i] == nums[i-1]) continue;
            currentAnswer.Add(nums[i]);
            subsetSolver(i+1,totalAnswer,currentAnswer,nums);
            currentAnswer.Remove(nums[i]);

        }


        return;


    }
}