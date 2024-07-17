using UnityEngine;

public class fillingbar : MonoBehaviour
{
    public Transform barTransform;
    public float fillSpeed = 0.1f;
    public Vector3 offset;
    private float targetFill = 1f;
    private Vector3 originalScale;
    private Transform targetTransform;
    
    public Chicken chickenscript;

    void Start()
    {
        chickenscript = transform.parent.GetComponent<Chicken>();
        originalScale = barTransform.localScale;
        barTransform.localScale = new Vector3(0, originalScale.y, originalScale.z);
    }

    void Update()
    {
        if(chickenscript.food > 0f)
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
            chickenscript.eggspawn();
        }

        if (targetTransform != null)
        {
            transform.position = targetTransform.position + offset;
        }
        }
    }

    public void Initialize(Transform target)
    {
        targetTransform = target;
        transform.parent = target;
        transform.localPosition = offset;
    }
}
