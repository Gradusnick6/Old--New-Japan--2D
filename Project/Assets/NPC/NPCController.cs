using System.Collections.Generic;
using UnityEngine;
using Actions;

public class NPCController : MonoBehaviour
{
    [SerializeField] private NPCKind kind;
    private List<Action> actions;

    void Start()
    {
        actions = new List<Action>();
        GetComponents(actions);
    }
    void Update()
    {
        for (int i = 0; i < actions.Count; i++)
            actions[i].Run();
    }
}