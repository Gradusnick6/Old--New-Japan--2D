using UnityEngine;

namespace ProgenitorActionForests
{
    [CreateAssetMenu(fileName = "PAForest_Storage", menuName = "MonteCarloTree/ProgenitorActionForestStorage", order = 1)]
    public class ProgenitorActionForestStorage : ScriptableObject
    {
        public DemonProgenitorActionForest demonPAF;

        public ProgenitorActionForestStorage()
        {
            demonPAF = new DemonProgenitorActionForest();
        }
    }
}