using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CodeEnemy : MonoBehaviour
{
    GameManager gameManager;

    //ObserverDesign Patern
    public event EventHandler eventHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.OnCodeCreation(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Player":
                Die();
                break;
            case "Projectile":
                Die();
                break;
        }
    }

    private void Die()
    {
        //Notify projectile of death
        NotifyOfDeath();
        Destroy(this.gameObject);
    }

    //Observer Design Pattern
    public void NotifyOfDeath() 
    {
        if(eventHandler != null)
        {
            eventHandler(this, EventArgs.Empty);
        }
        gameManager.OnCodeDead(this.gameObject);
    }
}
