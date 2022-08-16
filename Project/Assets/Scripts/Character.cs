using UnityEngine;

public class Character : MonoBehaviour
{
    protected float speed = 3f;
    public int health;
    public void getDamage(int damage)
    {
        health -= damage;
    }
}
