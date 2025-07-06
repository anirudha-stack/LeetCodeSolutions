class Solution(object):
    def findLucky(self, arr: List[int]) -> int:
        max_lucky_number = -1
        for num in arr:
            # Note that arr.count(num) has a cost of $$O(n)$$.
            # It works the same as the algorithm we defined in pseudocode.
            occurences_of_num = arr.count(num)
            # If num is a lucky number, and is the biggest lucky number so far.
            if num == occurences_of_num and num > max_lucky_number:
                max_lucky_number = num
        return max_lucky_number
        