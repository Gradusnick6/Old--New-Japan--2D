using MonteCarloTree;
using UnityEngine;

namespace Actions
{
    public abstract class Action : MonoBehaviour
    {
        protected Animation anim;

        public abstract void Initialize(int minDamage_, int maxDamage_, Animation anim_);

        public abstract TypeAction GetTypeAction();

        public abstract double GetLastScore(TypeAction typeActionTree);

        public abstract void Start();
    }
}