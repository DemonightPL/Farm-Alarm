using UnityEngine;

public class SpriteFillBar : MonoBehaviour
{
    public Transform fullFillImage;
    public Transform fillImage;
    public float fillAmount;
    public float size;
     private box box;

    void Start()
    {
         box = GetComponentInParent<box>();
        UpdateFillImage(0);
    }

    void Update()
    {
        Debug.Log(box.items);
      fillAmount =  (float)box.items;
        UpdateFillImage(fillAmount);

    }

    private void UpdateFillImage(float amount)
    {
        fillAmount = Mathf.Clamp01(amount);
        Vector3 fullScale = fullFillImage.localScale;
        fillImage.localScale = new Vector3(fillImage.localScale.x, fullScale.y * fillAmount * size * 0.1f, fillImage.localScale.z);
    }
}
