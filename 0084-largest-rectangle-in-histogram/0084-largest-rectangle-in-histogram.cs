public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length;
        if (n == 0) return 0;

        int[] nse = NextSmallerIndexToRight(heights);
        int[] pse = PrevSmallerIndexToLeft (heights);

        int maxArea = 0;
        for (int i = 0; i < n; i++) {
            // width = rightIndex – leftIndex – 1
            int width = nse[i] - pse[i] - 1;
            int area  = width * heights[i];
            maxArea   = Math.Max(maxArea, area);
        }
        return maxArea;
    }

    // For each i, find the first index j>i such that heights[j]<heights[i], or n if none
    private int[] NextSmallerIndexToRight(int[] heights) {
        int n = heights.Length;
        int[] nse = new int[n];
        var st = new Stack<int>();  // will store indices

        for (int i = n - 1; i >= 0; i--) {
            while (st.Count > 0 && heights[st.Peek()] >= heights[i]) {
                st.Pop();
            }
            nse[i] = st.Count > 0 ? st.Peek() : n;
            st.Push(i);
        }

        return nse;
    }

    // For each i, find the last index j<i such that heights[j]<heights[i], or -1 if none
    private int[] PrevSmallerIndexToLeft(int[] heights) {
        int n = heights.Length;
        int[] pse = new int[n];
        var st = new Stack<int>();  // will store indices

        for (int i = 0; i < n; i++) {
            while (st.Count > 0 && heights[st.Peek()] >= heights[i]) {
                st.Pop();
            }
            pse[i] = st.Count > 0 ? st.Peek() : -1;
            st.Push(i);
        }

        return pse;
    }
}
