class Solution:
    def maxDifference(self, s: str) -> int:
        freq = Counter(s)
        
        odd_freqs = [count for count in freq.values() if count % 2 == 1]
        even_freqs = [count for count in freq.values() if count % 2 == 0]
        
        if not odd_freqs or not even_freqs:
            return -1  # No valid pair

        max_diff = float('-inf')
        for o in odd_freqs:
            for e in even_freqs:
                max_diff = max(max_diff, o - e)
        
        return max_diff

        