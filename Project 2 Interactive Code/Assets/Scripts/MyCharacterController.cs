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
    public int currentHealth;
    public int currentStamina;
    public int currentInsanity;
    public int currentOccult;

    //Abilitys
        //Attack
            //Blade
            //Gun
            //Accult
        //Items
            //Key
            //Lighter
            //Candle
            //Old Coin

    //Other Varables
    public GameObject uI;
    public GameObject gameCamera;
    public float interactionDistence;

    //Inputs
    //public bool fire1;
    //public bool fire2;
    //public bool interact;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentInsanity = maxInsanity;
        currentOccult = maxOccult;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMainAttack() {
        Debug.Log("Stop hitting yourself (Left)");
        //play sound
        currentHealth--;
    }
    private void OnSecondaryAttack() {
        Debug.Log("Stop hitting yourself (right)");
        //play sound
        currentOccult--;
    }
    private void OnInteract() {
        //Debug.Log("Interact");
        //RaycastHit hit;
        //if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit)) {
            //Debug.Log(hit.transform.name);
            //if (hit.transform.GetComponent) {
            //    hit.transform.GetComponent<>(EclipseMonolith).Interact();
            //}
        //}
        currentInsanity++;
    }
    //Updates based on physics
    void FixedUpdate() {
    }
}
