public class Solution {
    public string MergeAlternately(string word1, string word2) {
        StringBuilder sg = new StringBuilder();
        int runner = 0;
        while(runner < word1.Length && runner < word2.Length){
            sg.Append(word1[runner]);
            sg.Append(word2[runner]);
            runner++;
        }

        if(runner < word1.Length){
           while(runner < word1.Length ){
            sg.Append(word1[runner]);
            runner++;
            } 
        }
        else if(runner < word2.Length){
           while(runner < word2.Length ){
            sg.Append(word2[runner]);
            runner++;
            } 
        }

        return sg.ToString();
    }
}