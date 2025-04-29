public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        Array.Sort(nums);
     IList<IList<int>> answer = new List<IList<int>>();

     solver(0,nums,answer, new List<int>());

     return answer;
      

    }

    public void solver(int index, int[] nums, IList<IList<int>> answer, List<int> currentAnswer){

        if(index == nums.Length){
            answer.Add(new List<int>(currentAnswer));
            return;
        }

        //for(int i=index;i<nums.Length;i++){

           
            currentAnswer.Add(nums[index]);
            solver(index+1,nums,answer,currentAnswer);
            currentAnswer.RemoveAt(currentAnswer.Count - 1);
             solver(index+1,nums,answer,currentAnswer);


        //}

        return;
    }
}