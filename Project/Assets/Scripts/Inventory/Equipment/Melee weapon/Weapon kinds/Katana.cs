using UnityEngine;
using Actions;

public class Katana : MeleeWeapon
{
    public Action actions { private set; get; }
    public Katana() 
    {
        minDamage = 20;
        maxDamage = 30;
        //actions = new StandartHit(minDamage, maxDamage, anim);
    }
}
