using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassscript : MonoBehaviour
{
    public GameObject spawner;
    public grassspawner script;
    public GameObject grass;
    // Start is called before the first frame update
    void Start()
    {
       spawner =  GameObject.Find("spawner");
        script = spawner.GetComponent<grassspawner>();
      Invoke("destroy", 20f);
    }

    // Update is called once per frame
    void destroy()
    {
        script.ammount -= 1;
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Hand"))
        {
            Instantiate(grass, transform.position, Quaternion.identity);
            destroy();
            
        }
    }
}
