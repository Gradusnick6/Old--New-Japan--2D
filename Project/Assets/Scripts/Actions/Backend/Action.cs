using UnityEngine;
using MonteCarloTree;
using System.Threading.Tasks;

namespace Actions_back
{
    public abstract class Action : IAction
    {
        protected ActionObjectCreater aObjCreater;
        /// <summary>
        /// Определяет возможность выполнения действия
        /// true - действие выполнимо; false - действие недоступно
        /// </summary>
        public bool isRun { protected set; get; }
        /// <summary>
        /// Тип персонажа, который является владельцем действия
        /// Для особых врагов или боссов используется имя
        /// </summary>
        protected string ownerName;
        /// <summary>
        /// Уровень владельца действия
        /// </summary>
        protected int ownerLevel;
        protected ActionKind kind;
        public Animation anim;
        /// <summary>
        /// перезарядка действия в секундах
        /// </summary>
        protected float rechargeTime;
        /// <summary>
        /// время прошедшее с последнего использования действия
        /// </summary>
        protected float curRechargeTime;


        public abstract void Initialize(ActionInfoBox infoBox);
        public abstract TypeAction GetTypeAction();
        public abstract double GetLastScore(TypeAction typeActionTree);
        public abstract bool Run();
        /// <summary>
        /// Возвращает конкатенацию полей имени и уровня владельца
        /// </summary>
        /// <returns>"ИмяУровень"</returns>
        protected string GetOwnerFullName()
        {
            return ownerName + ownerLevel.ToString();
        }

        /// <summary>
        /// По прошествии времени перезарядки присвает isRun значение true;
        /// </summary>
        protected async void RechargeDelay()
        {
            await Task.Delay((int)(rechargeTime * 1000));
            isRun = true;
        }
    }
}