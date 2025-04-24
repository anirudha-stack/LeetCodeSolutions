public class Solution {
    public IList<IList<string>> Partition(string s) {
        var answer = new List<IList<string>>();
        var curr = new List<string>();
        answer =  helper(answer,curr,0,s);
        return answer;
    }

    public List<IList<string>> helper(List<IList<string>> response, List<string> currentAnswer, int index,string s){

        if(index == s.Length)
        {
           response.Add(new List<string>(currentAnswer));
            return response;
        }

        for(int i=index;i < s.Length;i++){
            if(isPalindrome(s,index,i)){
                
                currentAnswer.Add(s.Substring(index,i - index + 1));
                response = helper(response,currentAnswer,i+1,s);
                currentAnswer.RemoveAt(currentAnswer.Count - 1);
                
            }
        }
        return response;
    }


    public bool isPalindrome(string s, int start,int end){
        while(start<=end){
            if(s[start++] != s[end--]){
                return false;
            }

        }
        return true;
    }
}