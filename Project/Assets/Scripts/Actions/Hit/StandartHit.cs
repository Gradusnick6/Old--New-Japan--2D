using System.Collections.Generic;
using MonteCarloTree;
using UnityEngine;

namespace Actions
{
    public class StandartHit : Action
    {
        public override void Initialize_Heal(int amountHealth, float rechargeTime_, Animation anim_) { }
        [SerializeField] private GameObject hitArea;
        [SerializeField] private Collider2D hitCollider;
        [SerializeField] private Collider2D characterCollider;

        int minDamage;
        int maxDamage;
        public override void Initialize_Hit(int minDamage_, int maxDamage_, float rechargeTime_, Animation anim_)
        {
            minDamage = minDamage_;
            maxDamage = maxDamage_;
            rechargeTime = rechargeTime_;
            curRechargeTime = rechargeTime;

            anim = anim_;

            if (transform.Find("StandartHitArea") == null)
                hitArea = Instantiate(Resources.Load<GameObject>("HitAreas/StandartHitArea"), transform);
            else hitArea = transform.Find("StandartHitArea").gameObject;

            if (hitCollider == null)
                hitCollider = hitArea.GetComponent<Collider2D>();

            if (characterCollider == null)
                characterCollider = GetComponent<Collider2D>();

            IgnoreCollision();
        }
        /// <summary>
        /// Обозначение игнорирования коллайдеров зоны поражения и персонажала-владельца этого действия
        /// </summary>
        protected void IgnoreCollision()
        {
            Collider2D parent = GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(hitCollider, parent, true);
        }
        public override double GetLastScore(TypeAction typeActionTree)
        {
            throw new System.NotImplementedException();
        }
        public override TypeAction GetTypeAction()
        {
            return TypeAction.Damage;
        }

        public override void Run()
        {
            if (curRechargeTime >= rechargeTime)
            {
                ContactFilter2D characterCF = new ContactFilter2D().NoFilter();
                characterCF.SetLayerMask(LayerMask.GetMask("Character"));

                int targetDamage;
                targetDamage = Random.Range(minDamage, maxDamage + 1);

                Collider2D hitAreaCollider = hitArea.GetComponent<Collider2D>();
                List<Collider2D> targets = new List<Collider2D>();
                hitAreaCollider.OverlapCollider(characterCF, targets);

                foreach (Collider2D target in targets)
                {
                    if (characterCollider != target)
                        target.GetComponent<Character>().getDamage(targetDamage);
                }

                curRechargeTime = 0;
            }

        }

        public override void Update()
        {
            curRechargeTime += Time.deltaTime;
        }
    }
}