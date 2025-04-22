public class Solution {
    public string CountAndSay(int n) {
        return rle_encode(n);
    }

    public string rle_encode(int n){
        
        if(n == 1) return "1";

        
        string answer = "";

        string s = rle_encode(n-1);

        for(int i=0;i<s.Length;i++){
           

            int count = 1;
            int j = i+1;
            while(j<s.Length && s[i]==s[j]){
                count++;
                j++;
            }
            answer+=count;
            answer+=s[i];
            i=j-1;

        }

        return answer;
    }
}