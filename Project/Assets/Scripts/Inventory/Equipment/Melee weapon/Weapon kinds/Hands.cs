using UnityEngine;
using Actions;

public class Hands : MeleeWeapon
{
    public Action actions { private set; get; }
    public Hands()
    {
        minDamage = 5;
        maxDamage = 10;
        //actions = new StandartHit(minDamage, maxDamage, anim);
    }
}
