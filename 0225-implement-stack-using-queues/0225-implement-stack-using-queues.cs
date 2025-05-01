public class MyStack {
    private readonly Queue<int> _queue;
    public MyStack() {
        _queue = new Queue<int>();
    }
    
    public void Push(int x) {
        _queue.Enqueue(x);
         int n = _queue.Count;
        for (int i = 0; i < n - 1; i++) {
            _queue.Enqueue(_queue.Dequeue());
        }
    }
    
    public int Pop() {
        return _queue.Dequeue();
    }
    
    public int Top() {
        return _queue.Peek();
    }
    
    public bool Empty() {
        return _queue.Count == 0? true:false;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */