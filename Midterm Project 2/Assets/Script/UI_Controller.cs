using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Controller : MonoBehaviour
{
    public string textValue;
    public Text mainText;
    public GameObject player;
    public PlayerController playerC;
    void Start()
    {
        playerC = player.GetComponent<PlayerController>();
        textValue = "Player Stats \n Health: " + playerC.currentHealth + "\n Stamina: " + playerC.currentStamina + "\n Insanity: " + playerC.currentInsanity + "\n Occult: " + playerC.currentOccult; ;
    }

    //Updated the stat text value
    void statTextUpdate()
    {
        textValue = "Player Stats \n Health: " + playerC.currentHealth + "\n Stamina: " + playerC.currentStamina + "\n Insanity: " + playerC.currentInsanity + "\n Occult: " + playerC.currentOccult;
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