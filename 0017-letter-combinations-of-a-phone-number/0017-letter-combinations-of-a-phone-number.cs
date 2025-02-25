public class Solution {

    static Dictionary<char, string> keypad = new Dictionary<char, string>() {
            {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"},
            {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}
        };

    public IList<string> LetterCombinations(string digits) {
        if (string.IsNullOrEmpty(digits)) return new List<string>();

        
         List<string> answer = new  List<string>();
         backtrack(digits,0,"",answer);


         return answer;
      


    }

    public void backtrack( string digits,int index, string currentString, List<string> answer)
    {
        if(index == digits.Length){
            answer.Add(currentString);
            return;
        }

        char  currentDigit = digits[index];
        if (!keypad.ContainsKey(currentDigit)) return;

        string keypadletters = keypad[currentDigit];

        foreach(var letter in keypadletters){
            backtrack(digits,index+1,currentString+letter,answer);
        }

    }
}