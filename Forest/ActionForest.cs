using System;
using System.Collections.Generic;
using System.Text;

namespace MonteCarloTree
{
    [Serializable]
    public class ActionForest : ProgenitorActionForest
    {
        /// <summary>
        /// Дерево родитель
        /// </summary>
        private ProgenitorActionForest progenitorActionForest;

        public ActionForest() : base() { progenitorActionForest = null; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="progenitorActionForest_">Дерево родитель</param>
        /// <param name="actionTrees_">Список деревьев</param>
        /// <param name="choiseActionTrees">Функция переключателя между деревьями</param>
        public ActionForest(ProgenitorActionForest progenitorActionForest_) 
            : base(progenitorActionForest_.actionTrees, progenitorActionForest_.GetCloneBehaviorSelector())
        {
            progenitorActionForest = new ProgenitorActionForest();
            progenitorActionForest = progenitorActionForest_;
        }

        /// <summary>
        /// Запуск следующего действия
        /// </summary>
        /// <returns>Индекс выбранного дерева</returns>
        public int Start()
        {
            LastActiveTree = behaviorSelector.GetIndexNextTree();
            if (LastActiveTree != -1) actionTrees[LastActiveTree].Start();
            return LastActiveTree;
        }

        /// <summary>
        /// Передача инофрмации лесу родителю
        /// </summary>
        public void InformationTransfer()
        {
            for (int i = 0; i < actionTrees.Count; i++)
            {
                ActionTree actionTree = actionTrees[i];
                actionTree.InformationTransfer(progenitorActionForest.actionTrees[i]);
            }
        }


    }
}
