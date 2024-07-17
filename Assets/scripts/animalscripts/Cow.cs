using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cow : MonoBehaviour
{
    public Button exit;
    public GameObject milk;
    public float food = 1f;
    private bool caneat;
    public GameObject foodindicator;
    public bool ishungry = false;
    private GameObject newObject;
    private Vector2 spawnPosition;
    private bool istouched;
    public bool isminigame;
    public GameObject managerobject;
    private Manager managerscript;
    public GameObject milkgame;

    private GameObject newminigame;

    public void milkspawn()
    {
        Instantiate(milk, transform.position, Quaternion.identity);
    }

    private void Start()
    {
        food = 1f;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Hay") && caneat)
        {
            food = 1f;
            Destroy(other.gameObject);
            full();
            caneat = false;
            ishungry = false;
        }
    }

    void FixedUpdate()
    {
        if (food > 0f)
        {
            food -= 0.1f * Time.deltaTime;
        }
        if (food < 0.5f)
        {
            caneat = true;
        }
        if (food < 0.2f && !ishungry)
        {
            Hungry();
            ishungry = true;
        }
    }

    void Update()
    {
        if (managerscript == null)
        {
            managerobject = GameObject.Find("manager");
            if (managerobject != null)
            {
                managerscript = managerobject.GetComponent<Manager>();
            }
        }
      

       
        if (Input.GetMouseButtonDown(0) && istouched && !managerscript.canvasactive )
        {
            newminigame = Instantiate(milkgame, new Vector3(0, 0, 0), transform.rotation);
            isminigame = true;
            managerscript.canvasactive =  true;
            exit = GameObject.Find("x").GetComponent<Button>();
            exit.onClick.AddListener(stopminigame);
        }

        
        
    }

    void Hungry()
    {
        spawnPosition = transform.position;
        spawnPosition.x -= 0.5f;
        spawnPosition.y += 0.5f;
        newObject = Instantiate(foodindicator, spawnPosition, transform.rotation);
        newObject.transform.parent = transform;
    }

    void full()
    {
        Destroy(newObject);
    }

    public void stopminigame()
    {
        Destroy(newminigame);
        isminigame = false;
        managerscript.canvasactive =  false;
    }

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
}
