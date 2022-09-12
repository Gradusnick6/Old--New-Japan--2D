using System.Collections.Generic;
using UnityEngine;
using Actions_back;

public class NPCController : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private ActionObjectCreater aObjCreater;
    [SerializeField] private NPCKind kind;
    private List<Action> actions;

    void Start()
    {
        if (aObjCreater == null) aObjCreater = transform.Find("ActionObjectCreater").GetComponent<ActionObjectCreater>();
        kind.aObjCreater = aObjCreater;

        kind.gameObj = gameObject;

        if (character == null) character = transform.GetComponent<Character>();
        kind.character = character;

        actions = new List<Action>();
        actions = kind.actions;

        kind.Initialize();
    }
    void Update()
    {
        for (int i = 0; i < actions.Count; i++)
            actions[i].Run();
    }
}