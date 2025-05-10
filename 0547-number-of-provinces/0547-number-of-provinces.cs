public class Solution {

    public class DSU(){

        public Dictionary<int,int> parent =  new Dictionary<int,int>();

        public Dictionary<int,int> rank =  new Dictionary<int,int>();


        public void createDSU(int[][] graph){
            for(int i=0;i<graph.Length;i++){
                parent[i] = i;
                rank[i]=0;
            }
        }

        public int findParent(int node){
            if(node == parent[node]) return node;

            return parent[node] = findParent(parent[node]);
        }

        public void unionByRank(int v, int u){
            int pu = findParent(u);
            int pv = findParent(v);

            if(rank[pu] < rank[pv]){
                parent[pu] = pv;
            }
            else if(rank[pv] < rank[pu]){
                parent[pv] = pu;
            }
            else{
                   parent[pv] = pu;
                   rank[pu]++;
            }
        }

    }


    public int FindCircleNum(int[][] isConnected) {
        
        DSU dsu =  new DSU();

        dsu.createDSU(isConnected);

        for(int i=0;i<isConnected.Length;i++){
              for(int j=0;j<isConnected[0].Length;j++){
               if(isConnected[i][j] == 1){
                    dsu.unionByRank(i,j);
               }       
            }
        }

        HashSet<int> uniqueParents = new HashSet<int>();
        for(int i=0;i<isConnected.Length;i++){
            if(!uniqueParents.Contains(dsu.findParent(i))){
                uniqueParents.Add(dsu.findParent(i));
            }
        }

        return uniqueParents.Count;



    }
}