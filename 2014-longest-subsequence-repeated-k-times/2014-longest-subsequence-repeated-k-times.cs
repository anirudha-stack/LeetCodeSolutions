public class Solution {
    public string LongestSubsequenceRepeatedK(string s, int k) {
        int[] freq = new int[26];
        foreach (char ch in s) {
            freq[ch - 'a']++;
        }

        List<char> candidate = new List<char>();
        for (int i = 25; i >= 0; i--) {
            if (freq[i] >= k) {
                candidate.Add((char)('a' + i));
            }
        }

        Queue<string> q = new Queue<string>();
        foreach (char ch in candidate) {
            q.Enqueue(ch.ToString());
        }

        string ans = "";
        while (q.Count > 0) {
            string curr = q.Dequeue();
            if (curr.Length > ans.Length) {
                ans = curr;
            }
            // generate the next candidate string
            foreach (char ch in candidate) {
                string next = curr + ch;
                if (IsKRepeatedSubsequence(s, next, k)) {
                    q.Enqueue(next);
                }
            }
        }

        return ans;
    }

    private bool IsKRepeatedSubsequence(string s, string t, int k) {
        int pos = 0, matched = 0;
        int m = t.Length;
        foreach (char ch in s) {
            if (ch == t[pos]) {
                pos++;
                if (pos == m) {
                    pos = 0;
                    matched++;
                    if (matched == k) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}