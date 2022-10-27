using MonteCarloTree;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterKind kind;
    private ActionForest aForest;

    private int maxHealth;
    public int currentHealth;
    private void Start()
    {
        maxHealth = kind.health;
        currentHealth = maxHealth;

        aForest = kind.aForest;
    }
    public void GetDamage(int damage)
    {
        if (currentHealth > damage)
            currentHealth -= damage;
        else Death();
    }
    public void GetHeal(int amountHealth)
    {
        if (maxHealth < amountHealth + currentHealth)
            currentHealth = maxHealth;
        else currentHealth += amountHealth;
    }
    void Death()
    {
        if (aForest != null) aForest.InformationTransfer();
        Destroy(gameObject);
    }
}
