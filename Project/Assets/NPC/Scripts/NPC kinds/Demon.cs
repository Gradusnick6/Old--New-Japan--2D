using System.Collections.Generic;
using UnityEngine;
using Actions_back;

[CreateAssetMenu(fileName = "Demon", menuName = "CharacterKind/NPCKind/Demon", order = 1)]
public class Demon : NPCKind
{
    private Animation anim_SHit { get; }
    private Animation anim_HealA { get; }

    Demon()
    {
        health = 150;
        Actions = new List<Action>();
    }
    public override void Initialize()
    {
        Actions.Add(new StandartHit());
        Actions[0].Initialize(new ActionInfoBox(ActionKind.StandartHit, aObjCreater, gameObj, 5, 10, 0.6f, anim_SHit, new Vector3(1, 1, 1)));

        Actions.Add(new HealYourself());
        Actions[1].Initialize(new ActionInfoBox(ActionKind.HealYourself, aObjCreater, gameObj, character, 40, 40, 3f, anim_HealA));
    }
}