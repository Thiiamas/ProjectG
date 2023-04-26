using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range(5, 13)]
    public float radius = 13;

    public float spawnRate = 0.5f;
    float timer = 0;

    public GameObject codePrefab;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer > spawnRate)
        {
            timer = 0;
            Spawn();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Spawn() 
    {
        Vector2 spawnLocation = Random.insideUnitCircle.normalized * radius;
        GameObject code = Instantiate(codePrefab,spawnLocation,Quaternion.identity);
    }
}
