public class Solution {
    public int MaxArea(int[] height) {
        
        int right=height.Length-1;
        int left=0;
        int maxArea = 0;
        int maxDist = 0;

        while(right>=left){
            
        
                maxDist = right-left;
                maxArea = Math.Max(Math.Min(height[right],height[left])*maxDist,maxArea);
           

           if(height[right]>height[left]){
            left++;
           }
           else{
            right--;
           }

               
        }

        return maxArea;

    }
}