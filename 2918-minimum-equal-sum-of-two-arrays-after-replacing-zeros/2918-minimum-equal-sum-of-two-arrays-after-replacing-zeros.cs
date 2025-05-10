public class Solution {
    public long MinSum(int[] nums1, int[] nums2) {
        
        List<int> zerosNum1 = new List<int>();
        long sum1 = 0;
        long sum2 = 0;
        List<int> zerosNum2 = new  List<int>();

        for(int i=0;i<nums1.Length;i++){
            if(nums1[i] == 0){
                zerosNum1.Add(i);;
                nums1[i] = 1;
            }
            sum1+= nums1[i];

        }

        for(int i=0;i<nums2.Length;i++){
            if(nums2[i] == 0){

                zerosNum2.Add(i);
                nums2[i] = 1;
            }
            sum2+= nums2[i];

        }



        if(sum1 == sum2) return sum2;
      
        //if(sum1 != sum2 && (zerosNum2.Count == 0 || zerosNum1.Count ==0 )) return -1;
        
        if(sum1 < sum2 && zerosNum1.Count >0 ) return sum2;
        if(sum1 > sum2 && zerosNum2.Count >0 ) return sum1;


        return -1;
        


    }
}