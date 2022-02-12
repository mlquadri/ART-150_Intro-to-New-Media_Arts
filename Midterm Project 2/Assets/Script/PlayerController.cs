using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public float maxHealthModifier;
	public float maxStaminaModifier;
	public float maxOccultModifier;
	[Header("Cinemachine")]
	[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
	public GameObject CinemachineCameraTarget;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnMainAttack()
	{
		//play sound
		RaycastHit enemy = Detect();
		try
		{
			Debug.Log("Attempting to main attack a(n) " + enemy.transform.name);
			Enemy enemyScript = enemy.transform.GetComponent<Enemy>();
			enemyScript.hit(10);
		}
		catch
		{
			Debug.Log("Main Attack failed");
		}
	}
	private void OnSecondaryAttack()
	{
		//play sound
		currentOccult -= (int)(currentOccult * maxOccultModifier);
		RaycastHit enemy = Detect();
		try
		{
			Debug.Log("Attempting to secondary attack a(n) " + enemy.transform.name);
			Enemy enemyScript = enemy.transform.GetComponent<Enemy>();
			enemyScript.hit(10);
		}
		catch
		{
			Debug.Log("Secondary Attack failed");
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
			else if (interacty.transform.tag == "Enemy")
			{
				Debug.Log("Object is an enemy");
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

	//Gets the object in front of the player (based on the camera)
	public RaycastHit Detect()
	{ // GameObject Detect(float distince, GameObject object) {
		RaycastHit hit;
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