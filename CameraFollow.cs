using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target to follow")]
    public Transform target;

    [Header("Smooth Follow Settings")]
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 1, -10);

    [Header("Clamp Limits")]
    public bool useClamp = false;
    public Vector2 minLimits;
    public Vector2 maxLimits;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        if (useClamp)
        {
            float clampedX = Mathf.Clamp(smoothedPosition.x, minLimits.x, maxLimits.x);
            float clampedY = Mathf.Clamp(smoothedPosition.y, minLimits.y, maxLimits.y);
            transform.position = new Vector3(clampedX, clampedY, smoothedPosition.z);
        }
        else
        {
            transform.position = smoothedPosition;
        }
    }
}
