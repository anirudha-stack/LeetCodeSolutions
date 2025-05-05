public class KthLargest {
    private readonly int _k;
    private readonly PriorityQueue<int,int> _minHeap;

    public KthLargest(int k, int[] nums) {
         _k      = k;
        _minHeap = new PriorityQueue<int,int>();

        // Seed the heap with initial numbers
        foreach (var x in nums) {
            _minHeap.Enqueue(x, x);
            if (_minHeap.Count > _k)
                _minHeap.Dequeue();
        }
    }
    
    public int Add(int val) {
         // Add new value
        _minHeap.Enqueue(val, val);
        // If we exceed k elements, remove the smallest
        if (_minHeap.Count > _k)
            _minHeap.Dequeue();
        // The top of the min‐heap is now the kth largest
        _minHeap.TryPeek(out int kthLargest, out _);
        return kthLargest;
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */