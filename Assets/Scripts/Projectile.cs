using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1000f;
    public GameObject target;
    public Vector2 moveDirection;
    CodeEnemy code;



    //Observer


    // Start is called before the first frame update
    void Start()
    {
        code = target.GetComponent<CodeEnemy>();
        Subscribe();
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

    public void Subscribe()
    {
        code.eventHandler += OnTargetDead;
    }

    public void OnTargetDead(object sender, EventArgs args)
    {
        Destroy(this.gameObject);   
    }
}
