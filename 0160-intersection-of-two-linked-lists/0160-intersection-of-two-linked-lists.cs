/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {

        int len1 = 0;
        int len2 = 0;

        ListNode dum1 = headA;
        ListNode dum2 = headB;


        if(dum1 == dum2) return dum1;

        while(dum1 != null){
            len1++;
            dum1 = dum1.next;
        }
        while(dum2 != null){
            len2++;
            dum2 = dum2.next;
        }
       


        dum1 = headA;
        dum2 = headB;
        int diff = Math.Abs(len2-len1);
        

           for(int i=0;i< diff;i++){
            if(len2>len1){
                dum2 = dum2.next;
            }
            else{
                dum1 = dum1.next;
            }
           }


           while(dum1 != null || dum2 != null){
         if(dum1 == dum2 ){
                return dum1;
            }
    

            dum2 = dum2.next;
            dum1 = dum1.next;

               
           }

        return null;


    }
}