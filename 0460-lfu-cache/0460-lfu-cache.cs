public class LFUCache {
    private readonly int _capacity;
    private int _minFreq;
    
    // Key → Node wrapper
    private readonly Dictionary<int, Node> _cache;
    // Frequency → Doubly-linked list of Nodes with that frequency
    private readonly Dictionary<int, LinkedList<Node>> _freqMap;

    public LFUCache(int capacity) {
        _capacity = capacity;
        _minFreq   = 0;
        _cache     = new Dictionary<int, Node>(capacity);
        _freqMap   = new Dictionary<int, LinkedList<Node>>();
    }

    public int Get(int key) {
        if (!_cache.TryGetValue(key, out var node))
            return -1;
        
        // Move node up one frequency bucket
        UpdateFrequency(node);
        return node.Value;
    }

    public void Put(int key, int value) {
        if (_capacity == 0) return;

        if (_cache.TryGetValue(key, out var existing)) {
            // Update value and bump frequency
            existing.Value = value;
            UpdateFrequency(existing);
        }
        else {
            // Evict if at capacity
            if (_cache.Count == _capacity) {
                // Remove LRU from lowest-frequency list
                var list = _freqMap[_minFreq];
                var lru  = list.First.Value;
                list.RemoveFirst();
                _cache.Remove(lru.Key);
            }

            // Insert new node at freq = 1
            var node = new Node(key, value);
            _cache[key] = node;
            if (!_freqMap.ContainsKey(1))
                _freqMap[1] = new LinkedList<Node>();
            _freqMap[1].AddLast(node.ListNode);
            
            _minFreq = 1;
        }
    }

    private void UpdateFrequency(Node node) {
        int freq = node.Freq;
        var oldList = _freqMap[freq];

        // Remove from old frequency list
        oldList.Remove(node.ListNode);
        if (oldList.Count == 0) {
            _freqMap.Remove(freq);
            if (_minFreq == freq)
                _minFreq++;
        }

        // Add to new frequency list
        node.Freq++;
        if (!_freqMap.ContainsKey(node.Freq))
            _freqMap[node.Freq] = new LinkedList<Node>();
        _freqMap[node.Freq].AddLast(node.ListNode);
    }

    // Internal wrapper storing key, value, frequency, and its ListNode
    private class Node {
        public int Key { get; }
        public int Value { get; set; }
        public int Freq  { get; set; }
        public LinkedListNode<Node> ListNode { get; }

        public Node(int key, int value) {
            Key       = key;
            Value     = value;
            Freq      = 1;
            ListNode  = new LinkedListNode<Node>(this);
        }
    }
}
