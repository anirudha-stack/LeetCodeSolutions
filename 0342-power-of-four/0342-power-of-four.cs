public class Solution {
    public bool IsPowerOfFour(int n) {
        int residue=n;
        if(n==1) return true;
        while(n>0){
            residue = residue%4;
            n = n/4;
        }

        if(residue>0) return false;
        else return true;

    }
}