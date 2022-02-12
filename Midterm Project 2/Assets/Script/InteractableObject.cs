using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //varable
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Interact
    public void Interact(GameObject interacter)
    {
        try
        {
            player = interacter;
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (this.gameObject.CompareTag("Monilith"))
            {
                playerController.currentInsanity++;
            }
            else if (this.gameObject.CompareTag("Painting")) 
            {
                playerController.maxInsanity++;
                playerController.currentInsanity++;
            }
            else if (this.gameObject.CompareTag("Enemy"))
            {
                playerController.currentInsanity-=1;
            }
        }
        catch
        {
            Debug.Log("Interact failed");
        }
    }
}
