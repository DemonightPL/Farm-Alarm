using UnityEngine;

public class fillingbar : MonoBehaviour
{
    public Transform barTransform;
    public float fillSpeed = 0.1f;
    public Vector3 offset;
    private float targetFill = 1f;
    private Vector3 originalScale;
    private Transform targetTransform;
    
    public Cow cowscript;

    private void Start()
    {
        cowscript = transform.parent.GetComponent<Cow>();
        originalScale = barTransform.localScale;
        barTransform.localScale = new Vector3(0, originalScale.y, originalScale.z);
    }

     private void Update()
    {
        if(cowscript.food > 0f)
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
            cowscript.milkspawn();
        }

        if (targetTransform != null)
        {
            transform.position = targetTransform.position + offset;
        }
        }
    }

    private void Initialize(Transform target)
    {
        targetTransform = target;
        transform.parent = target;
        transform.localPosition = offset;
    }
}
