public class LRUCache {

    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> _cache;
    private readonly LinkedList<(int key, int value)> _usage;

    public LRUCache(int capacity) {
        _capacity = capacity;
        _cache = new Dictionary<int, LinkedListNode<(int, int)>>(capacity);
        _usage = new LinkedList<(int, int)>();
    }

    public int Get(int key) {
        if (!_cache.ContainsKey(key))
            return -1;

        // Move the accessed node to the front (most recently used)
        var node = _cache[key];
        _usage.Remove(node);
        _usage.AddFirst(node);
        return node.Value.value;
    }

    public void Put(int key, int value) {
        if (_cache.ContainsKey(key)) {
            // Update existing value and move it to the front
            var node = _cache[key];
            _usage.Remove(node);
        }
        else if (_cache.Count == _capacity) {
            // Remove least recently used (tail of the list)
            var lru = _usage.Last.Value;
            _cache.Remove(lru.key);
            _usage.RemoveLast();
        }

        // Insert new node at front
        var newNode = new LinkedListNode<(int, int)>((key, value));
        _usage.AddFirst(newNode);
        _cache[key] = newNode;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */