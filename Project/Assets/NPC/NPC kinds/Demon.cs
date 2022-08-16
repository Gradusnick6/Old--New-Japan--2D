using System.Collections.Generic;
using UnityEngine;
using Actions;

[RequireComponent(typeof(StandartHit))]
public class Demon : NPCKind
{
    Animation anim_SHit;
    void Awake()
    {
        health = 150;
        actions = new List<Action>();

        actions[0] = gameObject.GetComponent<StandartHit>();
        actions[0].Initialize(5, 10, anim_SHit);
    }
}