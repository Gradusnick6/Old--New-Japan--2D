using UnityEngine;

[CreateAssetMenu(fileName = "Warrior", menuName = "CharacterKind/PlayerKind/Warrior", order = 2)]
public class Warrior : PlayerKind
{
    private void Awake()
    {
        health = 150;
    }
}
