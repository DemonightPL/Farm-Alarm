using UnityEngine;

public class touching : MonoBehaviour
{
    public Color tintColor = Color.blue;
    public float scaleMultiplier = 1.1f;
    private SpriteRenderer originalSpriteRenderer;
    private GameObject  newSpriteObject;
      void Start()
    {
        originalSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            CreateOutlineObject(originalSpriteRenderer);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            DeleteOutlineObject();
        }
    }

    private void CreateOutlineObject(SpriteRenderer originalSpriteRenderer)
    {
         newSpriteObject = new GameObject("ModifiedSprite");
        SpriteRenderer newSpriteRenderer = newSpriteObject.AddComponent<SpriteRenderer>();
        newSpriteRenderer.sprite = originalSpriteRenderer.sprite;
        newSpriteRenderer.color = tintColor;

        newSpriteObject.transform.localScale = originalSpriteRenderer.transform.localScale * scaleMultiplier;
        newSpriteObject.transform.position = originalSpriteRenderer.transform.position;
        newSpriteObject.transform.rotation = originalSpriteRenderer.transform.rotation;

        newSpriteObject.transform.SetParent(originalSpriteRenderer.transform);
    }
    

    private void DeleteOutlineObject()
    {
        Destroy(newSpriteObject);
    }
}
