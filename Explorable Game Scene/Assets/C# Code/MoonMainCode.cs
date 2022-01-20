using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMainCode : MonoBehaviour
{
    //Declare Varable
    public float rotationSpeed;
    public float jumpHight;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up*jumpHight);
        }
    }
}
