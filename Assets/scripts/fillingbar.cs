using UnityEngine;

public class SlidingBar : MonoBehaviour
{
    public Transform barTransform;
    public float fillSpeed = 0.1f;
    public Vector3 offset;
    private float targetFill = 1f;
    private Vector3 originalScale;
    private Transform targetTransform;
    public Chicken chicken;

    void Start()
    {
        
        originalScale = barTransform.localScale;
        barTransform.localScale = new Vector3(0, originalScale.y, originalScale.z);
    }

    void Update()
    {
        Vector3 newScale = barTransform.localScale;
        if (newScale.x < targetFill * originalScale.x)
        {
            newScale.x += fillSpeed * Time.deltaTime * originalScale.x;
            barTransform.localScale = newScale;
        }
        else
        {
            barTransform.localScale = new Vector3(0, originalScale.y, originalScale.z);
            chicken.eggspawn();
        }

        if (targetTransform != null)
        {
            transform.position = targetTransform.position + offset;
        }
    }

    public void Initialize(Transform target)
    {
        targetTransform = target;
        transform.parent = target;
        transform.localPosition = offset;
    }
}
