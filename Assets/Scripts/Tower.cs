using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameManager gameManager;

    [Range(0f, 1f)]
    public float fireRate = 0.5f;
    public float fireTimer = 0f;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if(fireTimer > fireRate)
        {
            GameObject target = GetClosestEnemie();
            if (target != null)
            {
                fireTimer = 0f;
                Fire(target);
            }
 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
    }

    void Fire(GameObject target)
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized + (Vector2) transform.position;
        Vector2 direction = (target.transform.position - transform.position).normalized;
        spawnPosition = (Vector2)transform.position + direction ;
        GameObject projectile = Instantiate(projectilePrefab,spawnPosition,Quaternion.identity);
        Projectile proj = projectile.GetComponent<Projectile>();
        proj.target = target;
        proj.moveDirection = direction;
    }
    GameObject GetClosestEnemie()   
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in gameManager.liveEnemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}
