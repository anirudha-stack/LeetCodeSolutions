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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        
     // Create a dummy node to simplify handling the head of the merged list
    ListNode dummy = new ListNode(0);
    ListNode current = dummy;
    
    // Use two pointers to traverse the two lists
    ListNode firstListMover = list1;
    ListNode secondListMover = list2;
    
    // Merge the two lists
    while (firstListMover != null && secondListMover != null) {
        if (firstListMover.val <= secondListMover.val) {
            current.next = firstListMover;
            firstListMover = firstListMover.next;
        } else {
            current.next = secondListMover;
            secondListMover = secondListMover.next;
        }
        current = current.next;
    }
    
    // Attach the remaining nodes (if any)
    if (firstListMover != null) {
        current.next = firstListMover;
    } else {
        current.next = secondListMover;
    }
    
    // Return the head of the merged list (skip the dummy node)
    return dummy.next;
        
    }
}