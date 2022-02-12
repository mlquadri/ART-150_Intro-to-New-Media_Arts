using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolith : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Interact
    public void Interact(GameObject player)
    {
        try
        {
            Debug.Log("Interact success");
            //player.ThirdPersonControler.currectInsanity -= 10;
            Destroy(this.gameObject);
        }
        catch
        {
            Debug.Log("Interact Failed");
        }
    }
}