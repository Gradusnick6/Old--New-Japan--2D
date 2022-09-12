using UnityEngine;

public class ActionObjectCreater : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private void Awake()
    {
        if (parent == null)
            parent = transform.parent;
    }
    /// <summary>
    /// вызов функции Instantiate
    /// </summary>
    /// <param name="prefab">создаваемый префаб</param>
    /// <returns>ссылка на созданный объект</returns>
    public GameObject CreatePrefab(GameObject prefab)
    {
        return Instantiate(prefab, parent);
    }
}
