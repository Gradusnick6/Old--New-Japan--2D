using System.Collections.Generic;
using MonteCarloTree;
using UnityEngine;
using Actions_front;


namespace Actions_back
{
    public class StandartHit : Action
    {
        /// <summary>
        /// размер зоны коллайдера для удара
        /// </summary>
        private Vector3 hitAreaScale;
        [SerializeField] private ActionStorage actionStorage;
        [SerializeField] private GameObject characterObj;
        [SerializeField] private GameObject hitArea;
        [SerializeField] private Collider2D hitCollider;
        [SerializeField] private Collider2D characterCollider;

        int minDamage;
        int maxDamage;
        public override void Initialize(ActionInfoBox infoBox)
        {
            if (infoBox.typeAction == TypeAction.Hit)
            {
                kind = infoBox.kind;
                minDamage = infoBox.minDamage;
                maxDamage = infoBox.maxDamage;
                rechargeTime = infoBox.rechargeTime;
                curRechargeTime = rechargeTime;

                anim = infoBox.anim;
                hitAreaScale = infoBox.hitAreaScale;

                CreatHitAreaObj();
                hitArea.transform.localScale = hitAreaScale;

                Physics2D.IgnoreCollision(hitCollider, characterCollider, true);
            }
        }
        public override double GetLastScore(TypeAction typeActionTree)
        {
            throw new System.NotImplementedException();
        }
        public override TypeAction GetTypeAction()
        {
            return TypeAction.Hit;
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
        /// <summary>
        /// Инициализирует hitArea объектом StandartHitArea
        /// Если такой объект отсутсвует в иерархии объекта, то создает его
        /// </summary>
        public void CreatHitAreaObj()
        {
            if (hitArea == null)
                hitArea = characterObj.transform.Find("StandartHitArea").gameObject;
            if (hitArea == null)
                hitArea = Instantiate(Resources.Load<GameObject>(actionStorage.GetResourcesPath(kind)), characterObj.transform);
        }
    }
}