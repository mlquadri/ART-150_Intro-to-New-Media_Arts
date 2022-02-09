using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Controller : MonoBehaviour
{
    public string textValue;
    public Text mainText;
    public GameObject player;
    public ScriptableObject playerC;
    //public ThirdPersonController playerC;

    // Start is called before the first frame update
    void Start()
    {
        textValue = "Player Stats \n Health: 100\n Stamina: 100\n Insanity: 100\n Occult: 100";
        //playerC = player.GetComponent(ThirdPersonController);
    }

    //Updated the stat text value
    void statTextUpdate()
    {
        //textValue = "Player Stats \n Health: " + playerC.currentHealth + "\n Stamina: " + playerC.currentStamina + "\n Insanity: " + playerC.currentInsanity + "\n Occult: " + playerC.currentOccult;
    }
    
    //Updated UI text
    void updateUI()
    {
        statTextUpdate();
        mainText.text = textValue;
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }
}
