using UnityEngine;

public class animalwalking : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRadius = 5f;
    private Vector2 randomDirection;
    private Transform hayTransform;
    private float randomSpeed;
    public float food;
    private Chicken chicken;

    void Start()
    {
        chicken = GetComponent<Chicken>();
        
        InvokeRepeating("ChooseRandomDirection", 0f, 2f);
        
    }

    void Update()
    {
         food = chicken.food;
        DetectHay();

        if (hayTransform != null & food < 0.5f)
        {
            MoveTowardsHay();
        }
        else
        {
            MoveInRandomDirection();
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

    void DetectHay()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        hayTransform = null;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Hay"))
            {
                hayTransform = collider.transform;
                break;
            }
        }
    }

    void MoveTowardsHay()
    {
        Vector2 direction = (hayTransform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
