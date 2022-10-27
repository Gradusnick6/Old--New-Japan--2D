using UnityEngine;
using UnityEngine.AI;
using MonteCarloTree;

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

    //хранит в себе информацию о выполнении текущего действия
    //если действие было доступно и выполнено, то true
    //если действие было не выполнено, то false
    bool isComleted;

    private ActionForest aForest;

    void Start()
    {
        ForestInitialize();
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
            aForest.Start();
    }
    private void ForestInitialize()
    {
        if (aObjCreater == null) aObjCreater = transform.Find("ActionObjectCreater").GetComponent<ActionObjectCreater>();
        kind.aObjCreater = aObjCreater;

        kind.gameObj = gameObject;

        if (character == null) character = transform.GetComponent<Character>();
        kind.character = character;

        kind.Initialize();

        aForest = kind.aForest;
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