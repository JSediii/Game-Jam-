using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed = 10f;
    [SerializeField] private float yOffset = 1f;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 xLimits = new Vector2(-10f, 10f);
    [SerializeField] private Vector2 yLimits = new Vector2(-10f, 10f);

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, xLimits.x, xLimits.y);
        newPosition.y = Mathf.Clamp(newPosition.y, yLimits.x, yLimits.y);

        transform.position = newPosition;
    }
}
