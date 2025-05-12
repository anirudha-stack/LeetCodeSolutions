public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
          // Step 1: Count frequencies
        Dictionary<string, int> freq = new();
        foreach (string word in words)
            freq[word] = freq.GetValueOrDefault(word, 0) + 1;

        // Step 2: Min-heap (priority queue)
        // Custom priority: 
        //   lower frequency = higher priority (to pop first)
        //   if freq equal => lexicographically *greater* word = higher priority (so correct ones stay)
        var pq = new PriorityQueue<string, WordPriority>();

        foreach (var entry in freq) {
            pq.Enqueue(entry.Key, new WordPriority(entry.Key, entry.Value));
            if (pq.Count > k)
                pq.Dequeue();  // Remove the least relevant
        }

        // Step 3: Extract in reverse order
        var result = new List<string>();
        while (pq.Count > 0) {
            result.Add(pq.Dequeue());
        }
        result.Reverse(); // Since we want highest freq first
        return result;
    }

    private record struct WordPriority(string Word, int Frequency) : IComparable<WordPriority>
    {
        public int CompareTo(WordPriority other)
        {
            // Min-heap: lower frequency is higher priority
            if (this.Frequency != other.Frequency)
                return this.Frequency.CompareTo(other.Frequency);

            // For same frequency: reverse lexicographical (so that lexically *larger* words come first in min-heap)
            return -this.Word.CompareTo(other.Word);
        }
    }
}