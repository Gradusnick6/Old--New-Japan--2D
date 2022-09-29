using UnityEngine;

public class View
{
    private GameObject characterObj;
    private Transform characterT;
    [Range(0, 360)] private float viewAngle;
    private float viewDistance { get; }
    /// <summary>
    /// расстояние, на котором объект может обнаружить цель вне поля зрения
    /// </summary>
    private float absDetection;




    public GameObject TargetObj { private set; get; }
    SocialComponent socialComp;
    /// <summary>
    /// слой объекта существа
    /// </summary>
    LayerMask creatureL;

    public View(GameObject characterObj_, float viewAngle_, float viewDistance_, float absDetection_)
    {
        characterObj = characterObj_;
        characterT = characterObj.transform;
        viewAngle = viewAngle_;
        viewDistance = viewDistance_;
        absDetection = absDetection_;
        socialComp = new SocialComponent(characterObj_);
        creatureL = LayerMask.GetMask("Creature");
    }

    /// <summary>
    /// проверяет наличие объекта с creatureL_ в окружности, центр которой - объект, радиус viewDistance
    /// запоминает положние цели в objTarget 
    /// </summary>
    /// <returns>true - объект с enemyL найден, изменяет objTarget; false - объект с enemyL не найден</returns>
    public bool IsFindTarget()
    {
        Transform targetT;
        float realAngle;
        RaycastHit2D[] hits;
        ContactFilter2D characterCF = new ContactFilter2D().NoFilter();

        Collider2D[] targets = Physics2D.OverlapCircleAll(characterT.position, viewDistance, creatureL);
        foreach (Collider2D target in targets)
        {
            characterCF.SetLayerMask(LayerMask.GetMask("Character"));
            targetT = target.transform;
            if (target.gameObject != characterObj && socialComp.isHostility(target.gameObject))
            {
                //проверка, есть ли преграды между объектом и целью
                Debug.DrawRay(characterT.position, targetT.position - characterT.position);
                hits = Physics2D.RaycastAll(characterT.position, targetT.position - characterT.position, viewDistance);
                for (int i = 0; i < hits.Length; i++)
                {
                    realAngle = Vector3.Angle(characterT.right, targetT.position - characterT.position);
                    float t = Vector3.Distance(characterT.position, targetT.position);
                    // является ли коллайдер hits[i] потенциальной целью
                    if (hits[i].transform == targetT)
                        //проверка, попадает ли объект в зону видимости или в зону абсолютного обнаружения
                        if (realAngle < viewAngle / 2f && Vector3.Distance(characterT.position, targetT.position) <= viewDistance ||
                        Vector3.Distance(characterT.position, targetT.position) <= absDetection)
                    {
                        TargetObj = targetT.gameObject;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Отрисовывает область видимости объекта
    /// </summary>
    public void DrawViewState()
    {
        Vector3 left = characterT.position + Quaternion.Euler(new Vector3(0, 0, viewAngle / 2f)) * (characterT.right * viewDistance);
        Vector3 right = characterT.position + Quaternion.Euler(-new Vector3(0, 0, viewAngle / 2f)) * (characterT.right * viewDistance);
        Debug.DrawLine(characterT.position, left, Color.yellow);
        Debug.DrawLine(characterT.position, right, Color.yellow);
    }
}
