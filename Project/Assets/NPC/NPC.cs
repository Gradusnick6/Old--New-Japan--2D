using System.Collections.Generic;
using UnityEngine;
using Actions;

public class NPC : Character
{
    [SerializeField] private NPCKind kind;
    private List<Action> actions;

    void Start()
    {
        health = kind.health;
        setActions(kind.actions);
    }
    void Update()
    {
        actions[0].Start();
    }

    /// <summary>
    /// добавляет к списку actions объекты из списка actions_
    /// </summary>
    private void setActions(List<Action> actions_)
    {
        foreach (Action action in actions_)
        {
            actions.Add(action);

        }
    }


}