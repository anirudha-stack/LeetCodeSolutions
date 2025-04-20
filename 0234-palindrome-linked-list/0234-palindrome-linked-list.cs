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
    public bool IsPalindrome(ListNode head) {
    
        
        if(head == null ||  head.next == null) return true;
        
        
        ListNode slow = head;
        ListNode fast = head;
        
        while(fast != null && fast.next !=  null){
            slow = slow.next;
            fast = fast.next.next;
        }
        
        //slow is now at midpoint. now reverse the second half
        
        ListNode temp = null;
        ListNode prev = null;
        
        while(slow!=null){
            temp = slow.next;
            slow.next = prev;
            prev = slow;
            slow = temp;
        }
        
        while(prev!=null){
            if(prev.val != head.val){
                return false;
            }
            
            
            prev = prev.next;
            head=head.next;
        }
        
        return true;
        
    }
}