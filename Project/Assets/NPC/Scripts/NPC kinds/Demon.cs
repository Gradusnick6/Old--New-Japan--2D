using System.Collections.Generic;
using UnityEngine;
using Actions_back;

[CreateAssetMenu(fileName = "Demon", menuName = "CharacterKind/NPCKind/Demon", order = 1)]
public class Demon : NPCKind
{
    Animation anim_SHit;
    Animation anim_HealA;

    Demon()
    {
        health = 150;
        actions = new List<Action>();
    }
    public override void Initialize()
    {
        actions.Add(new StandartHit());
        actions[0].Initialize(new ActionInfoBox(ActionKind.StandartHit, aObjCreater, gameObj, 5, 10, 0.6f, anim_SHit, new Vector3(1, 1, 1)));

        actions.Add(new HealYourself());
        actions[1].Initialize(new ActionInfoBox(ActionKind.HealYourself, aObjCreater, gameObj, character, 40, 40, 3f, anim_HealA));
    }
}