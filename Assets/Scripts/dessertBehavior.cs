using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class dessertBehavior : MonoBehaviour
{
    GameObject dessert;
    public int type;
    public int points;
    public GameObject[] desserts;
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

        GameObject obj = col.gameObject;
        int currentType = this.type;


        if (col.gameObject.CompareTag(dessert.tag))
        {
            print("collion detected");
            Debug.Log("Collision Detected" + col.gameObject.name + "with " + dessert.name);
            int objType = obj.GetComponent<dessertBehavior>().type;

            if (currentType == objType && currentType != 9)
            {
                Debug.Log("Same Type");
                if (transform.position.x > obj.transform.position.x ||
                      (transform.position.y > obj.transform.position.y
                      && transform.position.x == obj.transform.position.x))
                {
                    Debug.Log("Merge");

                    Destroy(col.gameObject);
                    Destroy(this.gameObject);

                    GameObject newDessert = Instantiate(desserts[currentType + 1],
                        Vector3.Lerp(transform.position, obj.transform.position, 0.5f), Quaternion.identity);
                    newDessert.GetComponent<Collider2D>().enabled = true;
                    newDessert.GetComponent<Rigidbody2D>().gravityScale = 3f;

                }
                    // 3. Destroy both colliding objects
            }
        }
    }
}

    
        
    

