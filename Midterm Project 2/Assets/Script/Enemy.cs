using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("enemy defeted");
            Destroy(this.gameObject);
        }
    }

    public void hit(int damage)
    {
        health -= damage;
        Debug.Log("Enemy hit for " + damage + " damage");
    }
}