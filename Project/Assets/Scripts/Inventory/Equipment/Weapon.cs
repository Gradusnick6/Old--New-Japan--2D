using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Thing
{
    public Animation anim { protected set; get; }
    public int minDamage { protected set; get; }
    public int maxDamage { protected set; get; }
}
