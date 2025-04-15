public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
      IList<IList<int>> answer = new List<IList<int>>();
       Array.Sort(nums);

      for(int i=0;i<nums.Length;i++){

        if( i>0 && nums[i] == nums[i-1]) continue;

        for(int j=i+1;j<nums.Length;j++){
             if( j>i+1 && nums[j] == nums[j-1]) continue;

            long sum = nums[i] + nums[j];
            int k = j+1;
            int l = nums.Length-1;

            while(k<l){

              

                if(nums[k]+nums[l] + sum > target){
                    l--;
                }
                else if(nums[k]+nums[l] + sum < target) {
                    k++;
                }
                else{

                    

                    IList<int> currentQuad = new List<int>();
                    currentQuad.Add(nums[i]);
                    currentQuad.Add(nums[j]);
                    currentQuad.Add(nums[k]);
                    currentQuad.Add(nums[l]);
                    if(!answer.Contains(currentQuad)){
                      
                    answer.Add(currentQuad);  
                    }

                    k++;
                    l--;

                    while( k<l && nums[k] == nums[k-1] ) k++;
                    
                    while( k<l && nums[l] == nums[l+1] ) l--;
                }
            }


        }
      }

    return answer;
    }
}