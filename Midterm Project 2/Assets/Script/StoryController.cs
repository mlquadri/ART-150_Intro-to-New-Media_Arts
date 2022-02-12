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
    StreamWriter writer;



    // Start is called before the first frame update
    void Start()
    {
        try
        {
            StreamReader reader = new StreamReader(SAVEfILEnAME);
            string file = reader.ReadToEnd();
            reader.Close();
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

    void UpdateSaveFile(string text)
    {
        writer.WriteLine(text);
    }
}