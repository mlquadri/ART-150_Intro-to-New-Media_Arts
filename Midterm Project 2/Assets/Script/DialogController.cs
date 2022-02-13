using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    //varables
    public string nPCTextValue;
    public string option1TextValue;
    public string option2TextValue;
    public string option3TextValue;
    public string option4TextValue;
    public TextMeshProUGUI nPCText;
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;
    public TextMeshProUGUI option4Text;
    public GameObject nPC;
    public bool InDialog;
    public string scriptText;
    public Dictionary<string, string[]> script = new Dictionary<string, string[]>();
    public string currentScriptLocation = "Starting Dialogue";
    public StoryController storyController;

    // Start is called before the first frame update
    void Start()
    {
        InDialog = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InDialog)
        {
            updateNPCText();
            updateOptionText();
        }
        else if (gameObject.activeSelf)
        {
            Time.timeScale = 1f;
            Debug.Log("Starting time, turning off cursor and ending dialogue");
            gameObject.SetActive(false);
        }
    }

    void updateNPCText()
    {
        nPCText.text = nPCTextValue;
    }
    void updateOptionText()
    {
        option1Text.text = option1TextValue;
        option2Text.text = option2TextValue;
        option3Text.text = option3TextValue;
        option4Text.text = option4TextValue;
    }

    void pressedOption1()
    {
        if (nPC.name == "NPC1")
        {
            storyController.person1Favarability += 1;
            currentScriptLocation = script[currentScriptLocation][1];
            nPCTextValue = script[currentScriptLocation][0];
            option1TextValue = script[currentScriptLocation][1];
            option2TextValue = script[currentScriptLocation][2];
            option3TextValue = script[currentScriptLocation][3];
            option4TextValue = script[currentScriptLocation][4];
        }
        Debug.Log("Option1 Pressed");
    }// interacty.option1(); }
    void pressedOption2()
    {
        if (nPC.name == "NPC1")
        {
            storyController.person1Favarability -= 1;
            currentScriptLocation = script[currentScriptLocation][2];
            nPCTextValue = scriptText;
            option1TextValue = scriptText;
            option2TextValue = scriptText;
            option3TextValue = scriptText;
            option4TextValue = scriptText;
        }
        Debug.Log("Option2 Pressed");
    }// interacty.option2(); }
    void pressedOption3() { }// interacty.option3(); }
    void pressedOption4() { }// interacty.option4(); }

    public void loadScript(string newScript)
    {
        scriptText = newScript;
        string[] scriptByLine = scriptText.Split('\n');
        foreach (string line in scriptByLine)
        {
            string[] keyAndValue = line.Split(':');
            string[] dicValue = keyAndValue[1].Split(','); // Causing an error
            Debug.Log("Key: " + keyAndValue[0] + ", Value: " + dicValue);
            script.Add(keyAndValue[0], dicValue);
        }
        try { Debug.Log(script[currentScriptLocation]); } catch { Debug.Log("No script"); }
    }

    public void StartDialogue(string newScript, GameObject npc) 
    {
        nPC = npc;
        loadScript(newScript);
        InDialog = true;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        //Cursor.visible = true; Cant move cursore while updating
        nPCTextValue = script[currentScriptLocation][0];
        option1TextValue = script[currentScriptLocation][1];
        option2TextValue = script[currentScriptLocation][2];
        option3TextValue = script[currentScriptLocation][3];
        option4TextValue = script[currentScriptLocation][4];
        Debug.Log("Stoping time, turning on cursor and starting dialogue");
    }
}