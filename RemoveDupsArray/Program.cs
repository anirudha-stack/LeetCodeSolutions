using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }; // Input array
            Console.WriteLine("nums is :" + string.Join(", ", nums));


            int k = RemoveDuplicates(nums); // Calls your implementation

            
            Console.WriteLine("k is :" + k);

            Console.WriteLine("altered nums is :" + string.Join(", ", nums));

        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            List<int> cleanedList = new List<int>();    

            List<int> ListNums = nums.ToList();
            int index = 0;
            foreach (int num in ListNums)
            {
                if (!cleanedList.Contains(num))
                {
                    cleanedList.Add(num);
                    nums[index] = num;
                     index++;

                }

            }
            
            return cleanedList.Count;
        }
    }
}