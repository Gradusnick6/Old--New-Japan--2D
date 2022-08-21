using UnityEngine;
using MonteCarloTree;

namespace Actions
{
    public abstract class Action : MonoBehaviour
    {
        protected Animation anim;
        /// <summary>
        /// перезарядка действия в секундах
        /// </summary>
        protected float rechargeTime;
        /// <summary>
        /// время прошедшее с последнего использования действия
        /// </summary>
        protected float curRechargeTime;
        public abstract void Initialize_Heal(int amountHealth, float rechargeTime_, Animation anim_);// { }
        public abstract void Initialize_Hit(int minDamage_, int maxDamage_, float rechargeTime_, Animation anim_);// { }

        /// <summary>
        /// Возврат типа действия
        /// </summary>
        /// <returns>Тип действия</returns>
        public abstract TypeAction GetTypeAction();

        /// <summary>
        /// Последний счёт действия
        /// </summary>
        /// <param name="typeActionTree">Тип дерева</param>
        /// <returns></returns>
        public abstract double GetLastScore(TypeAction typeActionTree);

        /// <summary>
        /// Запуск действия
        /// </summary>
        /// <returns>Счёт действия</returns>
        public abstract void Run();
        /// <summary>
        /// отсчёт перезарядки
        /// </summary>
        public abstract void Update();
    }
}