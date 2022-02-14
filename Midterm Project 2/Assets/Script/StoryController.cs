using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StoryController : MonoBehaviour
{
    //Varables
    public float person1Favarability;
    public float person2Favarability;
    public float person3Favarability;
    public float person4Favarability;
    public bool person1IsAlive;
    public bool person2IsAlive;
    public bool person3IsAlive;
    public bool person4IsAlive;
    public string SAVEfILEnAME = "Assets/Game Saves/SaveFile.txt";
    public string saveFile;
    StreamWriter writer;



    // Start is called before the first frame update
    void Start()
    {
        try
        {
            StreamReader reader = new StreamReader(SAVEfILEnAME);
            saveFile = reader.ReadToEnd();
            reader.Close();
            LoadSaveFile();
            Debug.Log("Save file loaded");
            writer = new StreamWriter(SAVEfILEnAME, true);
        }
        catch
        {
            person1Favarability = 0;
            person2Favarability = 0;
            person3Favarability = 0;
            person4Favarability = 0;
            person1IsAlive = true;
            person2IsAlive = true;
            person3IsAlive = true;
            person4IsAlive = true;
            Debug.Log("No Save File Found");
        }
    }

    public void UpdateSaveFile()
    {
        string newSaveFile = "person1Favarability:"+ person1Favarability + "\nperson2Favarability:"+ person2Favarability + "\nperson3Favarability:"+ person3Favarability + "\nperson4Favarability:"+ person4Favarability + "\nperson1IsAlive:"+ person1IsAlive + "\nperson2IsAlive:"+ person2IsAlive + "\nperson3IsAlive:"+ person3IsAlive + "\nperson4IsAlive:"+ person4IsAlive;
        writer.WriteLine(newSaveFile);
        Debug.Log("Saving Game");
    }
    public void LoadSaveFile()
    {
        string[] fileByLine = saveFile.Split('\n');
        foreach (string line in fileByLine)
        {
            string[] varAndValue = line.Split(':');
            if (varAndValue[0] == "person1Favarability") 
            {
                person1Favarability = float.Parse(varAndValue[1]);
            }
            else if (varAndValue[0] == "person2Favarability")
            {
                person2Favarability = float.Parse(varAndValue[1]);
            }
            else if(varAndValue[0] == "person3Favarability")
            {
                person3Favarability = float.Parse(varAndValue[1]);
            }
            else if (varAndValue[0] == "person4Favarability")
            {
                person4Favarability = float.Parse(varAndValue[1]);
            }
            else if (varAndValue[0] == "person1IsAlive")
            {
                person1IsAlive = varAndValue[1] == "true";
            }
            else if (varAndValue[0] == "person2IsAlive")
            {
                person2IsAlive = varAndValue[1] == "true";
            }
            else if (varAndValue[0] == "person3IsAlive")
            {
                person3IsAlive = varAndValue[1] == "true";
            }
            else if (varAndValue[0] == "person4IsAlive")
            {
                person4IsAlive = varAndValue[1] == "true";
            }
        }
        Debug.Log("Loading Game");
    }
}