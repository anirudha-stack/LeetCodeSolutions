public class Solution {
    // Doubly‐linked‐list node
    private class Node {
        public char c;
        public Node prev, next;
        public Node(char c) { this.c = c; }
    }
    
    public string ClearStars(string s) {
        // 1) Setup: head<->…<->tail sentinel doubly‐linked list
        Node head = new Node('\0'), tail = new Node('\0');
        head.next = tail;
        tail.prev = head;
        
        // 2) For each letter 'a'..'z', keep a stack of Nodes in the list:
        var buckets = new List<Node>[26];
        for (int i = 0; i < 26; i++)
            buckets[i] = new List<Node>();
        
        // 3) Process each character
        foreach (char ch in s) {
            if (ch != '*') {
                // insert new node before tail
                var nd = new Node(ch);
                nd.prev = tail.prev;
                nd.next = tail;
                tail.prev.next = nd;
                tail.prev = nd;
                
                // record it in the bucket
                buckets[ch - 'a'].Add(nd);
            }
            else {
                // find the smallest non‐empty bucket
                for (int i = 0; i < 26; i++) {
                    var bucket = buckets[i];
                    if (bucket.Count > 0) {
                        // take the rightmost occurrence of that char
                        var toRemove = bucket[bucket.Count - 1];
                        bucket.RemoveAt(bucket.Count - 1);
                        
                        // unlink it from the DLL
                        toRemove.prev.next = toRemove.next;
                        toRemove.next.prev = toRemove.prev;
                        break;
                    }
                }
                // (we drop the '*' by not inserting it)
            }
        }
        
        // 4) Build result from the linked list
        var sb = new StringBuilder();
        for (var cur = head.next; cur != tail; cur = cur.next)
            sb.Append(cur.c);
        return sb.ToString();
    }
}