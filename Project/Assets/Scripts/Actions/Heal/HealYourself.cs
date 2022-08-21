using UnityEngine;
using MonteCarloTree;

namespace Actions
{
    public class HealYourself : Action
    {
        public override void Initialize_Hit(int minDamage_, int maxDamage_, float rechargeTime_, Animation anim_) { }
        [SerializeField] private Character character;
        private int amountHealth;
        public override void Initialize_Heal(int amountHealth_, float rechargeTime_, Animation anim_) 
        {
            amountHealth = amountHealth_;
            rechargeTime = rechargeTime_;
            curRechargeTime = rechargeTime;

            anim = anim_;
            if (character == null)
                character = GetComponent<Character>();
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
                character.getHeal(amountHealth);
                curRechargeTime = 0;
            }
        }

        public override void Update()
        {
            curRechargeTime += Time.deltaTime;
        }
    }
}