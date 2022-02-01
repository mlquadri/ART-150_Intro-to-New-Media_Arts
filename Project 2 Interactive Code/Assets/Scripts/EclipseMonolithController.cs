using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EclipseMonolithController : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public int health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact() {
        damage++;
        if (damage >= health) {
            Destroy(gameObject);
        }
    }
}
