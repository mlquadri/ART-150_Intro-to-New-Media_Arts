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
    public GameObject cursor;
    public Vector3 mousePos;

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
            if(nPCTextValue == "End dialogue")
            {
                InDialog = false;
            }
        }
        else
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

    public void pressedOption1()
    {
        if (nPC.name == "NPC1")
        {
            storyController.person1Favarability += 1;
        }
        currentScriptLocation = script[currentScriptLocation][1];
        nPCTextValue = script[currentScriptLocation][0];
        option1TextValue = script[currentScriptLocation][1];
        option2TextValue = script[currentScriptLocation][2];
        option3TextValue = script[currentScriptLocation][3];
        option4TextValue = script[currentScriptLocation][4];
        Debug.Log("Option1 Pressed");
    }// interacty.option1(); }
    public void pressedOption2()
    {
        if (nPC.name == "NPC1")
        {
            storyController.person1Favarability -= 1;
        }
        currentScriptLocation = script[currentScriptLocation][2];
        nPCTextValue = script[currentScriptLocation][0];
        option1TextValue = script[currentScriptLocation][1];
        option2TextValue = script[currentScriptLocation][2];
        option3TextValue = script[currentScriptLocation][3];
        option4TextValue = script[currentScriptLocation][4];
        Debug.Log("Option2 Pressed");
    }// interacty.option2(); }
    public void pressedOption3()
    {
        if (nPC.name == "NPC1")
        {
            nPC.SetActive(false);
            storyController.person1IsAlive = false;
        }
        currentScriptLocation = script[currentScriptLocation][3];
        nPCTextValue = script[currentScriptLocation][0];
        option1TextValue = script[currentScriptLocation][1];
        option2TextValue = script[currentScriptLocation][2];
        option3TextValue = script[currentScriptLocation][3];
        option4TextValue = script[currentScriptLocation][4];
        Debug.Log("Option3 Pressed");
    }// interacty.option3(); }
    public void pressedOption4()
    {
        currentScriptLocation = script[currentScriptLocation][4];
        nPCTextValue = script[currentScriptLocation][0];
        option1TextValue = script[currentScriptLocation][1];
        option2TextValue = script[currentScriptLocation][2];
        option3TextValue = script[currentScriptLocation][3];
        option4TextValue = script[currentScriptLocation][4];
        Debug.Log("Option4 Pressed");
    }// interacty.option4(); }

    public void loadScript(string newScript)
    {
        scriptText = newScript;
        //char[] extraChar = {' ', (char)(9)};
        string[] scriptByLine = scriptText.Split('\n');
        foreach (string line in scriptByLine)
        {
            string[] keyAndValue = line.Split(':');
            string[] dicValue = keyAndValue[1].Split(',');
            for(int i = 0; i < dicValue.Length; i++) 
            {
                dicValue[i] = dicValue[i];//.Trim(extraChar);
            }
            script.Add(keyAndValue[0], dicValue);//.Trim(extraChar)

        }
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