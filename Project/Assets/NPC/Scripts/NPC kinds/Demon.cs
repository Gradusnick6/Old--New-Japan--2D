using System.Collections.Generic;
using UnityEngine;
using Actions_back;
using MonteCarloTree;
using ProgenitorActionForests;

[CreateAssetMenu(fileName = "Demon", menuName = "CharacterKind/NPCKind/Demon", order = 1)]
public class Demon : NPCKind
{
    private Animation anim_SHit { get; }
    private Animation anim_HealA { get; }
    public static ProgenitorActionForest pActionForest = null;
    [SerializeField] private ProgenitorActionForestStorage pAFS;

    public override void Initialize()
    {
        health = 150;

        List<IAction> actions = new List<IAction>();
        actions.Add(new StandartHit());
        actions[0].Initialize(new ActionInfoBox(ActionKind.StandartHit, aObjCreater, gameObj, 5, 10, 0.6f, anim_SHit, new Vector3(1, 1, 1)));

        actions.Add(new HealYourself());
        actions[1].Initialize(new ActionInfoBox(ActionKind.HealYourself, aObjCreater, gameObj, character, 40, 40, 3f, anim_HealA));

        aForest = new ActionForest(pAFS.demonPAF.PAF);
        aForest.actionTrees[0].SwapActions(actions);
        aForest.actionTrees[1].SwapActions(actions);
    }
}