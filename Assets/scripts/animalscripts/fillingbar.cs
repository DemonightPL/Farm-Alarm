using UnityEngine;

public class fillingbar : MonoBehaviour
{
    public Transform barTransform;
    public float fillSpeed = 0.1f;
    public Vector3 offset;
    private float targetFill = 1f;
    private Vector3 originalScale;
    private Transform targetTransform;
    public GameObject parent;
    public string animal;
    public Chicken chickenscript;
    public Cow cowscript;

    void Start()
    {
        parent= transform.parent.gameObject;
        if(parent !=null)
        {
            chickenscript = parent.GetComponent<Chicken>();
            cowscript = parent.GetComponent<Cow>();
            if(chickenscript != null)
            {
                animal = "chicken";
                fillSpeed = 0.1f;
            }
            else
            {
                animal = "cow";
                fillSpeed = 0.01f;
            }
               
        }

       
        
         
        
        
        originalScale = barTransform.localScale;
        barTransform.localScale = new Vector3(0, originalScale.y, originalScale.z);
    }

    void Update()
    {
        if(animal == "chicken")
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
        else if (animal == "cow")
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
    }

    public void Initialize(Transform target)
    {
        targetTransform = target;
        transform.parent = target;
        transform.localPosition = offset;
    }
}
