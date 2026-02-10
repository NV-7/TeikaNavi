using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dessertBehavior : MonoBehaviour
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
        
        
        if (col.gameObject.CompareTag(dessert.tag))
        {
            print("collion detected");
            Debug.Log("Collision Detected" + col.gameObject.name + "with " + dessert.name);
            if (this.gameObject.GetInstanceID() > col.gameObject.GetInstanceID())
            {
              

                // 3. Destroy both colliding objects
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }

    }
        
    }

