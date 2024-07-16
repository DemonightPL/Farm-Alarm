using UnityEngine;

public class HandTriggerCheck : MonoBehaviour
{
    public GameObject outlinePrefab;
    private GameObject outlineObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            CreateOutlineObject();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            DeleteOutlineObject();
        }
    }

    private void CreateOutlineObject()
    {
        if (outlineObject == null)
        {
            outlineObject = Instantiate(outlinePrefab, transform.position, Quaternion.identity);
            outlineObject.transform.SetParent(transform);
            outlineObject.transform.localPosition = Vector3.zero;
        }
    }

    private void DeleteOutlineObject()
    {
        if (outlineObject != null)
        {
            Destroy(outlineObject);
            outlineObject = null;
        }
    }
}
