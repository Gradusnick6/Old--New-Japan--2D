﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MonteCarloTree
{
    [Serializable]
    public class ActionTree : Node
    {
        /// <summary>
        /// Общее количество выполненных действий в дереве
        /// </summary>
        private uint amountOfAction;
        /// <summary>
        /// Суммарный счёт использованых узлов
        /// </summary>
        [NonSerialized] private double generalScore;
        /// <summary>
        /// Глубина дерева
        /// </summary>
        protected int treeDepth;

        public ActionTree() : base()
        {
            amountOfAction = 0;
            generalScore = 0;
            treeDepth = 1;
            nodeDepth = 0;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="followingActions_">Список действий для последующих узлов</param>
        /// <param name="typeBehavior_">Тип поведения узла</param>
        /// <param name="nodeDepth_">Глубина узла</param>
        public ActionTree(List<IAction> followingActions_, TypeAction typeBehavior_) : this()
        {
            followingActions = new List<IAction>(followingActions_);
            sheets = new List<ActionBranch>(followingActions.Count);
            for (int i = 0; i < followingActions.Count; i++)
            {
                sheets.Add(null);
            }
            typeBehavior = typeBehavior_;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="actionTree">Копируемый объект</param>
        public ActionTree(ActionTree actionTree) : this(actionTree.followingActions, actionTree.typeBehavior)
        {
            amountOfAction = actionTree.amountOfAction;
            treeDepth = actionTree.treeDepth;
            for (int i = 0; i < actionTree.sheets.Count; i++)
            {
                ActionBranch sheet = actionTree.sheets[i];
                if (sheet != null) sheets[i] = new ActionBranch(sheet);
                else sheets[i] = null;
            }
        }

        /// <summary>
        /// Вернуть максимальную глубину дерева
        /// </summary>
        /// <returns>Максимальную глубина дерева</returns>
        public override int GetMaxDepth()
        {
            if (nodeDepth > 0) return nodeDepth;
            if (IsAnySheets())
            {
                int max = 0;
                foreach (ActionBranch sheet in sheets)
                {
                    if (sheet != null)
                    {
                        int current = sheet.GetMaxDepth();
                        if (max < current)
                        {
                            max = current;
                        }
                    }
                }
                nodeDepth = max;
                return nodeDepth;
            }
            else
            {
                nodeDepth = 0;
                return nodeDepth;
            }
        }

        /// <summary>
        /// Возвращает общее количество выполненных действий у узла и у последющих узлов
        /// </summary>
        /// <returns>Общее количество выполненных действий у узла и у последющих узлов</returns>
        public override uint GetAmountOfAction()
        {
            uint sumNumberOfGames = 0;
            foreach (ActionBranch sheet in sheets)
            {
                if (sheet != null)
                {
                    sumNumberOfGames += sheet.GetAmountOfAction();
                }
            }
            return sumNumberOfGames;
        }

        /// <summary>
        /// Возвращает общий счёт узла и последющих узлов
        /// </summary>
        /// <returns>Общее счёт узла и последющих узлов</returns>
        public override double GetGeneralScore()
        {
            generalScore = 0;
            if (indexNextNode != -1)
            {
                generalScore += sheets[indexNextNode].GetGeneralScore();
            }
            return generalScore;
        }

        /// <summary>
        /// Повысить количество выйгрышных использований у использованных узлов
        /// </summary>
        public override void WinningGameUpgrade()
        {
            if (indexNextNode != -1)
            {
                sheets[indexNextNode].WinningGameUpgrade();
            }
        }

        /// <summary>
        /// Передача инофрмации деревьям в лес-родитель
        /// </summary>
        /// <param name="actionTree">дерево леса-родителя</param>
        /// /// <param name="GeneralScore">Общий рейтинг дерева</param>
        public void InformationTransfer(ActionTree actionTree)
        {
            WinningGameUpgrade();
            GetGeneralScore();
            if (treeDepth > actionTree.treeDepth)
            {
                actionTree.treeDepth = treeDepth;
            }
            if (indexNextNode == -1)
            {
                return;
            }
            else if (actionTree.sheets[indexNextNode] != null)
            {
                sheets[indexNextNode].InformationTransfer(actionTree.sheets[indexNextNode], generalScore);
            }
            else
            {
                actionTree.sheets[indexNextNode] = new ActionBranch(sheets[indexNextNode]);
                actionTree.sheets[indexNextNode].ClearIndexNextNode();
                actionTree.followingActions[indexNextNode] = null;
                sheets[indexNextNode].InformationTransfer(actionTree.sheets[indexNextNode], generalScore, false);
            }
            actionTree.amountOfAction = actionTree.GetAmountOfAction();
        }

        /// <summary>
        /// Запуск следующего действия
        /// </summary>
        public bool Start()
        {
            if (indexNextNode == -1)
            {
                indexNextNode = ChoiseSheet(amountOfAction, ref treeDepth);
            }
            return sheets[indexNextNode].Start(ref amountOfAction, ref treeDepth);
        }
        public override IAction GetLastUsedAction()
        {
            if (indexNextNode == -1)
            {
                return null;
            }
            else return sheets[indexNextNode].GetLastUsedAction();
        }
    }
}
