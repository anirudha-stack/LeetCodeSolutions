public class MinStack {
    private readonly Stack<int> _stack;
    private readonly LinkedList<int> _deque;
    public MinStack() {
        _stack = new Stack<int>();
        _deque = new LinkedList<int>();
    }
    
    public void Push(int val) {
        _stack.Push(val);

        if( _deque.Count >0){
            if( val < _deque.First()){
                _deque.AddFirst(val);
            }else{
                _deque.AddLast(val);

            }
        }
        else{
           _deque.AddFirst(val); 
        }

        
    }
    
    public void Pop() {
        int val = _stack.Peek();
        _stack.Pop();

        if( val == _deque.First()){
            _deque.RemoveFirst();
        }else{
             _deque.RemoveLast();

        }
    }
    
    public int Top() {
        return _stack.Peek();
    }
    
    public int GetMin() {
        return _deque.First();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */