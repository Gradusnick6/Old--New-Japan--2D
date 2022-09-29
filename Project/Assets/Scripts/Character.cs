using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterKind kind;
    private int maxHealth;
    public int currentHealth;
    private void Start()
    {
        maxHealth = kind.health;
        currentHealth = maxHealth;
    }
    public void GetDamage(int damage)
    {
        if (currentHealth > damage)
            currentHealth -= damage;
        else currentHealth = 0;
    }
    public void GetHeal(int amountHealth)
    {
        if (maxHealth < amountHealth + currentHealth)
            currentHealth = maxHealth;
        else currentHealth += amountHealth;
    }
}
