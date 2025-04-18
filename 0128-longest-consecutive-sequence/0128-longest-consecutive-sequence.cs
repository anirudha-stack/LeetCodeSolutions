public class Solution {
    public int LongestConsecutive(int[] nums) {
        
        if(nums.Length == 0) return 0;
        return OofNSolution(nums);
        

    }

    public int OofNSolution(int[] nums){

        HashSet<int> set = new HashSet<int>(nums);
        int maxLen = 0;
    


        foreach(int num in set){
           
            if(!set.Contains(num-1)){
                int currentMax = 0;
                int currentNum = num;

                while(set.Contains(currentNum+1)){

                    currentMax++; // 3
                    currentNum++;
                    if(currentMax > maxLen){
                        maxLen = currentMax; // 3
                    }

                }
            }

        }
        return maxLen + 1;


    }

    public int sortingSolution(int[] nums){
        Array.Sort(nums);



        int maxLen = 0;
        int currentMax = 0;

        for(int i=1;i<nums.Length;i++){
            //1,2,3,4,100,200

            if(nums[i] == nums[i-1]){
                    continue;
            }

            if(nums[i] - nums[i-1] == 1){
                currentMax++; // 3

                if(currentMax > maxLen){
                    maxLen = currentMax; // 3
                }
            }
            else{
                currentMax = 0;
            }

        }

        return maxLen+1;
    }
}