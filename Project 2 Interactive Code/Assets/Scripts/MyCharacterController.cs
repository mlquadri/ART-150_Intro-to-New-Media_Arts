using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    //Stats
    public int maxHealth;
    public int maxStamina;
    public int maxInsanity;
    public int maxOccult;
    public int curentHealth;
    public int curentStamina;
    public int curentInsanity;
    public int curentOccult;

    //Inputs
    public bool fire1;
    public bool fire2;
    public bool interact;

    // Start is called before the first frame update
    void Start()
    {
        curentHealth = maxHealth;
        curentStamina = maxStamina;
        curentInsanity = maxInsanity;
        curentOccult = maxOccult;
        fire1 = false;
        fire2 = false;
        interact = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fire1) {
            fire1 = Input.GetButtonDown("Fire1");
            
        }
        if (!fire2)
        {
            fire2 = Input.GetButtonDown("Fire2");

        }
        if (!interact)
        {
            //interact = Input.GetButtonDown("interact");

        }
    }

    //Updates based on physics
    void FixedUpdate() {

        if (fire1)
        {
            Debug.Log("Fire right");
            fire1 = false;
        }
        if (fire2)
        {
            Debug.Log("Fire left");
            fire2 = false;
        }
        if (fire1)
        {
            Debug.Log("Interact");
            fire1 = false;
        }
    }
}
