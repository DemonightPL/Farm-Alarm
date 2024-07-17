using UnityEngine;

public class fillingstart : MonoBehaviour
{
    public fillingbar slidingBarPrefab;
    public Transform targetObject;

    void Start()
    {
        fillingbar slidingBarInstance = Instantiate(slidingBarPrefab, targetObject.position, Quaternion.identity);
        slidingBarInstance.Initialize(targetObject);
    }
}
