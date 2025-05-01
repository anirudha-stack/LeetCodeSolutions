public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
        int n = nums1.Length;
        int m = nums2.Length;
        int[] arr = new int[n+m];

        int run1 = 0;
        int run2 = 0;
        int index = 0;

        while(run1<n && run2<m){
            if(nums1[run1] < nums2[run2]){
                arr[index] = nums1[run1];
                run1++;
                index++;

                //if(run1>n)
            }
            else{
                arr[index] = nums2[run2];
                run2++;
                index++;
            }
        }

        while(run1<n){
            arr[index] = nums1[run1];
            index++;
            run1++;
        }
        while(run2<m){
            arr[index] = nums2[run2];
            index++;
            run2++;
        }

        int total = arr.Length;

        if(total%2!=0){
            return arr[total/2];
        }
        else{
            return ((float)(arr[total/2] + arr[(total/2) -1])/2);
        }

    }
}