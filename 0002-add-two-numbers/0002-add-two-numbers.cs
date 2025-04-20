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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode firstRunner = (l1);
        ListNode secondRunner = (l2);

        ListNode answer = new ListNode(0);
      
        ListNode headOfanswer = answer;

        

                int carry = 0;

        while (firstRunner != null || secondRunner != null || carry != 0) {
            int d1 = (firstRunner != null ? firstRunner.val : 0);
            int d2 = (secondRunner != null ? secondRunner.val : 0);

            int sum = d1 + d2 + carry;
            carry   = sum / 10;

            headOfanswer.next = new ListNode(sum % 10);
            headOfanswer      = headOfanswer.next;

            if (firstRunner != null) firstRunner = firstRunner.next;
            if (secondRunner != null) secondRunner = secondRunner.next;
        }
     

        return answer.next;


    }
    
 
}


