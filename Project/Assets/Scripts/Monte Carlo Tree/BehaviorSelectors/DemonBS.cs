using MonteCarloTree;
using System.Collections.Generic;

namespace BehaviorSelectors
{
    public class DemonBS : BehaviorSelector
    {
        private enum TreeType
        {
            PROTECTION,
            ATTACK
        }
        public List<int> ScoreTrees;
        public DemonBS() { }
        public DemonBS(DemonBS demonBS)
        {

        }
        private int GetIndexMaxScoreTree()
        {
            int maxScore = ScoreTrees[0], index = 0;
            for (int i = 1; i < ScoreTrees.Count; i++)
            {
                int scoreTree = ScoreTrees[i];
                if (scoreTree > maxScore)
                {
                    maxScore = scoreTree;
                    index = i;
                }
            }
            return index;
        }
        public override int GetIndexNextTree()
        {

            return 0;
        }
        public override BehaviorSelector GetCloneBehaviorSelector()
        {
            return new DemonBS(this);
        }
    }
}