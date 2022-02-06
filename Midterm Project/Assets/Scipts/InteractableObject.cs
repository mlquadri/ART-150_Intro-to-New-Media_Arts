using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //varable
    public ScriptableObject OtherScript;

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
            object p = OtherScript.Interact(player);
        }
        catch 
        {
            Debug.Log("Interact failed");
        }
    }
}
