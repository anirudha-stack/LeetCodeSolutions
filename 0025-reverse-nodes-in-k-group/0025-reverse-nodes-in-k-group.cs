/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
      
     // 1) Dummy so we can easily reverse at the very front:
        var dummy = new ListNode(0, head);
        var groupPrev = dummy;

        while (true) {
            // 2) Find the k-th node after groupPrev
            var kth = GetKth(groupPrev, k);
            if (kth == null) break;               // fewer than k nodes remain

            var groupNext = kth.next;             // node after this k-group

            // 3) Reverse exactly the nodes [groupPrev.next ... kth]
            reverseSlice(groupPrev.next, kth);

            // 4) Re‑link the reversed block
            //    old head is now the tail of the block
            var tmp        = groupPrev.next;
            groupPrev.next = kth;                 // new head of this block
            tmp.next       = groupNext;           // connect tail to remainder

            // 5) Move groupPrev to the tail (tmp) to prepare for next iteration
            groupPrev = tmp;
        }

        return dummy.next;
    }

    // Advances `curr` by k steps (not counting curr itself),
    // returns the node you land on, or null if you run out.
    private ListNode GetKth(ListNode curr, int k) {
        while (curr != null && k > 0) {
            curr = curr.next;
            k--;
        }
        return curr;
    }

    // Reverses the slice [start ... end], inclusive,
    // assuming end.next is the node you should link to after reversal.
    private void reverseSlice(ListNode start, ListNode end) {
        ListNode prev = end.next;
        var curr = start;
        while (prev != end) {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
    }

    // (Optional) helper to print the list for debugging:
    public void PrintList(ListNode head) {
        var curr = head;
        while (curr != null) {
            Console.Write(curr.val);
            if (curr.next != null) Console.Write(" -> ");
            curr = curr.next;
        }
        Console.WriteLine();
    }
}
