using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //varable
    public GameObject player;
    public ScriptableObject ddd;
    
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
        }
        catch 
        {
            Debug.Log("Interact failed");
        }
    }
}
