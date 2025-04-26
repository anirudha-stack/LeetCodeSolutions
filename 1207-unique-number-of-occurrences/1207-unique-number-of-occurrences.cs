public class Solution {
    public bool UniqueOccurrences(int[] arr) {
       Dictionary<int, int> freqMap = new Dictionary<int, int>();
        foreach (int num in arr) {
            if (!freqMap.ContainsKey(num)) {
                freqMap[num] = 0;
            }
            freqMap[num]++;
        }

        HashSet<int> seenFrequencies = new HashSet<int>();
        foreach (int freq in freqMap.Values) {
            if (!seenFrequencies.Add(freq)) {
                return false; // frequency already exists
            }
        }

        return true;

    }
}