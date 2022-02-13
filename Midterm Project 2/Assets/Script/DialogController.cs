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
    public GameObject interacty;
    public bool InDialog;
    public string script;

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
            gameObject.SetActive(true);
            updateNPCText();
            updateOptionText();
        }
        else if (this.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        Debug.Log(gameObject.activeSelf);
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

    void pressedOption1() { }// interacty.option1(); }
    void pressedOption2() { }// interacty.option2(); }
    void pressedOption3() { }// interacty.option3(); }
    void pressedOption4() { }// interacty.option4(); }

    public void loadScript(string newScript)
    {
        script = newScript;
        //foreach (string line in new LineReader(() => new StringReader(text)))
        //{
        //    Debug.Log(line);
        //}
        //using (StringReader reader = new StringReader(input))
        //{
        //    string line;
        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        // Do something with the line
        //    }
        //}
    }
}