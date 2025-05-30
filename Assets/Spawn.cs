using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private GameObject currentCoin;

    void Start()
    {
        SpawnCoin();
    }

    void SpawnCoin()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        currentCoin = Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        currentCoin.GetComponent<Coin>().SetSpawner(this);
    }

    public void CoinCollected()
    {
        Destroy(currentCoin);
        SpawnCoin();
    }

}
