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
        private ActionStorage actionStorage;
        private GameObject characterObj;
        private GameObject hitArea;
        private Collider2D hitCollider;
        private Collider2D characterCollider;
        int minDamage;
        int maxDamage;
        public override void Initialize(ActionInfoBox infoBox)
        {
            isRun = true;

            if (infoBox.typeAction == TypeAction.Hit)
            {
                kind = infoBox.kind;
                minDamage = infoBox.minDamage;
                maxDamage = infoBox.maxDamage;
                rechargeTime = infoBox.rechargeTime;
                curRechargeTime = rechargeTime;

                characterObj = infoBox.gameObj;
                anim = infoBox.anim;
                aObjCreater = infoBox.aObjCreator;
                hitAreaScale = infoBox.hitAreaScale;

                SetHitAreaObj();
                hitArea.transform.localScale = hitAreaScale;
                hitCollider = hitArea.GetComponent<Collider2D>();

                characterCollider = characterObj.GetComponent<Collider2D>();

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
            if (isRun)
            {
                isRun = false;

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
                        target.GetComponent<Character>().GetDamage(targetDamage);
                }

                RechargeDelay();
            }
        }
        /// <summary>
        /// Инициализирует hitArea объектом StandartHitArea
        /// Если такой объект отсутсвует в иерархии объекта, то создает его
        /// </summary>
        public void SetHitAreaObj()
        {
            if (hitArea == null)
                hitArea = characterObj.transform.Find("StandartHitArea").gameObject;
            if (hitArea == null)
                hitArea = aObjCreater.CreatePrefab(Resources.Load<GameObject>(actionStorage.GetResourcesPath(kind)));
                
        }
    }
}