public class StockSpanner {
     // Each entry is (price, span)
    private readonly Stack<(int price, int span)> _stack;

    public StockSpanner() {
        _stack = new Stack<(int price, int span)>();
    }
    
    public int Next(int price) {
        int span = 1;
        
        // Absorb all previous spans whose prices are ≤ today's
        while (_stack.Count > 0 && _stack.Peek().price <= price) {
            span += _stack.Pop().span;
        }
        
        // Now push today’s price + its computed span
        _stack.Push((price, span));
        return span;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */