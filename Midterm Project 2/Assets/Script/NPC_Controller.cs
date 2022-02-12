using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NPC_Controller : MonoBehaviour
{
    public DialogController dialogController;
    string scriptFileName = "";
    string script;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            StreamReader reader = new StreamReader(scriptFileName);
            script = reader.ReadToEnd();
            reader.Close();
            Debug.Log("Script file loaded");
        }
        catch 
        {
            Debug.Log("Script file not loaded");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        dialogController.InDialog = true;
    }
}
