using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionBehavior : MonoBehaviour

    
   
{
    GameObject dessert;
    // Start is called before the first frame update
    void Start()
    {
        dessert = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        
        if (dessert.name.Equals(col.gameObject.name))
        {
            print("collion detected");
            Debug.Log("Collision Detected" + col.gameObject.name + "with " + dessert.name);
            
        }
        
    }
}
