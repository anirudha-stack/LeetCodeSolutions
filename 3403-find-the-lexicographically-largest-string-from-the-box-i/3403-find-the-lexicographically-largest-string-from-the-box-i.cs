public class Solution {
    public string AnswerString(string word, int numFriends) {
        if (numFriends == 1)
            return word;

        string res = "";
        int length = word.Length - numFriends + 1;

        for (int i = 0; i < word.Length; i++) {
            string temp;
            if (i + length <= word.Length)
                temp = word.Substring(i, length);
            else
                temp = word.Substring(i); // till end

            if (string.Compare(temp, res, StringComparison.Ordinal) > 0)
                res = temp;
        }

        return res;
    }
}
