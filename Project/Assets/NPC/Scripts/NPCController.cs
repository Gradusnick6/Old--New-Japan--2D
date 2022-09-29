using System.Collections.Generic;
using UnityEngine;
using Actions_back;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    //Movement
    private View eyes;
    [SerializeField] private NavMeshAgent agent;
    private GameObject targetObj;
    private Vector3 curTargetPos;

    //Actions
    [SerializeField] private Character character;
    [SerializeField] private ActionObjectCreater aObjCreater;
    [SerializeField] private NPCKind kind;
    private List<Action> actions;


    void Start()
    {
        ActionsInitialize();
        MovementInitialize();
    }

    void Update()
    {
        RotateSprites();
        if (eyes.IsFindTarget())
        {
            setTargetObj(eyes.TargetObj);
            agent.SetDestination(curTargetPos);
        }

        eyes.DrawViewState();


        //for (int i = 0; i < actions.Count; i++)
        //    actions[i].Run();
    }
    private void ActionsInitialize()
    {
        if (aObjCreater == null) aObjCreater = transform.Find("ActionObjectCreater").GetComponent<ActionObjectCreater>();
        kind.aObjCreater = aObjCreater;

        kind.gameObj = gameObject;

        if (character == null) character = transform.GetComponent<Character>();
        kind.character = character;

        actions = new List<Action>();
        actions = kind.Actions;

        kind.Initialize();
    }
    private void MovementInitialize()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        eyes = new View(gameObject, 45f, 7f, 3f);
    }
    
    /// <summary>
    /// Поворачивает объект
    /// </summary>
    private void RotateSprites() 
    {
        if (transform.position.x < curTargetPos.x)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (transform.position.x > curTargetPos.x)
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    void setTargetObj(GameObject newTO)
    {
        targetObj = newTO; 
        curTargetPos = newTO.transform.position;
    }
}