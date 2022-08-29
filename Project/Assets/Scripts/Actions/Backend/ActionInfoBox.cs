using MonteCarloTree;
using UnityEngine;

namespace Actions_back
{
    public class ActionInfoBox
    {
        //Общие параметры
        public float rechargeTime;
        public TypeAction typeAction;
        public Animation anim;
        public ActionKind kind;

        //Параметры для действия "Удар"
        public int minDamage, maxDamage;
        public Vector3 hitAreaScale;

        //Параметры для действия "Лечение"
        public int minHeal, maxHeal;




        /// <summary>
        /// Конструктор действия "Удар"
        /// </summary>
        /// <param name="kind_">вид удара</param>
        /// <param name="minDamage_">минимальный урон от удара</param>
        /// <param name="maxDamage_">максимальный урон от удара</param>
        /// <param name="rechargeTime_">время перезарядки действия в секундах</param>
        /// <param name="anim_">анимация действия</param>
        /// <param name="hitAreaScale_">размер зоны коллайдера для удара</param>
        public ActionInfoBox(ActionKind kind_, int minDamage_, int maxDamage_, float rechargeTime_, Animation anim_, Vector3 hitAreaScale_)
        {
            typeAction = TypeAction.Hit;
            minDamage = minDamage_;
            maxDamage = maxDamage_;
            rechargeTime = rechargeTime_;
            anim = anim_;
            hitAreaScale = hitAreaScale_;
            kind = kind_;
        }

        /// <summary>
        /// Конструктор действия "Лечение"
        /// </summary>
        /// <param name="kind_">вид лечения</param>
        /// <param name="minHeal_">минимальное количество восполняемых очков здоровья</param>
        /// <param name="maxHeal_">максимальный количество восполняемых очков здоровья</param>
        /// <param name="rechargeTime_">время перезарядки действия в секундах</param>
        /// <param name="anim_">анимация действия</param>
        public ActionInfoBox(ActionKind kind_, int minHeal_, int maxHeal_, float rechargeTime_, Animation anim_)
        {
            typeAction = TypeAction.Heal;
            minHeal = minHeal_;
            maxHeal = maxHeal_;
            rechargeTime = rechargeTime_;
            anim = anim_;
            kind = kind_;
        }
    }
}