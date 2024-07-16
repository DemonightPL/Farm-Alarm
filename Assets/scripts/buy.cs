using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy : MonoBehaviour
{
    public GameObject shopmenu;
    private bool istouched;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            istouched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hand"))
        {
            istouched = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) & istouched)
        {
            buymenu();

        }
    }
    void buymenu()
    {
        shopmenu.SetActive(true);
    }
   
}
