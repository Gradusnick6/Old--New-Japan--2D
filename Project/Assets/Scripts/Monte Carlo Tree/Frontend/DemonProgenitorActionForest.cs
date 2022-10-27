using MonteCarloTree;
using BehaviorSelectors;
using System.Collections.Generic;
using Actions_back;
using UnityEngine;

public class DemonProgenitorActionForest
{
    public ProgenitorActionForest PAF;
    BehaviorSelector bSelector;

    StandartHit sHit;
    HealYourself hYourself;


    public DemonProgenitorActionForest()
    {
        sHit = new StandartHit();
        hYourself = new HealYourself();
        sHit.Initialize(new ActionInfoBox(ActionKind.StandartHit, null, null, 0, 0, 0, null, new Vector3(0, 0, 0)));//значения не играют роли
        hYourself.Initialize(new ActionInfoBox(ActionKind.HealYourself, null, null, null, 40, 40, 3f, null));//значения не играют роли

        List<IAction> actions = new List<IAction>() { sHit, hYourself };
        ActionTree attackTree = new ActionTree(actions, TypeAction.Hit);
        ActionTree defendTree = new ActionTree(actions, TypeAction.Heal);
    
        bSelector = new DemonBS();
        PAF = new ProgenitorActionForest(new List<ActionTree>() { attackTree, defendTree }, bSelector);
    }
}
