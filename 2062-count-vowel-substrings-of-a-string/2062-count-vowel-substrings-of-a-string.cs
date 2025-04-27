public class Solution {
    public int CountVowelSubstrings(string word) {

         int ans = 0;
        
        int la = -1, le = -1, li = -1, lo = -1, lu = -1;
    
        int lastCons = -1;

        for (int i = 0; i < word.Length; i++) {
            char c = word[i];
            switch (c) {
                case 'a': la = i; break;
                case 'e': le = i; break;
                case 'i': li = i; break;
                case 'o': lo = i; break;
                case 'u': lu = i; break;
                default:
                    // Hit a consonant—reset the window
                    lastCons = i;
                    // Invalidate vowel positions so future min(...) ≤ lastCons
                    la = le = li = lo = lu = -1;
                    continue;
            }

            // Find the earliest of the five last–seen vowel indices
            int earliestVowel = Math.Min(
                Math.Min(la, le),
                Math.Min(Math.Min(li, lo), lu)
            );

            // If we've now seen all five (earliestVowel ≥ 0),
            // then any substring that starts in (lastCons, ..., earliestVowel]
            // and ends exactly at i is a valid vowel substring.
            if (earliestVowel > lastCons) {
                ans += earliestVowel - lastCons;
            }
        }

        return ans;
    }
}