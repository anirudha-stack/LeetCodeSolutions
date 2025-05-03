public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (nums == null || k <= 0) 
            return Array.Empty<int>();

        int n = nums.Length;
        int[] result = new int[n - k + 1];
        // We'll store indices in a LinkedList to act as our deque
        var deque = new LinkedList<int>();

        for (int i = 0; i < n; i++) {
            // 1) Remove indices that are out of this window
            while (deque.Count > 0 && deque.First.Value < i - k + 1) {
                deque.RemoveFirst();
            }

            // 2) Pop smaller values from the back—
            //    they can't ever be the max if nums[i] is bigger
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) {
                deque.RemoveLast();
            }

            // 3) Add current index to the back
            deque.AddLast(i);

            // 4) Starting at i = k-1, the front of the deque is the window max
            if (i >= k - 1) {
                result[i - k + 1] = nums[deque.First.Value];
            }
        }

        return result;
    }
}
