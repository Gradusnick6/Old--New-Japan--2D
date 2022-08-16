using UnityEngine;

public class CameraForPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    /// <summary>
    /// резкость смещения камеры
    /// </summary>
    private const float dumping = 3f;
    /// <summary>
    /// смещение камеры по оси X
    /// </summary>
    private const float offsetX = 2.5f;
    /// <summary>
    /// смещение камеры по оси Y
    /// </summary>
    private const float offsetY = 0.5f;
    /// <summary>
    /// содержит информацию о направлении смещения камеры по оси X
    /// </summary>
    private bool isLeft;
    /// <summary>
    /// содержит информацию о направлении смещения камеры по оси Y
    /// </summary>
    private bool isDown;
    /// <summary>
    /// координаты положения наблюдаемого объекта в предыдущем кадре
    /// </summary>
    private Vector2 lastPos;
    private int y;

    void Start()
    {
        isLeft = false;
        isDown = false;
        lastPos.x = player.transform.position.x;
        lastPos.y = player.transform.position.y;
        //transform.position = player.transform.position;
    }
    void LateUpdate()
    {
        float currentX = player.transform.position.x;
        float currentY = player.transform.position.y;
        if (currentX != lastPos.x)
        {
            isLeft = !(currentX > lastPos.x);
            lastPos.x = currentX;
        }

        if (currentY != lastPos.y)
        {
            isDown = !(currentY > lastPos.y);
            lastPos.y = currentY;
        }

        Vector3 target = player.transform.position;

        if (isLeft)
            target.x = player.transform.position.x - offsetX;
        else
            target.x = player.transform.position.x + offsetX;

        if (lastPos.y != currentY) y = 0;

        if (isDown)
                target.y = player.transform.position.y - offsetY; // + (++y) * 0.0005f
        else
                target.y = player.transform.position.y + offsetY; // + (--y) * 0.0005f

        transform.position = Vector3.Lerp(transform.position, target, dumping*Time.deltaTime);
    }
}
