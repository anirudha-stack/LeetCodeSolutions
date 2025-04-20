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
    public ListNode RotateRight(ListNode head, int k) {
        
        if(head == null || head.next == null || k==0){
            return head;
        }
    


      ListNode tail = head;
        int len = 1;
        while (tail.next != null) {
        tail = tail.next;
        len++;
        }

       // Console.WriteLine($"{len}");

        tail.next = head;

          // 3) find the new tail: (len - k%len)-th node
    k %= len;
    int stepsToNewTail = len - k;
    ListNode newTail = head;
    for (int i = 1; i < stepsToNewTail; i++) {
        newTail = newTail.next;
    }

    // 4) break and return
    ListNode newHead = newTail.next;
    newTail.next = null;
    return newHead;
    }
}