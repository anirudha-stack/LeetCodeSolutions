public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        
       // 1) Build map for all nums2 elements
        var nextGreater = new Dictionary<int,int>(nums2.Length);
        var stack = new Stack<int>();

        // Scan nums2 from left → right
        foreach (int x in nums2) {
            // Maintain a decreasing stack: whenever the current x is greater
            // than stack.Peek(), we’ve found the “next greater” for that peek.
            while (stack.Count > 0 && stack.Peek() < x) {
                nextGreater[stack.Pop()] = x;
            }
            stack.Push(x);
        }

        // Any elements left in the stack have no greater element
        while (stack.Count > 0) {
            nextGreater[stack.Pop()] = -1;
        }

        // 2) Build the result for nums1 by lookup
        int[] ans = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++) {
            ans[i] = nextGreater[nums1[i]];
        }
        return ans;
    }
}