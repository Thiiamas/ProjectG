using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1000f;
    public GameObject target;
    public Vector2 moveDirection;
    CodeEnemy code;

    




    // Start is called before the first frame update
    void Start()
    {
        code = target.GetComponent<CodeEnemy>();
        Subscribe();

        Destroy(gameObject, 5);
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(moveDirection * Time.deltaTime * speed);
        }
    }

    //Observer
    public void Subscribe()
    {
        code.eventHandler += OnTargetDead;
    }

    public void OnTargetDead(object sender, EventArgs args)
    {
        Destroy(this.gameObject);   
    }
}
