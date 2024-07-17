using UnityEngine;

public class animalwalking : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRadius = 5f;
    private Vector2 randomDirection;
    private Transform foodTransform;
    private float randomSpeed;
    public float food = 1f;
    private Chicken chicken;
    private Chick chick;
    private Cow cow;
    private Sheep sheep;
    public string animal;

    void Start()
    {
        chicken = GetComponent<Chicken>();
        cow = GetComponent<Cow>();
         chick = GetComponent<Chick>();
         sheep = GetComponent<Sheep>();
        if(cow != null)
        {
            
            animal="cow";
        }
        else if(chicken != null)
        {
            animal = "chicken";
           
        }
        else if(chick != null)
        {
            animal = "chick";
        }
        else if(sheep != null)
        {
            animal = "sheep";
        }
        
        InvokeRepeating("ChooseRandomDirection", 0f, 2f);
        
    }

    void Update()
    {
        if(animal == "chicken" )
        {
            food = chicken.food;
        }
        else if(animal == "cow")
        {
            food = cow.food;

        }
        else if (animal == "chick")
        {
            food = chick.food;
        }
        else if (animal == "sheep")
        {
            food = sheep.food;
        }
        DetectFood();
        if(animal !="cow" || !cow.isminigame)
        {
             if (foodTransform != null & food < 0.5f)
            {
             MoveTowardsFood();
            }
             else
            {
             MoveInRandomDirection();
            }
        }
       
    }

    void ChooseRandomDirection()
    {
        randomSpeed = Random.Range(0.4f, 1f);
        float randomAngle = Random.Range(0f, 360f);
        randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
    }

    void MoveInRandomDirection()
    {
        transform.Translate(randomDirection * speed * Time.deltaTime * randomSpeed);
    }

    void DetectFood()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foodTransform = null;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Hay") & animal == "cow" || collider.CompareTag("Hay") & animal == "sheep")
            {
                foodTransform = collider.transform;
                break;
            }
            else if(collider.CompareTag("Grass") & animal == "chicken" || collider.CompareTag("Grass") & animal == "chick")
            {
                foodTransform = collider.transform;
                break;
            }
        }
    }

    void MoveTowardsFood()
    {
        Vector2 direction = (foodTransform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
