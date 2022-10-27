using System.Collections.Generic;
using MonteCarloTree;
using UnityEngine;
using System.Threading.Tasks;


namespace Actions_back
{
    public class StandartHit : Action
    {
        /// <summary>
        /// размер зоны коллайдера для удара
        /// </summary>
        private Vector3 hitAreaScale;
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

                if (characterObj != null)
                    if (hitArea == null)
                    {
                        hitArea = characterObj.transform.Find("StandartHitArea").gameObject;
                        characterCollider = characterObj.GetComponent<Collider2D>();
                        hitArea.transform.localScale = hitAreaScale;
                    }
                if (aObjCreater != null)
                    if (hitArea == null)
                    {
                        hitArea = aObjCreater.CreatePrefab(Resources.Load<GameObject>(ActionResources.GetResourcesPath(kind)));
                        hitArea.transform.localScale = hitAreaScale;
                    }

                if (hitArea != null)
                    hitCollider = hitArea.GetComponent<Collider2D>();

                if (hitCollider != null && characterCollider != null)
                Physics2D.IgnoreCollision(hitCollider, characterCollider, true);
            }
        }
        public override double GetLastScore(TypeAction typeActionTree)
        {
            return 1;
        }
        public override TypeAction GetTypeAction()
        {
            return TypeAction.Hit;
        }

        public override bool Run()
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
                return true;
            }
            return false;
        }
    }
}