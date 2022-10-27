using Actions_back;


namespace MonteCarloTree
{
    public interface IAction
    {
        /// <summary>
        /// Возврат типа действия
        /// </summary>
        /// <returns>Тип действия</returns>
        TypeAction GetTypeAction();

        /// <summary>
        /// Последний счёт действия
        /// </summary>
        /// <param name="typeActionTree">Тип дерева</param>
        /// <returns></returns>
        double GetLastScore(TypeAction typeActionTree);

        /// <summary>
        /// Запуск действия
        /// </summary>
        /// <returns>Счёт действия</returns>
        bool Run();

        void Initialize(ActionInfoBox infoBox);
    }
}
