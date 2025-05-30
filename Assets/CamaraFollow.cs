using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] Transform player; 
    [SerializeField] Transform coin; 
    [SerializeField] float lerpSpeed = 5f; 

    void Update()
    {
        Vector3 targetPosition = Vector3.Lerp(player.position, coin.position, 0.5f); 
        targetPosition.z = transform.position.z; 
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
    }
}
