public class Solution {
    public bool IsSubsequence(string s, string t) {
        
        int start = 0;
        
        
        if(s.Length>t.Length  ) return false;

        if(s.Length ==0 ) return true;


        for(int i=0;i<t.Length;i++){
            if(s[0] == t[i]){
                start = i;
                break;
            }
        }

        for(int i=start;i<t.Length;i++){

            if(start<s.Length && s[start] == t[i]){
                start++;
            }

        }

        if(start == s.Length) return true;
        else return false;

    }
}