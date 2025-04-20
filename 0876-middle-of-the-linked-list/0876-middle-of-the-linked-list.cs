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
    public ListNode MiddleNode(ListNode head) {
        
        int end = 0;
        ListNode currentNode = head;
        while(currentNode.next != null){
            end++;
            currentNode = currentNode.next;
        }

         currentNode = head;
        if(end%2 ==0 ) end = end/2;
        else{
            end = (end+1)/2;
        }
        for(int i=0;i<end;i++){
            currentNode = currentNode.next;
        }

    return currentNode;
    }
}