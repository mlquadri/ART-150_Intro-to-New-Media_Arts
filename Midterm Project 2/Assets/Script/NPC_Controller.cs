using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NPC_Controller : MonoBehaviour
{
    public DialogController dialogController;
    public string scriptFileName = "Assets/Character Dialogue/TutorialDialogue.txt";
    public string script;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            StreamReader reader = new StreamReader(scriptFileName);
            script = reader.ReadToEnd();
            reader.Close();
            Debug.Log(this.gameObject.name + " Dialogue file loaded");
            Debug.Log(script);
        }
        catch 
        {
            Debug.Log(this.gameObject.name+" Dialogue file not loaded");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        dialogController.StartDialogue(script, this.gameObject);
    }
}
