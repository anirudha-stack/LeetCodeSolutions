using System;
using System.Collections.Generic;

public class Solution {
    public int MinimumDeletions(string word, int k) {
        // 1) Count character frequencies
        int[] freq = new int[26];
        foreach (char c in word)
            freq[c - 'a']++;

        // 2) Collect only the non-zero freqs and sort them
        var counts = new List<int>(26);
        foreach (int f in freq)
            if (f > 0) counts.Add(f);
        counts.Sort();

        int n = counts.Count;
        if (n == 0) return 0;         // empty string

        // 3) Sliding-window over sorted counts
        int totalSum       = word.Length;   // sum of all counts
        int deletedLeftSum = 0;             // sum of counts we've “deleted” on the left
        int sumInWindow    = 0;             // sum of counts in [i..j)
        int j              = 0;
        int best           = int.MaxValue;

        for (int i = 0; i < n; i++) {
            int from = counts[i];
            int to   = from + k;

            // expand right pointer while counts[j] ≤ to
            while (j < n && counts[j] <= to) {
                sumInWindow += counts[j];
                j++;
            }

            // everything right of j must be reduced down to ≤ to
            int rightCount    = n - j;
            int sumRight      = totalSum - sumInWindow;
            int deleteRight   = sumRight - (rightCount * to);

            // total deletions = those we “deleted” on the left + those on the right
            best = Math.Min(best, deletedLeftSum + deleteRight);

            // move i out of the window (i.e. “delete” counts[i] entirely)
            totalSum       -= counts[i];
            deletedLeftSum += counts[i];
            sumInWindow    -= counts[i];
        }

        return best;
    }
}
