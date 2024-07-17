using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mill : MonoBehaviour
{
    public GameObject Flour;
    public float ammount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(mil());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hay"))
        {
            Destroy(other.gameObject);
            
            ammount +=1;
        }
    }


    IEnumerator mil()
    {
        while (true)
        {
        yield return new WaitForSeconds(5f);
        
        if(ammount > 0)
        {
            ammount -=1;
         Instantiate(Flour, transform.position, transform.rotation);
        }
        
        }
    }
}
