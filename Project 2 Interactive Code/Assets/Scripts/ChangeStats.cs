using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStats : MonoBehaviour
{
    private bool removingStamina;
    private bool removingHealth;
    [SerializeField] public Text statText;
    public Text HealthText

    // Start is called before the first frame update
    void Start()
    {
        removingHealth = false;
        removingStamina = false;
        //hello world
    }

    // Update is called once per frame
    void Update()
    {
        if (!removingHealth)
        {
            removingHealth = CrossPlatfromInputManager.GetbuttonDown("Fire1");
        }
        if (!removingStamina) {
            removingStamina = CrossPlatfromInputManager.GetbuttonDown("Fire2");
        }
        if (removingHealth) {
            Debug.Log("Removing Health");
            removeingHealth = false;
        }
    }

    // Update is called in sync with physics
    void FixedUpdate() {
        removingHealth = !(!removingHealth);
    }
}
