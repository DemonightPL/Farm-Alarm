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
    private Cow cow;
    
    private string animal;

    void Start()
    {
        chicken = GetComponent<Chicken>();
        if(chicken == null)
        {
            cow = GetComponent<Cow>();
            animal="cow";
        }
        else
        {
            animal = "chicken";
        }
        
        InvokeRepeating("ChooseRandomDirection", 0f, 2f);
        
    }

    void Update()
    {
        if(animal == "chicken")
        {
            food = chicken.food;
        }
        else if(animal == "cow")
        {
            food = cow.food;

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
            if (collider.CompareTag("Hay") & animal == "cow")
            {
                foodTransform = collider.transform;
                break;
            }
            else if(collider.CompareTag("Grass") & animal == "chicken")
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
