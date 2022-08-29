using UnityEngine;
using MonteCarloTree;

namespace Actions_back
{
    public class HealYourself : Action
    {
        [SerializeField] private Character character;
        private int minHeal;
        private int maxHeal;
        public override void Initialize(ActionInfoBox infoBox)
        {
            kind = infoBox.kind;
            minHeal = infoBox.minHeal;
            maxHeal = infoBox.maxHeal;
            rechargeTime = infoBox.rechargeTime;
            curRechargeTime = rechargeTime;
            anim = infoBox.anim;
        }
        public override double GetLastScore(TypeAction typeActionTree)
        {
            throw new System.NotImplementedException();
        }

        public override TypeAction GetTypeAction()
        {
            return TypeAction.Heal;
        }

        public override void Run()
        {
            if (curRechargeTime >= rechargeTime)
            {
                character.getHeal(Random.Range(minHeal, maxHeal + 1));
                curRechargeTime = 0;
            }
        }
    }
}