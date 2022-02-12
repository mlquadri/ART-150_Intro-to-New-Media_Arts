using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerController : MonoBehaviour
{
	[Header("Player Stats")]
	public int maxHealth;
	public int maxStamina;
	public int maxInsanity;
	public int maxOccult;
	public int currentHealth;
	public int currentStamina;
	public int currentOccult;
	public int currentInsanity;
	[Header("Player Stat Modifiers")]
	public float maxHealthModifier;
	public float maxStaminaModifier;
	public float maxOccultModifier;
	public float healthModifier;
	public float staminaModifier;
	public float occultModifier;
	[Header("Cinemachine")]
	[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
	public GameObject CinemachineCameraTarget;
	[Header("Abilitys")]
	public float interactDistance;
	public int mainAttackDamage;
	public int secondaryAttackDamage;
	public float mainAttackCost;
	public float secondaryAttackCost;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentOccult > maxOccult) 
		{
			currentOccult = maxOccult; 
		}
		if ( ((currentInsanity < (maxInsanity / 3)) && (currentHealth > maxHealth)) || (currentHealth > maxHealth + currentInsanity) )
		{
			currentHealth = maxHealth;
		}
		if (currentStamina > maxStamina)
		{
			currentStamina = maxStamina;
		}
		if (currentHealth == 0) 
		{ 
			Debug.Log("Game Over"); 
		}
		if (currentInsanity == maxInsanity) 
		{ 
			Debug.Log("Game is now in insaine mode"); 
		}
    }
	private void OnMainAttack()
	{
		if (currentStamina >= (int)(mainAttackCost * staminaModifier)) 
		{
			currentStamina -= (int)(mainAttackCost*staminaModifier);
		}
		//play sound
		RaycastHit enemy = Detect();
		try
		{
			Debug.Log("Attempting to main attack a(n) " + enemy.transform.name);
			Enemy enemyScript = enemy.transform.GetComponent<Enemy>();
			enemyScript.hit(mainAttackDamage);
		}
		catch
		{
			Debug.Log("Main Attack failed");
		}
	}
	private void OnSecondaryAttack()
	{
		//play sound
		if ((currentOccult - (int)(secondaryAttackCost * occultModifier)) >= 0)
		{
			currentOccult -= (int)(secondaryAttackCost * occultModifier);
			RaycastHit enemy = Detect();
			try
			{
				Debug.Log("Attempting to secondary attack a(n) " + enemy.transform.name);
				Enemy enemyScript = enemy.transform.GetComponent<Enemy>();
				enemyScript.hit(secondaryAttackDamage);
			}
			catch
			{

			}
		}
	}
	private void OnInteract()
	{
		//play sound
		RaycastHit interacty = Detect();
		try
		{
			Debug.Log("Attempting to interact with " + interacty.transform.name);
			if (interacty.transform.tag == "Interactable Object")
			{
				InteractableObject interactyScript = interacty.transform.GetComponent<InteractableObject>();
				interactyScript.Interact(this.gameObject);
			}
			else if (interacty.transform.tag == "Monolith")
			{

				currentInsanity += 1;
				maxOccult += (int)(1*maxOccultModifier);
				if (occultModifier > .25)
				{
					occultModifier /= 2;
				}
				Debug.Log("Object is an Monolith, currentInsanity has increased, maxOccult has been increased to: "+maxOccult+", and occultModifier has decreased to: "+occultModifier);
			}
			else if (interacty.transform.tag == "Painting")
			{
				currentInsanity += 1;
				currentOccult += (int)(1 * (1/occultModifier));
				Debug.Log("Object is an Painting, currentInsanity has increased, currentOccult has been increased to: " + currentOccult); 
			}
			else if (interacty.transform.tag == "Enemy")
			{
				currentHealth -= 5;
				Debug.Log("Object is an enemy, player takes "+5+"damage");
			}
			else if (interacty.transform.tag == "NPC")
			{
				interacty.transform.GetComponent<NPC_Controller>().Interact();
			}
			else
			{
				Debug.Log("Object is not interactable");
			}
		}
		catch
		{
			Debug.Log("Interact failed");
		}
	}
    ///Gets the object in front of the player (based on the camera)
    ///public RaycastHit Detect()
    ///{
    ///	return this.gameObject.ThirdPersonControler.Detect();
    ///}
	//Gets the object in front of the player(based on the camera)
        public RaycastHit Detect()
    { // GameObject Detect(float distince, GameObject object) {
        RaycastHit hit;
#if UNITY_EDITOR
        Debug.DrawLine(CinemachineCameraTarget.transform.position, CinemachineCameraTarget.transform.position + (CinemachineCameraTarget.transform.forward * interactDistance), Color.red);
#endif
        if (Physics.Raycast(CinemachineCameraTarget.transform.position, CinemachineCameraTarget.transform.forward, out hit))
        {
            Debug.Log("Detected " + hit.transform.name);
            return hit;
        }
        Debug.Log("Nothing Detected");
        return hit;
    }

    //public void OnTriggerEnter(Collision collision)
    //{
    //	Debug.Log("Player collided with something");
    //	if (collision.gameObject.tag == "Door")
    //	{
    //		Debug.Log("Entered door, loading next level.");
    //	}
    //}

    //Updates based on physics
    void FixedUpdate()
	{

	}

}