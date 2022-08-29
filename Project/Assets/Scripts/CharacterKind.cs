using UnityEngine;

public class CharacterKind : ScriptableObject
{
    [SerializeField] public int health { protected set; get; }
    [SerializeField] public float speed = 3f;
    /// <summary>
    /// Для особых врагов или боссов используется имя
    /// Для рядовых тип
    /// </summary>
    protected string characterType;
    /// <summary>
    /// Уровень персонажа
    /// </summary>
    protected string characterLevel;

}