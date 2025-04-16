public class Solution {
    public int[] SortArray(int[] nums) {
        
        return MergeSort(nums);
    }

    private int[] BubbleSort(int[] nums){

         int n = nums.Length;
        int j=0;
        while(j <n){

           

            for(int i=1;i<n-j;i++){
//Console.WriteLine($"Checking {nums[i-1]} , {nums[i]}");
                    
                if(nums[i-1] > nums[i]){
                    //Console.WriteLine($"Swapping {nums[i-1]} , {nums[i]}");
                    int temp = nums[i];
                    nums[i] = nums[i-1];
                    nums[i-1] = temp;
                }

            
        }
            j++;
        }
        return nums;
    }


    private int[] MergeSort(int[] nums){
        int n= nums.Length;


       return  DivideAndMerge(nums,0, n-1);


    }

    private int[] DivideAndMerge(int[] nums, int low, int high){
        //Console.WriteLine($"Checking {nums[low]} , {nums[high]}");
         if(low == high) {
            return new int[] { nums[low] }; // Return a single-element array
         }

        int[] leftHalf =  DivideAndMerge(nums, low, (low+high)/2 );
        int[] rightHalf =  DivideAndMerge(nums, (low+high)/2 + 1 ,high);
         nums = Merge(leftHalf,rightHalf);
        return nums;
    }

    private int[] Merge(int[] left, int[] right){

        
        List<int> merged = new List<int>();
    int i = 0, j = 0;

    while (i < left.Length && j < right.Length)
    {
        if (left[i] <= right[j])
        {
            merged.Add(left[i]);
            i++;
        }
        else
        {
            merged.Add(right[j]);
            j++;
        }
    }

    // Append any remaining elements
    while (i < left.Length)
    {
        merged.Add(left[i++]);
    }

    while (j < right.Length)
    {
        merged.Add(right[j++]);
    }

    return merged.ToArray();
    }


    private int[] InsertionSort(int[] nums){
         int n = nums.Length;

         int size = 1;

        while(size<n){
         for(int i=0; i<size;i++){

            for(int j=size; j>0;j--){
               // Console.WriteLine($"Checking {nums[j-1]} , {nums[j]}");
                if(nums[j] < nums[j-1]){
                    int temp = nums[j];
                    nums[j] = nums[j-1];
                    nums[j-1] = temp;
                }
            }
           
         }
      //    if(size < n)
            size++;
        }
         
        return nums;
    }
    private int[] SelectionSort(int[] nums){
        int n = nums.Length;

        for (int i = 0; i < n - 1; i++)
        {
            // Find the index of the minimum element in the unsorted part
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] < nums[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap the found minimum element with the first element of the unsorted part
            if (minIndex != i)
            {
                int temp = nums[i];
                nums[i] = nums[minIndex];
                nums[minIndex] = temp;
            }
        }

        return nums;
    }
}