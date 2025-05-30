using UnityEngine;

public class Coin : MonoBehaviour
{
    private Spawn spawner;
    [SerializeField] float rotationSpeed = 100f;


    public void SetSpawner(Spawn coinSpawner)
    {
        spawner = coinSpawner;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            spawner.CoinCollected();
            Destroy(gameObject);
        }
    }
}
