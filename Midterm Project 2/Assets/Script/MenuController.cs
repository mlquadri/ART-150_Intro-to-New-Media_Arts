using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public bool menuActive;
    public StoryController storyController;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (menuActive)
        {
            if (Input.GetKeyDown("enter"))
            {
                Save();
            }
            else if(Input.GetKeyDown("escape"))
            {
                Exit();
            }

        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Save() 
    {
        Debug.Log("Save Game");
        storyController.UpdateSaveFile();
    }
    public void Exit()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
    public void openMenu()
    {
        this.gameObject.SetActive(true);
        menuActive = true;
    }
}
