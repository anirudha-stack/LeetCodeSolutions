public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var totalAnswer = new List<IList<int>>();
        var currentAnswer = new List<int>();
         helper(0,currentAnswer,totalAnswer,nums);

        return totalAnswer;
    }

    public void helper(int index,List<int> currentAnswer,IList<IList<int>> totalAnswer, int[] nums){

        if(index > nums.Length-1){
            totalAnswer.Add(new List<int>(nums));
            return;
        }

        for(int i=index;i<nums.Length;i++){

            swap(i,index,nums);
           // currentAnswer.Add(nums[i]);
            helper(index+1,currentAnswer,totalAnswer,nums);
            //currentAnswer.RemoveAt(currentAnswer.Count-1);
            swap(i,index,nums);

        }

        return;

    }

    private void swap(int left, int right, int[] nums){

        if(right<nums.Length-1){
        int temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
        }
       

    }
}