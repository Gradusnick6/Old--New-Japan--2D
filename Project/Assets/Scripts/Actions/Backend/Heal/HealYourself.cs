using UnityEngine;
using MonteCarloTree;

namespace Actions_back
{
    public class HealYourself : Action
    {
        private Character character;
        private int minHeal;
        private int maxHeal;
        public override void Initialize(ActionInfoBox infoBox)
        {
            isRun = true;

            kind = infoBox.kind;
            character = infoBox.character;
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
            if (isRun)
            {
                isRun = false;
                character.GetHeal(Random.Range(minHeal, maxHeal + 1));
                curRechargeTime = 0;
                RechargeDelay();
            }
        }
    }
}