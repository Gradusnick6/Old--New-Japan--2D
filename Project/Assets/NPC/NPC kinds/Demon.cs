using System.Collections.Generic;
using UnityEngine;
using Actions;

[RequireComponent(typeof(StandartHit))]
[RequireComponent(typeof(HealYourself))]
public class Demon : NPCKind
{
    Animation anim_SHit;
    Animation anim_HealA;

    void Awake()
    {
        health = 150;
        actions = new List<Action>();

        GetComponents(actions);
        actions[0].Initialize_Hit(5, 10, 0.6f, anim_SHit);
        actions[1].Initialize_Heal(40, 3f, anim_HealA);
    }
}