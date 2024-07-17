using UnityEngine;

public class camerascript : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 5.0f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 offset = targetPosition - initialPosition;

            if (offset.magnitude > maxDistance)
            {
                offset = offset.normalized * maxDistance;
            }

            transform.position = initialPosition + offset;
        }
    }
}
