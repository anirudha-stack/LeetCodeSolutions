class Solution(object):
    def possibleStringCount(self, word):
        """
        Count the number of possible original strings that could
        produce 'word' if Alice ever long-pressed exactly one key
        (or none).
        """
        n = len(word)
        if n == 0:
            return 0

        total = 1      # the “no long-press” case
        run_len = 1

        # scan runs of identical characters
        for i in range(1, n):
            if word[i] == word[i-1]:
                run_len += 1
            else:
                # if this run was potentially long-pressed (run_len>=2),
                # you have (run_len - 1) choices to shrink it.
                if run_len > 1:
                    total += (run_len - 1)
                run_len = 1

        # last run
        if run_len > 1:
            total += (run_len - 1)

        return total
