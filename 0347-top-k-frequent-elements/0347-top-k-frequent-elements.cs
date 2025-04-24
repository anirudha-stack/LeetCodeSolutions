public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freq = new Dictionary<int,int>();
        foreach (var x in nums) freq[x] = freq.GetValueOrDefault(x) + 1;

        // Min-heap of size k: we push (num, freq) with priority = freq
        var heap = new PriorityQueue<int,int>();
        foreach (var kv in freq) {
            heap.Enqueue(kv.Key, kv.Value);
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }

   // The k most frequent elements remain in the heap
        var res = new int[k];
        for (int i = k - 1; i >= 0; i--) {
            res[i] = heap.Dequeue();
        }
        return res;


    }
}