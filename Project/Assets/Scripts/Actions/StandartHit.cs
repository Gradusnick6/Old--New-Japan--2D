using System.Collections.Generic;
using MonteCarloTree;
using UnityEngine;

namespace Actions
{
    public class StandartHit : Action
    {
        private GameObject hitArea;
        int minDamage;
        int maxDamage;
        public override void Initialize(int minDamage_, int maxDamage_, Animation anim_)
        {
            minDamage = minDamage_;
            maxDamage = maxDamage_;

            anim = anim_;

            hitArea = Resources.Load("StandartHitArea", typeof(GameObject)) as GameObject;
            Instantiate(hitArea, transform);
        }
        public override double GetLastScore(TypeAction typeActionTree)
        {
            throw new System.NotImplementedException();
        }

        public override TypeAction GetTypeAction()
        {
            return TypeAction.Damage;
        }

        public override void Start()
        {
            ContactFilter2D enemyCF = new ContactFilter2D();
            enemyCF.layerMask = LayerMask.GetMask("Character");
            int targetDamage;

            Collider2D hitAreaCollider = hitArea.GetComponent<PolygonCollider2D>();
            List<Collider2D> targets = new List<Collider2D>();
            hitAreaCollider.OverlapCollider(enemyCF, targets);
            foreach (Collider2D target in targets)
            {
                targetDamage = Random.Range(minDamage, maxDamage + 1);
                target.gameObject.GetComponent<Character>().getDamage(targetDamage);
            }
        }
    }
}