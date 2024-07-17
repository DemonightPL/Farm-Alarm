using UnityEngine;

public class ammountshower : MonoBehaviour
{
    public Transform fullFillImage;
    public Transform fillImage;
    public float fillAmount;
    public float size;
     

    void Start()
    {
         
        UpdateFillImage(0);
    }

    void Update()
    {
        
        UpdateFillImage(fillAmount);

    }

    private void UpdateFillImage(float amount)
    {
        fillAmount = Mathf.Clamp01(amount);
        Vector3 fullScale = fullFillImage.localScale;
        fillImage.localScale = new Vector3(fillImage.localScale.x, fullScale.y * fillAmount * size , fillImage.localScale.z);
    }
}
