public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        
        HashSet<int> firstSet = new HashSet<int>(nums1);

        HashSet<int> secondSet = new HashSet<int>(nums2);

         List<int> answer0 = new List<int>();
        foreach (int num in firstSet) {
            if (!secondSet.Contains(num)) {
                answer0.Add(num);
            }
        }

        // Find elements in nums2 but not in nums1
        List<int> answer1 = new List<int>();
        foreach (int num in secondSet) {
            if (!firstSet.Contains(num)) {
                answer1.Add(num);
            }
        }

        return new List<IList<int>> { answer0, answer1 };







    }
}