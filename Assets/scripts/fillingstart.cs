using UnityEngine;

public class TestSlidingBar : MonoBehaviour
{
    public SlidingBar slidingBarPrefab;
    public Transform targetObject;

    void Start()
    {
        SlidingBar slidingBarInstance = Instantiate(slidingBarPrefab, targetObject.position, Quaternion.identity);
        slidingBarInstance.Initialize(targetObject);
    }
}
