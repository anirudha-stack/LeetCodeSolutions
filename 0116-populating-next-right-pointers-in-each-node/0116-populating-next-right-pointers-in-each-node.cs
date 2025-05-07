/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
         if (root == null) return null;
        
        // Start at the leftmost node of the current level
        Node leftmost = root;
        
        // Since it's perfect, if leftmost.left != null, there is another level below
        while (leftmost.left != null) {
            // Walk across this level
            Node head = leftmost;
            while (head != null) {
                // 1) Link its two children
                head.left.next = head.right;
                
                // 2) If there's a next parent on this level, link right child → next.left
                if (head.next != null) {
                    head.right.next = head.next.left;
                }
                
                head = head.next;
            }
            // Go down one level
            leftmost = leftmost.left;
        }
        
        return root;


    }

   }