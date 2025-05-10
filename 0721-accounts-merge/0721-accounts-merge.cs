public class Solution {

    public class DSU {

        public Dictionary<int,int> parent = new Dictionary<int,int>();
        
        public Dictionary<int,int> rank = new Dictionary<int,int>();

        public void createDSU(int n){
            for(int i=0;i<n;i++){
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int findParent(int node){
            if(node == parent[node]) return node;
            return parent[node] = findParent(parent[node]);
        }


        public void unionByRank(int v,int u){
            int pu = findParent(u);
            int pv = findParent(v);

            if(rank[pu]<rank[pv]){
                parent[pv] = pu;
            }
            else if(rank[pv]<rank[pu]){
                parent[pu] = pv;
            }
            else{
                  parent[pu] = pv;
                  rank[pv]++;
            }
        }


    }




    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        DSU dsu = new DSU();
        dsu.createDSU(accounts.Count);
        Dictionary<string,int> map = new Dictionary<string,int>();

        for(int i=0;i<accounts.Count;i++){

            for(int j=1;j<accounts[i].Count;j++){
                string mail = accounts[i][j];
                if(!map.ContainsKey(mail)){
                    map.Add(mail,i);
                }
                else{
                    dsu.unionByRank(i,map[mail]);
                }
            }
        }


        Dictionary<int, List<string>> merged = new Dictionary<int, List<string>>();

        foreach (var kvp in map) {
            string email = kvp.Key;
            int idx = kvp.Value;
            int root = dsu.findParent(idx);

            if (!merged.ContainsKey(root))
                merged[root] = new List<string>();
            merged[root].Add(email);
        }


        List<IList<string>> result = new List<IList<string>>();

        foreach (var kvp in merged) {
            int index = kvp.Key;
            List<string> emails = kvp.Value;
            emails.Sort(StringComparer.Ordinal); 
            
            List<string> mergedAccount = new List<string>();
            mergedAccount.Add(accounts[index][0]);
            mergedAccount.AddRange(emails);

            result.Add(mergedAccount);
        }

        return result;
    }
}