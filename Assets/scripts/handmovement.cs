using UnityEngine;

public class HandFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float maxDistance = 5f; // Maximum distance the hand can be from the player

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - player.position;
        if (direction.magnitude > maxDistance)
        {
            direction = direction.normalized * maxDistance;
        }

        transform.position = player.position + direction;
    }
}
