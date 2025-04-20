public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
      
        IList<IList<int>> answer = new List<IList<int>>();

        Array.Sort(nums);

           
        for(int i=0;i<nums.Length;i++){
            
            if(i > 0 && nums[i] == nums[i-1]) continue;
            int j = i+1;

           
            int k = nums.Length-1;

            while(j<k){

              // Console.WriteLine($"Working with {nums[i]} {nums[j]} {nums[k]}");
            long sum = nums[i]+nums[j]+nums[k] ;
                if(sum == 0){
                    
                    List<int> trio = new List<int> { nums[i],nums[j],nums[k] };

                    if(!answer.Contains(trio)){
                        answer.Add(trio);
                    }
                    j++;
                    k--;

                    while(j<k && nums[j] ==  nums[j-1]) j++;
                    
                    while(j<k && nums[k] ==  nums[k+1]) k--;

                }
                else if( sum < 0){
                    j++;
                }
                else{
                    k--;
                }
            }
                       //   Console.WriteLine($"j = {j} and k = {k} so moving to i");

        }
       
        return answer;
    }
}