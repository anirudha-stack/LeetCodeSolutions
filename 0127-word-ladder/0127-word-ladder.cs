public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> wordSet = new(wordList);
        Queue<(string,int)> queue = new();
        HashSet<string> map = new();
        queue.Enqueue((beginWord,1));
        int answer = 0;

        while(queue.Count>0){

            var (word,level) = queue.Dequeue();
            if (word == endWord) return level;
            if(map.Contains(word)) continue;


            map.Add(word);
            answer = level;
            for(int i=0;i<word.Length;i++){
                char[] arr = word.ToCharArray();
                char original = arr[i];

                for (char ch = 'a'; ch <= 'z'; ch++) {
                    if (ch == original) continue;
                    arr[i] = ch;
                    string newWord = new string(arr);

                    if (wordSet.Contains(newWord)) {
                        queue.Enqueue((newWord, level + 1));
                    }
                }
                arr[i] = original; // restore original letter
            }
           

        }


        
        return 0;


    }
}