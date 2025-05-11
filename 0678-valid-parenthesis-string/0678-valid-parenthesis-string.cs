public class Solution {
    public bool CheckValidString(string s) {
        if(s == null || s.Length ==0 || s.Length ==1) return false;
        Stack<char> stack = new Stack<char>();

        foreach(var ch in s){

            if(ch == ')'){
                char check = stack.Pop();
               if(!(check == '(' || check == '*')) {
                return false;
               }
            }
            else{
            stack.Push(ch);

            }
             


        }

        return true;
    }
}