public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        int[] sortedArr = (int[] )nums.Clone();
        Array.Sort(sortedArr);
        int answer = 0;
        int firstIndex = -1;
        int lastIndex = 0;
        for(int i=0;i<nums.Length;i++){
            if(nums[i] != sortedArr[i]){
                    if(firstIndex ==-1){
                        firstIndex = i;
                       Console.WriteLine($"First mismatch at {firstIndex}");
                    }
                   lastIndex = i;
                   
                        Console.WriteLine($"Last mismatch at {lastIndex}");
            }
        }

        if(lastIndex == 0 && firstIndex ==-1 ) return 0;

        return (lastIndex - firstIndex) + 1;
    }
}