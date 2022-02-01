using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public int me;
    public string textValue;
    public Text mainText;
    public GameObject myPlayer;
    public MyCharacterController myPlayerC;

    // Start is called before the first frame update
    void Start()
    {
        textValue = "Player Stats \n Health: 100\n Stamina: 100\n Insanity: 100\n Occult: 100";
        myPlayerC = myPlayer.GetComponent<MyCharacterController>();
    }

    //Updated the stat text value
    void statTextUpdate()
    {
        textValue = "Player Stats \n Health: "+ myPlayerC.currentHealth + "\n Stamina: "+ myPlayerC.currentStamina + "\n Insanity: "+ myPlayerC.currentInsanity+ "\n Occult: "+ myPlayerC.currentOccult;
    }

    void updateUI() {
        statTextUpdate();
        mainText.text = textValue;
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }
}
