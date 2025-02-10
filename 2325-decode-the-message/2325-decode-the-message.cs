public class Solution {
    public string DecodeMessage(string key, string message) {
      Dictionary<char, char> substitutionTable = new Dictionary<char, char>();
        HashSet<char> seen = new HashSet<char>();
        char mappedChar = 'a'; // Start mapping from 'a'

        // Build the substitution table from `key`
        foreach (char ch in key) {
            if (ch != ' ' && !seen.Contains(ch)) {
                substitutionTable[ch] = mappedChar;
                seen.Add(ch);
                mappedChar++;
            }
        }

        // Decode the message
        StringBuilder decodedMessage = new StringBuilder();
        foreach (char ch in message) {
            decodedMessage.Append(ch == ' ' ? ' ' : substitutionTable[ch]);
        }

        return decodedMessage.ToString();
    }
}